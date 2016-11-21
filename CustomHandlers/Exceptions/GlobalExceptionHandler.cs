using System.Web.Http.ExceptionHandling;

namespace WebApi.ExceptionAndLogging.CustomHandlers.Exceptions
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var result = HandleException.Handle(context);
            context.Result = result;
        }

        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }
    }
}