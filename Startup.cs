using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EmptyCoreApp.Middleware;

namespace EmptyCoreApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            MvcOptions obj = new MvcOptions();
            obj.EnableEndpointRouting = false;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            #region MiddlewareCoomponents

            //app.Use(async (context, next) => {

            //    if (context.Request.Method == HttpMethods.Get 
            //           && context.Request.Query["custom"] == "true")
            //    {
            //        await next(); // immediately next middleware component will be called 
            //        await context.Response.WriteAsync("\n Custom Middleware --4 \n");
            //    }              
            //});

            //app.UseMiddleware<QueryMiddleware>();

            //app.Use(async (context, next) => {
            //    if (context.Request.Method == HttpMethods.Get)
            //        await context.Response.WriteAsync("This is post request coming from middleware --2  \n");
            //    await next();
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World! -- 3");
            //    });
            //});

            #endregion

            #region EndPointsWithLiteralSegments

            app.UseEndpoints(endPoints => {
                endPoints.MapGet("routing", async context =>
                    await context.Response.WriteAsync("This is sample routing")
                );
            });

            app.UseEndpoints(endPoints => {
                endPoints.MapGet("first/second", async context =>
                    await context.Response.WriteAsync("This is slash routing")
                ) ;                        
            });

            #endregion


        }
    }
}
