using System.Net;
using System.Net.Sockets;
using System.Runtime.ExceptionServices;
using MQTTnet.Exceptions;
using Serilog;

namespace HASS.Agent.Managers
{
    internal static class LoggingManager
    {
        private static readonly List<string> LoggedFirstChanceHttpRequestExceptions = new();
        private static string _lastLog = string.Empty;

        /// <summary>
        /// Initializes Serilog logger
        /// </summary>
        internal static void PrepareLogging(string[] args)
        {
            var logName = string.Empty;
            if (args.Any()) logName = $"{args.First(x => !string.IsNullOrEmpty(x))}_";

            // prepare a serilog logger
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Async(a =>
                    a.File(Path.Combine(Variables.LogPath, $"[{DateTime.Now:yyyy-MM-dd}] {Variables.ApplicationName}_{logName}.log"),
                        rollingInterval: RollingInterval.Day,
                        fileSizeLimitBytes: 10000000,
                        retainedFileCountLimit: 10,
                        rollOnFileSizeLimit: true,
                        buffered: true,
                        flushToDiskInterval: TimeSpan.FromMilliseconds(150)))
                .CreateLogger();
        }

        /// <summary>
        /// Processes FirstChanceExceptions (when extended logging's enabled)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        /// <exception cref="NotImplementedException"></exception>
        internal static void CurrentDomainOnFirstChanceException(object sender, FirstChanceExceptionEventArgs eventArgs)
        {
            try
            {
                // resource exceptions can be ignored
                if (eventArgs.Exception.Message.Contains("GetLocalizedResourceManager")) return;

                // syncfusion input-string errors as well
                if (eventArgs.Exception.Message.Contains("IntegerTextBox.FormatChanged")) return;

                // we only log these once-in-a-row, to prevent spamming
                if (!string.IsNullOrEmpty(_lastLog))
                {
                    if (_lastLog == eventArgs.Exception.ToString()) return;
                    if (eventArgs.Exception.ToString().Contains(_lastLog)) return;
                }
                _lastLog = eventArgs.Exception.ToString();

                // handle based on exception type
                switch (eventArgs.Exception)
                {
                    // handle filenotfound exceptions
                    case FileNotFoundException fileNotFoundException:
                        HandleFirstChanceFileNotFoundException(fileNotFoundException);
                        return;

                    // handle socket exceptions
                    case SocketException socketException:
                        HandleFirstChanceSocketException(socketException);
                        return;

                    // handle web exceptions
                    case WebException webException:
                        HandleFirstChanceWebException(webException);
                        return;

                    // handle httprequest exceptions
                    case HttpRequestException httpRequestException:
                        HandleFirstChanceHttpRequestException(httpRequestException);
                        return;

                    // handle mqttcommunication exceptions
                    case MqttCommunicationException mqttCommunicationException:
                        HandleFirstChanceMqttCommunicationException(mqttCommunicationException);
                        return;

                    // just log it
                    default:
                        Log.Fatal(eventArgs.Exception, "[PROGRAM] FirstChanceException: {err}", eventArgs.Exception.Message);
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[PROGRAM] Error processing FirstChanceException: {err}", ex.Message);
            }
        }

        private static void HandleFirstChanceFileNotFoundException(FileNotFoundException fileNotFoundException)
        {
            // ignore resources
            if (fileNotFoundException.FileName != null && fileNotFoundException.FileName.Contains("resources")) return;

            Log.Error("[PROGRAM] FileNotFoundException: {err}", fileNotFoundException.Message);
        }

        private static void HandleFirstChanceSocketException(SocketException socketException)
        {
            var socketErrorCode = socketException.SocketErrorCode;
            switch (socketErrorCode)
            {
                case SocketError.ConnectionRefused:
                    Log.Error("[NET] [{type}] {err}", socketErrorCode.ToString(), socketException.Message);
                    return;

                case SocketError.ConnectionReset:
                    Log.Error("[NET] [{type}] {err}", socketErrorCode.ToString(), socketException.Message);
                    return;

                default:
                    Log.Fatal(socketException, "[NET] [{type}] {err}", socketErrorCode.ToString(), socketException.Message);
                    break;
            }
        }

        private static void HandleFirstChanceWebException(WebException webException)
        {
            var status = webException.Status;
            switch (status)
            {
                case WebExceptionStatus.ConnectFailure:
                    Log.Error("[NET] [{type}] {err}", status.ToString(), webException.Message);
                    return;

                case WebExceptionStatus.Timeout:
                    Log.Error("[NET] [{type}] {err}", status.ToString(), webException.Message);
                    return;

                default:
                    Log.Fatal(webException, "[NET] [{type}] {err}", status.ToString(), webException.Message);
                    return;
            }
        }

        private static void HandleFirstChanceHttpRequestException(HttpRequestException httpRequestException)
        {
            // usually contains a more interesting inner exception
            if (httpRequestException.InnerException != null)
            {
                switch (httpRequestException.InnerException)
                {
                    case SocketException sE:
                        HandleFirstChanceSocketException(sE);
                        break;
                    case WebException wE:
                        HandleFirstChanceWebException(wE);
                        break;
                }
            }

            // only log once to prevent spamming
            var excMsg = httpRequestException.ToString();
            if (LoggedFirstChanceHttpRequestExceptions.Contains(excMsg)) return;
            LoggedFirstChanceHttpRequestExceptions.Add(excMsg);

            if (excMsg.Contains("SocketException"))
            {
                Log.Error("[NET] [{type}] {err}", "FirstChanceHttpRequestException.SocketException", httpRequestException.Message);
                return;
            }

            // just log it
            Log.Fatal(httpRequestException, "[NET] FirstChanceHttpRequestException: {err}", httpRequestException.Message);
        }

        private static void HandleFirstChanceMqttCommunicationException(MqttCommunicationException mqttCommunicationException)
        {
            // usually contains a more interesting inner exception
            if (mqttCommunicationException.InnerException != null)
            {
                switch (mqttCommunicationException.InnerException)
                {
                    case SocketException sE:
                        HandleFirstChanceSocketException(sE);
                        break;
                    case WebException wE:
                        HandleFirstChanceWebException(wE);
                        break;
                }
            }

            // check for exceptions in message
            var excMsg = mqttCommunicationException.ToString();
            if (excMsg.Contains("SocketException"))
            {
                Log.Error("[NET] [{type}] {err}", "MqttCommunicationException.SocketException", mqttCommunicationException.Message);
                return;
            }
            if (excMsg.Contains("OperationCanceledException"))
            {
                Log.Error("[NET] [{type}] {err}", "MqttCommunicationException.OperationCanceledException", mqttCommunicationException.Message);
                return;
            }

            // just log it
            Log.Fatal(mqttCommunicationException, "[NET] FirstChancemqttCommunicationException: {err}", mqttCommunicationException.Message);
        }
    }
}
