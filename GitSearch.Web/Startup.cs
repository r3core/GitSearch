using Autofac;
using AutoMapper;
using GitSearch.Application.Services.Interfaces;
using GitSearch.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GitSearch.Web
{
    /// <summary>
    /// Class defining the start up configuration of the application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Creates an instance of <see cref="Startup"/>.
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/> to be injected.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddMvc();
        }

        /// <summary>
        /// DI Container configuration for the Application and Repository layer.
        /// </summary>
        /// <param name="builder">A <see cref="ContainerBuilder"/> instance.</param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IUserRepository).Assembly)
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(IUserService).Assembly)
                .AsImplementedInterfaces();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Users/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Users}/{action=Index}/{id?}");
            });
        }
    }
}
