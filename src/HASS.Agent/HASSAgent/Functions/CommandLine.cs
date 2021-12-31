using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.Buffered;
using HASSAgent.Models;
using HASSAgent.Models.Internal;
using Serilog;

namespace HASSAgent.Functions
{
    internal static class CommandLine
    {
        // ReSharper disable once ConvertToConstant.Local
        private static readonly uint FileNotFoundUint = 0x80004005;
        private static readonly int FileNotFoundError = (int)FileNotFoundUint;

        /// <summary>
        /// Executes the file within a command prompt, parses & returns the output
        /// /// <para>Uses default timeout of 5 minutes</para>
        /// </summary>
        /// <param name="file"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static async Task<ConsoleResult> ExecuteCommandAsync(string file, string args)
        {
            return await ExecuteCommandAsync(file, args, TimeSpan.FromMinutes(5));
        }

        /// <summary>
        /// Executes the file within a command prompt, parses & returns the output
        /// </summary>
        /// <param name="file"></param>
        /// <param name="args"></param>
        /// <param name="timout"></param>
        /// <returns></returns>
        internal static async Task<ConsoleResult> ExecuteCommandAsync(string file, string args, TimeSpan timout)
        {
            var consoleResult = new ConsoleResult();

            try
            {
                using (var cts = new CancellationTokenSource())
                {
                    cts.CancelAfter(timout);
                    
                    var result = await Cli.Wrap(file)
                        .WithArguments(args)
                        .WithValidation(CommandResultValidation.None)
                        .ExecuteBufferedAsync(cts.Token);

                    var exitCode = result.ExitCode;
                    var stdOut = result.StandardOutput;
                    var stdErr = result.StandardError;

                    if (cts.IsCancellationRequested)
                    {
                        // timeout elapsed
                        Log.Error("[CLI] Execution didn't finish within timeout limit (exitcode: {exitCode}): {file}", exitCode, file);
                    }
                    else
                    {
                        // executed within timeout
                        if (exitCode != 0) Log.Warning("[PROCESS] Execution returned non-ok exitcode (exitcode: {exitCode}): {file}", exitCode, file);
                    }

                    // add console output to the console result
                    if (!string.IsNullOrEmpty(stdOut))
                    {
                        var output = stdOut.Trim();
                        output = output.Replace(@"\r\n", Environment.NewLine);
                        output = output.Replace(@"\n", Environment.NewLine);

                        var consoleOutput = new StringBuilder();

                        foreach (var row in output.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
                        {
                            consoleOutput.AppendLine(row);
                        }

                        consoleResult.Output = consoleOutput.ToString();
                    }
                    else consoleResult.Output = string.Empty;

                    // add console error output to the console result
                    if (!string.IsNullOrEmpty(stdErr))
                    {
                        var err = stdErr.Trim();
                        err = err.Replace(@"\r\n", Environment.NewLine);
                        err = err.Replace(@"\n", Environment.NewLine);

                        var errorOutput = new StringBuilder();

                        foreach (var row in err.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
                        {
                            errorOutput.AppendLine(row);
                        }

                        consoleResult.ErrorOutput = errorOutput.ToString();
                    }
                    else consoleResult.ErrorOutput = string.Empty;

                    // complete the console result
                    var success = exitCode == 0 && string.IsNullOrEmpty(stdErr);

                    consoleResult.Error = !success;
                    consoleResult.ExitCode = exitCode;

                    // done
                    return consoleResult;
                }
            }
            catch (Win32Exception we)
            {
                // win32 file-not-found error
                if (we.NativeErrorCode == FileNotFoundError || we.NativeErrorCode == 2)
                {
                    Log.Error("[CLI] File not found, unable to execute: {file}", file);
                    return consoleResult.SetError("file not found");
                }

                // this error means a x64 file has been run on an x86 environment (probably)
                if (we.NativeErrorCode == 193)
                {
                    var os32 = Environment.Is64BitOperatingSystem ? "NO" : "YES";
                    Log.Error("[CLI] File isn't compatible with the current platform (OS is 32bit: {os32})", os32);
                    return consoleResult.SetError("file incompatible with platform");
                }

                // code unknown
                Log.Error("[CLI] Unknown WIN32 error encountered (code: {code}): {file}", we.NativeErrorCode, file);
                return consoleResult.SetError("unknown error");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[CLI] Fatal error when executing file: {file}", file);
                return consoleResult.SetError("fatal error");
            }
        }
    }
}
