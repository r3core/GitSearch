using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace GitSearch.Web
{
    /// <summary>
    /// Class defining the entry point of the program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point of the program.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// Builds the <see cref="IWebHost"/> instance.
        /// </summary>
        /// <param name="args">CL arguments.</param>
        /// <returns>The built <see cref="IWebHost"/> instance.</returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services.AddAutofac())
                .UseStartup<Startup>()
                .Build();
    }
}
