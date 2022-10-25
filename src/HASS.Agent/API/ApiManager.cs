using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using Grapevine;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Functions;
using HASS.Agent.Shared.Managers;
using Serilog;

#pragma warning disable CA1416 // Validate platform compatibility
namespace HASS.Agent.API
{
    /// <summary>
    /// The local API manager handles incoming requests from HA integrations through a local Rest API (requires our custom integrations)
    /// </summary>
    internal static class ApiManager
    {
        /// <summary>
        /// Initializes and launches a new REST server to receive requests from HA integrations
        /// </summary>
        internal static void Initialize()
        {
            if (!Variables.AppSettings.LocalApiEnabled)
            {
                Log.Information("[LOCALAPI] Disabled");
                Variables.MainForm?.SetLocalApiStatus(ComponentStatus.Stopped);
                return;
            }

            Log.Information("[LOCALAPI] Initializing ..");

            try
            {
                // are we set to ignore cert errors on images?
                if (Variables.AppSettings.NotificationsIgnoreImageCertificateErrors)
                {
                    Log.Information("[LOCALAPI] Ignoring certificate errors for images");

                    // create a handler that drops all certificate errors
                    var handler = new HttpClientHandler
                    {
                        ClientCertificateOptions = ClientCertificateOption.Manual,
                        ServerCertificateCustomValidationCallback = (_, _, _, _) => true
                    };

                    // set a new http client with the handler
                    Variables.HttpClient = new HttpClient(handler);
                }

                // prepare and use a new server
                using (Variables.LocalApiServer = RestServerBuilder.From<ApiConfiguration>().Build())
                {
                    Variables.LocalApiServer.AfterStarting += (s) =>
                    {
                        // root route to show we're up & running
                        s.Router.Register(new Route(async (ctx) =>
                        {
                            await ctx.Response.SendResponseAsync("HASS.Agent Active");
                        }, "Get", "/", true, "RootEndpoint"));

                        // info route
                        var deviceInfoRoute = new Route(ApiEndpoints.DeviceInfoRoute, "Get", "/info", true, "DeviceInfoRoute");
                        s.Router.Register(deviceInfoRoute);

                        // notification route
                        var notifyRoute = new Route(ApiEndpoints.NotifyRoute, "Post", "/notify", true, "NotifyRoute");
                        s.Router.Register(notifyRoute);

                        // media route
                        var mediaRoute = new Route(ApiEndpoints.MediaRoute, "Get", "/media", true, "MediaRoute");
                        s.Router.Register(mediaRoute);

                        // done
                        Log.Information("[LOCALAPI] listening on port {port}", Variables.AppSettings.LocalApiPort);
                        Variables.MainForm?.SetLocalApiStatus(ComponentStatus.Ok);
                    };

                    // register shutdown event
                    Variables.LocalApiServer.AfterStopping += (_) =>
                    {
                        if (Variables.ShuttingDown) return;

                        Log.Information("[LOCALAPI] Stopped");
                        Variables.MainForm?.SetLocalApiStatus(ComponentStatus.Stopped);
                    };

                    // try to launch server
                    try
                    {
                        Variables.LocalApiServer.Run();
                    }
                    catch (Exception ex)
                    {
                        if (Variables.ShuttingDown) return;
                        Log.Fatal(ex, "[LOCALAPI] Error trying to bind the API to port {port}: {err}", Variables.AppSettings.LocalApiPort, ex.Message);
                        Variables.MainForm?.ShowMessageBox(string.Format(Languages.LocalApiManager_Initialize_MessageBox1, Variables.AppSettings.LocalApiPort), true);

                        Variables.MainForm?.SetLocalApiStatus(ComponentStatus.Failed);
                    }
                }
            }
            catch (Exception ex)
            {
                if (Variables.ShuttingDown) return;
                Log.Fatal(ex, "[LOCALAPI] Error initializing the API to {port}: {err}", Variables.AppSettings.LocalApiPort, ex.Message);
                Variables.MainForm?.SetLocalApiStatus(ComponentStatus.Failed);
            }
        }

