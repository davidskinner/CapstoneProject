/** TODO: Replace file. This is a template file.
 * 
 *  Controllers folder has to be named exactly Controllers because the MVC-middleware
 *  is explicitly looking for this folder.
 *  A controller is just a class that inherits from the Controller class. It is
 *  responsible for handling the request of a certain route. There is typically
 *  one controller for every REST-endpoint.
 *  For example, say you want a "Cat"-endpoint, we create a Cat-controller that
 *  is responsible for the route "api/cat".
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace shortest_path_UARK.Controllers
{
    /** 
     * Class SampleDataController is decorated by an 
     * attribute (Route), tells the framework, which route this controller is
     * responsible for. Attributes are similar to decorators in angular/TypeScript,
     * they add meta information to the class.
     * The "[controller]" part is replaced by the name of the controller by the
     * framework
    */
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /** 
         * ...All REST-methods have a corresponding C#-method.
         * Method is "decorated" by the "HttpGet" attribute, to tell the framework,
         * that this method should handle get-requests, that are pointed directly
         * at the endpoint. We return an IEnumerable of WeatherForecast.
         * IEnumerable is basically the base-interface of almost everything that
         * is a collection of items.
         * 
         * Getting one specific Element
         * We query for a specific Element, we require the id/name of that Element
         * to be passed, as well. In REST, its done by adding the id/name to the
         * route. E.g. "api/cat/Lilly".
         * To implement this dynamic route, we add a route parameter to the "HttpGet"
         * attribute. Marked by curled-braces. The name inside of the braces will
         * be the name of our parameter.
        */
        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            /** 
            * Output to be either calculated or read from a database.
            * JOSE: Notice this is not read from a server, but rather calculated
            * within this file.
            */
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        /** 
         * C# is strongly typed, so we need to create a model.      
        */
        public class WeatherForecast
        {
            /** 
             * Properties
             * Properties of WeatherForecast         
            */
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
