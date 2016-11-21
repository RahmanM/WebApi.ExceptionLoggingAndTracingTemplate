using System;
using System.Globalization;
using System.Net;

namespace WebApi.ExceptionAndLogging.CustomHandlers.Exceptions
{
    public class ExceptionResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public string ErrorNumber { get; set; }
        public string Stack { get; set; }

        public string ErrorDateTime
        {
            get { return DateTime.Now.ToString(CultureInfo.InvariantCulture); }
        }

    }
}