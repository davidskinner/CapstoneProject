/** The entry point of our application. Every C# program starts with a static
*   method called Main. That Main is in this class Program. It calls BuildWebHost
*   method
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace shortest_path_UARK
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /** Configures and starts the server-app */
            CreateWebHostBuilder(args).Build().Run();
        }

        /** Builder is told to use class Startup (i.e. Startup.cs), to configure 
         * our app. */
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
