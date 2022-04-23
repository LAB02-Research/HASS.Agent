using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASS.Agent.Models.Internal
{
    public class TestResult
    {
        public TestResult SetFailed(string reason)
        {
            Succesful = false;
            ErrorReason = reason;
            return this;
        }

        public TestResult SetSuccesful(string returnValue)
        {
            Succesful = true;
            ReturnValue = returnValue;
            return this;
        }

        public TestResult()
        {
            //
        }

        public bool Succesful { get; set; }
        public string ReturnValue { get; set; }
        public string ErrorReason { get; set; }
    }
}
