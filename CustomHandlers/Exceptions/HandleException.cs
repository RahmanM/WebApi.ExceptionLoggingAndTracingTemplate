using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using WebApi.ExceptionAndLogging.ExceptionTypes;

namespace WebApi.ExceptionAndLogging.CustomHandlers.Exceptions
{
    public class HandleException
    {
        public static ResponseMessageResult Handle(ExceptionHandlerContext context)
        {
            var exception = context.Exception;

            if (exception is BusinessException)
            {
                return HandleBusinessException(context);
            }
            else
            {
                return HandleUnhandledException(context);
            }
        }

        private static ResponseMessageResult HandleUnhandledException(ExceptionHandlerContext context)
        {
            // log it
            Elmah.ErrorSignal.FromCurrentContext().Raise(context.Exception);

            var generalException = context.Exception as GeneralException;

            if (generalException != null)
            {
                return GetResponseMessageResult(context, generalException.TicketNumber);
            }
            else
            {
                return GetResponseMessageResult(context, Guid.NewGuid().ToString());
            }

        }

        private static ResponseMessageResult GetResponseMessageResult(
            ExceptionHandlerContext context, 
            string errorNumber)
        {
            var errorData = new ExceptionResponse()
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = "Some unhandled error happened. The error has been logged and will be fixed. We appologise blah blah....",
                ErrorNumber = errorNumber,
                Stack = context.Exception.StackTrace
            };

            var response = context.Request.CreateResponse(errorData);
            var result = new ResponseMessageResult(response);
            return result;
        }

        private static ResponseMessageResult HandleBusinessException(ExceptionHandlerContext context)
        {
            var errorData = new ExceptionResponse()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = context.Exception.Message,
                ErrorNumber = ((BusinessException) context.Exception).TicketNumber
            };

            var response = context.Request.CreateResponse(errorData);
            var result = new ResponseMessageResult(response);
            return result;
        }
    }
}