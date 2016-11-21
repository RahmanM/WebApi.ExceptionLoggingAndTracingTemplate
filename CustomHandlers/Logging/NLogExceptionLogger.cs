using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;
using WebApi.ExceptionAndLogging.ExceptionTypes;

namespace WebApi.ExceptionAndLogging.CustomHandlers.Logging
{
    public class NLogExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {

            if (context.Exception.GetType() != typeof(BusinessException))
            {
                // TODO: log it

            }
        }
    }
}