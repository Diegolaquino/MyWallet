using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Services.Responses
{
    public class FailureResponse : ResponseBase
    {
        public string Details { get; private set; }
        public string StackTrace { get; private set; }

        public FailureResponse(int statusCode, string message, string details = "", string stackTrace = "") : base(statusCode, message)
        {
            Details = details;
            StackTrace = stackTrace;
        }
    }
}
