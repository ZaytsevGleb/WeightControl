using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using WeightControl.Application.Common.Models;
using WeightControl.Application.Exceptions;

namespace WeightControl.Api.Infrastructure
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(new ErrorDto { Description = ex.Message});
            }
            catch (BadRequestException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new ErrorDto { Description = ex.Message });
            }
        }
    }
}
