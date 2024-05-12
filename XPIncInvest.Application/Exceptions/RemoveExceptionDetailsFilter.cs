using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace XPIncInvest.Application.Exceptions
{
    public class RemoveExceptionDetailsFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _environment;

        public RemoveExceptionDetailsFilter(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public void OnException(ExceptionContext context)
        {
            if (!_environment.IsDevelopment())
            {
                context.Exception = null; // Remove a exceção
            }
        }


    }
}
