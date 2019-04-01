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
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        /** 
         * TODO: Implement method
         * 
         * To insert a new element at our endpoint.       
        */
        [Route("/api/PathData/onSubmit")]
        [HttpPost]
        public void OnSubmit([FromBody]Classroom classroom)
        {
            /** TESTING: ...*/
            Console.WriteLine(classroom.ClassName);
        }

        //[HttpPost]
        //public Task<ActionResult> AngularData(Classroom classroom)
        //{
        //    //return Json(new { foo = "bar", baz = "Blech" });
        //}

        /** 
         * TODO: Implement method
         *
         * JOSE: Create an HttpGet method to calculate and output the path.       
        */
        /*
        [HttpGet]
        public IEnumerable<Something> path()
        {
            return Enumerable...;
        }*/

        /** 
         * C# is strongly typed, so we need to create a model.      
        */

    }
}
