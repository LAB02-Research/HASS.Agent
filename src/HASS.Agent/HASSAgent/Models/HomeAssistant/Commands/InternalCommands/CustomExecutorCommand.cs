using System;
using System.Diagnostics;
using System.IO;
using HASSAgent.Functions;
using HASSAgent.Models.Internal;
using HASSAgent.Sensors;
using Newtonsoft.Json;
using Serilog;

namespace HASSAgent.Models.HomeAssistant.Commands.InternalCommands
{
    internal class CustomExecutorCommand : InternalCommand
    {
        internal CustomExecutorCommand(string name = "CustomExecutor", string command = "", string id = default) : base(name ?? "CustomExecutor", command, id)
        {
            CommandConfig = command;
            State = "OFF";
        }

        public override void TurnOn()
        {
            State = "ON";

            try
            {
                // is there a custom executor provided?
                if (string.IsNullOrEmpty(Variables.AppSettings.CustomExecutorBinary))
                {
                    Log.Warning("[CUSTOMEXECUTOR] No custom executor provided, unable to execute");
                    return;
                }

                // does the binary still exist?
                if (!File.Exists(Variables.AppSettings.CustomExecutorBinary))
                {
                    Log.Error("[CUSTOMEXECUTOR] Provided custom executor not found: {file}", Variables.AppSettings.CustomExecutorBinary);
                    return;
                }

                // all good, launch
                using (var process = new Process())
                {
                    var startInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true,
                        FileName = Variables.AppSettings.CustomExecutorBinary,
                        Arguments = CommandConfig
                    };

                    process.StartInfo = startInfo;
                    var start = process.Start();

                    // check if the start went ok
                    if (!start)
                    {
                        Log.Error("[CUSTOMEXECUTOR] Unable to start executing command: {command}", CommandConfig);
                        return;
                    }

                    // yep, done
                }
            }
            catch (Exception ex)
            {
                Log.Error("[CUSTOMEXECUTOR] Error while processing custom executor: {err}", ex.Message);
            }
            finally
            {
                State = "OFF";
            }
        }
    }
}
