using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Templates.Api.Filters
{
    public class LogExceptionFilter : IExceptionFilter
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<LogExceptionFilter> _logger;

        public LogExceptionFilter(IConfiguration configuration, ILogger<LogExceptionFilter> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public void OnException(ExceptionContext exceptionContext)
        {
            var log = new
            {
                Title = "Error",
                Message = exceptionContext.Exception.Message,
                Date = DateTime.Now,
                ProjectName = _configuration["ProjectName"],
                Host = exceptionContext.HttpContext.Request.Host.Value,
                HostSource = exceptionContext.HttpContext.Request?.Path,
                CorrelationId = exceptionContext.HttpContext.Request.Headers["CorrelationId"]
            };

            _logger.LogError(
                exceptionContext.Exception,
                exceptionContext.Exception.Message,
                log
                );
        }
    }
}
