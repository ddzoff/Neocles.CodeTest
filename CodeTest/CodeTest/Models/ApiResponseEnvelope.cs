using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeTest.Models
{
    public class ApiResponseEnvelope<TResponse>
    {
        public TResponse Data { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public ApiResponseEnvelope()
        {
            Success = true;
        }
    }

    public class ApiResponseEnvelope : ApiResponseEnvelope<object>
    {
        public ApiResponseEnvelope(object data) : base()
        {
        }
    }
}