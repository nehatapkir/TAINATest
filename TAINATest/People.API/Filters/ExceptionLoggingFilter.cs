using Microsoft.Extensions.Logging;
using System;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace TAINATest.Filters
{
    public class ExceptionLoggingFilter : ExceptionFilterAttribute
    {
        private ILogger _logger;

        public ExceptionLoggingFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            Exception ex = context.Exception;

            if (_logger != null)
            {
                _logger.LogError(ex.Message);
            }     
        }

}
}
