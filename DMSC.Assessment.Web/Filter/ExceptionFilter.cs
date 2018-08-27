namespace DMSC.Assessment.Web.Filter
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;

    public class ExceptionFilter : IExceptionFilter
    {
        private ILogger<ExceptionFilter> _logger;
       
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            if (context == null || context.Exception == null)
                return;

            //just log an exception here, handle it later
            context.ExceptionHandled = false;
           _logger.LogError(context.Exception.Message, context.Exception);
        }
    }
}
