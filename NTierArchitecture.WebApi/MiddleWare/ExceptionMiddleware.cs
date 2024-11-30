
namespace NTierArchitecture.WebApi.MiddleWare
{
    public sealed class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (Exception e)
			{
				await HandleExceptionAsync(context, e);
			}
        }

		private  Task HandleExceptionAsync(HttpContext context, Exception e)
		{
			context.Response.ContentType = "application/json";
			//context.Response.StatusCode = 500;
			return context.Response.WriteAsync(new
			{
				Message = e.Message
			}.ToString());

		}
	}
}
