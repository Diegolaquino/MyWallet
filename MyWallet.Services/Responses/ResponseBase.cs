using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Services.Responses
{
    public abstract class ResponseBase
    {
        protected ResponseBase(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public int StatusCode { get; protected set; }

        public string Message { get; protected set; }

        public void SetStatusCode(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
