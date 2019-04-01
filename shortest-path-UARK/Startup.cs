/** Here, we add features and services to our server.
*
*/

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace shortest_path_UARK
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /** This method gets called by the runtime. Use this method to add 
         * services to the container. These services can then be requested via
         * dependency injection in our classes constructors like Angular.       
         */       

        public void ConfigureServices(IServiceCollection services)
        {
            /** MVC-Service (Model-View-Controller). This service is responsible
             * for routing the HTTP-requests to our controllers.
            */
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        /** This method gets called by the runtime. Use this method to configure 
         * the HTTP request pipeline. With this application-builder, we can add
         * middleware to our HTTP-request pipeline.       
        */
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            /**            
             * MVC-middleware is responsible for forwarding the requests to the
             * responsible controller.
             *            
            */
            app.UseMvc(routes =>
            {
                /** 
                 * TODO: Setup to match PathDataController.cs. This is setup for
                 * the template.
                 * DONE.
                */
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    /** 
                     * https://docs.microsoft.com/en-us/aspnet/core/client-side/spa/angular?view=aspnetcore-2.2&tabs=visual-studio
                     * Won't launch an Angular ClI server, but instead use the
                     * instance you start manually. Enables it to start and restart faster.
                    */
                    //spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