        /// <summary>
        /// Stops and disposes the REST server
        /// </summary>
        internal static void Stop()
        {
            try
            {
                Variables.LocalApiServer?.Stop();
                Variables.LocalApiServer?.Dispose();
            }
            catch (ObjectDisposedException)
            {
                // whatever
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[LOCALAPI] Error trying to stop: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Attempt to add HTTP port reservation through an elevated console
        /// </summary>
        /// <returns></returns>
        internal static bool ExecuteElevatedPortReservation()
        {
            try
            {
                using var p = new Process();
                p.StartInfo.Verb = "runas";
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.FileName = Variables.ApplicationExecutable;
                p.StartInfo.Arguments = "portreservation";

                var success = p.Start();
                if (!success)
                {
                    Log.Error("[LOCALAPI] Error while executing elevated port reservation");
                    return false;
                }

                p.WaitForExit();

                if (p.ExitCode != 0) Log.Warning("[LOCALAPI] Elevated port reservation executed with non-standard exitcode: {exitcode}", p.ExitCode);
                else Log.Information("[LOCALAPI] Elevated port reservation executed succesfully");

                return p.ExitCode == 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Attempt to add HTTP port reservation (requires elevation!)
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "InvertIf")]
        internal static async Task<bool> ExecutePortReservationAsync(int port)
        {
            try
            {
                Log.Information("[LOCALAPI] Executing port reservation for port: {port}", port);

                var args = $"http add urlacl url=http://+:{port}/ user=\"{SharedHelperFunctions.EveryoneLocalizedAccountName()}\"";
                var executionResult = await CommandLineManager.ExecuteCommandAsync("netsh", args, TimeSpan.FromMinutes(2));

                // capture normal and error output
                var output = executionResult.Output.Trim();
                var errOutput = executionResult.ErrorOutput.Trim();
                var exitCode = executionResult.ExitCode;

                // all good?
                if (exitCode == 0)
                {
                    Log.Information("[LOCALAPI] Port reservation succesfully added");
                    return true;
                }

                // check for known errors
                if (output.Contains(": 183") || errOutput.Contains(": 183"))
                {
                    Log.Information("[LOCALAPI] Port reservation already exists, nothing to do");
                    return true;
                }
                if (output.Contains(": 5") || errOutput.Contains(": 5"))
                {
                    Log.Error("[LOCALAPI] Port reservation failed, requires elevation");
                    return false;
                }
                if (output.Contains(": 1332") || errOutput.Contains(": 1332"))
                {
                    Log.Error("[LOCALAPI] Port reservation failed, incorrect parameters provided: {param}", args);
                    return false;
                }

                // nope, something went wrong
                Log.Error("[LOCALAPI] Execution failed, port reservation probably failed - exitcode: {code}", exitCode);

                // process & print normal output
                if (!string.IsNullOrEmpty(output))
                {
                    var consoleLog = new StringBuilder();

                    consoleLog.AppendLine("[LOCALAPI] Console output:");
                    consoleLog.AppendLine("");
                    consoleLog.AppendLine(output);
                    consoleLog.AppendLine("");

                    Log.Information(consoleLog.ToString());
                }

                // process & print error output
                if (!string.IsNullOrEmpty(errOutput))
                {
                    var consoleErrLog = new StringBuilder();

                    consoleErrLog.AppendLine("[LOCALAPI] Error output:");
                    consoleErrLog.AppendLine("");
                    consoleErrLog.AppendLine(errOutput);
                    consoleErrLog.AppendLine("");

                    Log.Error(consoleErrLog.ToString());
                }

                // done
                return false;
            }
            catch (Exception ex)
            {
                Log.Fatal("[LOCALAPI] Error while executing port reservation: {msg}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Attempt to remove HTTP port reservation (requires elevation!)
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "InvertIf")]
        internal static async Task<bool> RemovePortReservationAsync(int port)
        {
            try
            {
                Log.Information("[LOCALAPI] Removing port reservation for port: {port}", port);

                var args = $"http delete urlacl url=http://+:{port}/";
                var executionResult = await CommandLineManager.ExecuteCommandAsync("netsh", args, TimeSpan.FromMinutes(2));

                // capture normal and error output
                var output = executionResult.Output.Trim();
                var errOutput = executionResult.ErrorOutput.Trim();
                var exitCode = executionResult.ExitCode;

                // all good?
                if (exitCode == 0)
                {
                    Log.Information("[LOCALAPI] Port reservation succesfully removed");
                    return true;
                }

                // check for known errors
                if (output.Contains(": 2") || errOutput.Contains(": 2"))
                {
                    Log.Information("[LOCALAPI] Port reservation already removed, nothing to do");
                    return true;
                }
                if (output.Contains(": 5") || errOutput.Contains(": 5"))
                {
                    Log.Error("[LOCALAPI] Port reservation failed, requires elevation");
                    return false;
                }
                if (output.Contains(": 1332") || errOutput.Contains(": 1332"))
                {
                    Log.Error("[LOCALAPI] Port reservation failed, incorrect parameters provided: {param}", args);
                    return false;
                }

                // nope, something went wrong
                Log.Error("[LOCALAPI] Execution failed, port reservation removal probably failed - exitcode: {code}", exitCode);

                // process & print normal output
                if (!string.IsNullOrEmpty(output))
                {
                    var consoleLog = new StringBuilder();

                    consoleLog.AppendLine("[LOCALAPI] Console output:");
                    consoleLog.AppendLine("");
                    consoleLog.AppendLine(output);
                    consoleLog.AppendLine("");

                    Log.Information(consoleLog.ToString());
                }

                // process & print error output
                if (!string.IsNullOrEmpty(errOutput))
                {
                    var consoleErrLog = new StringBuilder();

                    consoleErrLog.AppendLine("[LOCALAPI] Error output:");
                    consoleErrLog.AppendLine("");
                    consoleErrLog.AppendLine(errOutput);
                    consoleErrLog.AppendLine("");

                    Log.Error(consoleErrLog.ToString());
                }

                // done
                return false;
            }
            catch (Exception ex)
            {
                Log.Fatal("[LOCALAPI] Error while removing port reservation: {msg}", ex.Message);
                return false;
            }
        }
    }
}
#pragma warning restore CA1416 // Validate platform compatibility
