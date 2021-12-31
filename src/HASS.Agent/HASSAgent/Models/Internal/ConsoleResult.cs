namespace HASSAgent.Models.Internal
{
    public class ConsoleResult
    {
        public ConsoleResult()
        {
            //
        }

        public ConsoleResult SetError(string errorOutput, int exitCode = -1, string output = "")
        {
            Error = true;
            ExitCode = exitCode;
            ErrorOutput = errorOutput;
            Output = output;

            return this;
        }

        public ConsoleResult SetSucces(string output, int exitCode = -1, string errorOuput = "")
        {
            Error = false;
            ExitCode = exitCode;
            Output = output;
            ErrorOutput = errorOuput;

            return this;
        }

        public bool Error { get; set; }
        public int ExitCode { get; set; } = -1;
        public string Output { get; set; } = string.Empty;
        public string ErrorOutput { get; set; } = string.Empty;
    }
}
