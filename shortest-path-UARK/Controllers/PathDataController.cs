/** 
 *  Controllers folder has to be named exactly Controllers because the MVC-middleware
 *  is explicitly looking for this folder.
 *  A controller is just a class that inherits from the Controller class. It is
 *  responsible for handling the request of a certain route. There is typically
 *  one controller for every REST-endpoint.
 *  For example, say you want a "Cat"-endpoint, we create a Cat-controller that
 *  is responsible for the route "api/cat".
*/

using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shortestpathUARK.Models;

namespace shortest_path_UARK.Controllers
{
    /** 
     * Class PathDataController is decorated by an 
     * attribute (Route), tells the framework, which route this controller is
     * responsible for. Attributes are similar to decorators in angular/TypeScript,
     * they add meta information to the class.
     * The "[controller]" part is replaced by the name of the controller by the
     * framework
    */
    [Route("api/[controller]")]
    public class PathDataController : Controller
    {
        static readonly IJsonDataTransferObjectRepository repository = new JsonDataTransferObjectRepository();

        /** 
         * JOSE: Web API deserializes (i.e. stream of bytes is converted into an object)
         * the parameter from the request body. Hence, we serialize (i.e. convert an
         * object into a stream of bytes).
        */
        [HttpPost("[action]")]
        public JsonDataTransferObject PostClassrooms([FromBody]JsonDataTransferObject classroomObject)
        {
            // TESTING: Print the contents of the nested JSON object to
            // "Application Output" to confirm binding.
            // https://stackoverflow.com/questions/5166486/how-to-print-values-from-json-type-object-to-console-in-c-sharp
            Console.WriteLine();
            Console.WriteLine("TESTING...");
            Console.WriteLine(JsonConvert.SerializeObject(classroomObject));
            Console.WriteLine();

            return classroomObject;
        }

        /** TODO: Implement method...png file. */
        //...
    }
}
