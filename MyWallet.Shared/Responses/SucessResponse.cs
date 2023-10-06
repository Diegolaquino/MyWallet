using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Services.Responses
{
    public class SucessResponse<T> : ResponseBase
    {
        public  T Value { get; set; }
        public SucessResponse(int statusCode, T value, string message = "") : base(statusCode, message)
        {
            Value = value;
        }
    }
}
