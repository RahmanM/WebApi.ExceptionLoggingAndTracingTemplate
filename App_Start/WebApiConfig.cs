using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Tracing;
using WebApi.ExceptionAndLogging.CustomHandlers.Exceptions;
using WebApi.ExceptionAndLogging.CustomHandlers.Logging;

namespace WebApi.ExceptionAndLogging
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            // Web API configuration and services
            config.Services.Replace(typeof (IExceptionHandler), new GlobalExceptionHandler());
            config.Services.Replace(typeof(IExceptionLogger), new NLogExceptionLogger());
            config.Services.Replace(typeof(ITraceWriter), new WebApiContrib.Tracing.Nlog.NlogTraceWriter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
