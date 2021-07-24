using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EmptyCoreApp.Middleware
{
    public class QueryMiddleware
    {
        private RequestDelegate next;

        public QueryMiddleware(RequestDelegate requestDelegate)
        {
            next = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
                await context.Response.WriteAsync("Custom middleware from query middleware -- 1 \n");

            await next(context);
        }
    }
}
