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

        public FailureResponse(int statusCode, string userErroMessage, Exception ex = null, string details = "") : base(statusCode, userErroMessage)
        {
            Details = ex?.Message ?? details;
            StackTrace = ex?.StackTrace ?? "";
        }
    }
}
