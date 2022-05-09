using Microsoft.AspNetCore.Mvc.Filters;

namespace APICatalogo.Filters
{
    public class ApiLoggingFilter : IActionFilter
    {

        private readonly ILogger<ApiLoggingFilter> _logger;
        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
        {
            _logger = logger;

        }




        //executa antes da action
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Executando antes da action");
        }
        //executa depois da action
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("Executando depois da action");
        }


    }
}
