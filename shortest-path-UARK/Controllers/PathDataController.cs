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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
         * TODO: Better design (dependency injection)
         *         
         * ..."not the best design"...better approach see the link.
         * https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/dependency-injection 
        */
        static readonly IJsonDataTransferObjectRepository repository = new JsonDataTransferObjectRepository();

        /** 
         * TODO: Implement method
         * 
         * TODO: Summarize comments        
         * https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/        
         * Internet Media Types (MIME type), identifies the format of a piece of data.
         * In HTTP, media types describe the format of the message body. A media
         * type consists of two strings, a type and a subtype (e.g. application/json).
         * When an HTTP message contains an entity-body, the Content-Type header
         * specifies the format of the message body. This tells the receiver how
         * to parse the contents of the message body.
         * Media type determines how Web API serializes and deserializes the HTTP
         * message body. Web API has built-in support for...JSON...        
         * 
         * https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/json-and-xml-serialization
         * In ASP.NET Web API, a media-type formatter is an object that can:
         * Read CLR objects from an HTTP message body
         * Write CLR objects into an HTTP message body
         * Web API provides media-type formatters for JSON. The framework inserts
         * these formatters into the pipeline by default. Clients can request
         * JSON in the Accept header of the HTTP request.
         * 
         * https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/content-negotiation        
         * ...
         * 
         * https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/model-validation-in-aspnet-web-api
         * ...
         *         
         * https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/parameter-binding-in-aspnet-web-api        
         * When Web API calls a method on a controller, it must set values for the
         * parameters (binding). For complex types, Web API tries to read the value
         * from the message body using a 'media-type formatter'.
         * A key principle of HTTP is that resources are sent in the message body,
         * using content negotiation to specify the representation of the resource.
         * Media-type formatters were designed for exactly this purpose.
         * [FromBody]- To force Web API to read a simple type from the request body
         * (e.g. a raw JSON string (not a JSON object))
         * Create a custom model binder, giving you access to the HTTP request,
         * the action description, and the raw values from the route data.
         * ...        
         * 
         * https://docs.microsoft.com/en-us/aspnet/web-api/overview/older-versions/creating-a-web-api-that-supports-crud-operations
         * Create a resource (new classroom). The client sends an HTTP POST request.
         * The method takes a parameter of type Classrooms. In Web API, parameters
         * w/ complex types are deserialized from the request body. We expect the
         * client to send a serialized representation of a classrooms object, in
         * ...JSON format.
         * 
         * TODO: Explain [FromBody], the missing piece of the puzzle.
        */
        [HttpPost("[action]")]
        public JsonDataTransferObject PostClassrooms([FromBody]JsonDataTransferObject classroomObject)
        {
            // TODO: Remove comments and testing
            // TESTING: Trying to print the contents of the nested JSON object to
            // Application Output to confirm binding.
            //
            // JOSE: It should be clear from your testing below, that you have an
            // object because Web API deserialized. And serialization is the solution
            // in order to print the contents. But when you serialize, classrooms
            // (your JSON w/ the information) outputs to null. Why? This is what
            // you need to figure out.
            // I'm thinking the cause is connected to your model (your representation (JsonDataTransferObject.cs))
            // of the nested JSON object.
            //
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/serialization/
            // Serialization is the process of converting an object into a stream of
            // bytes to store the object or transmit it to memory. Main purpose
            // is to save the state of an object in order to be able to recreate
            // it when needed. Reverse process is called deserialization.
            // Through serialization, a developer can perform actions like sending
            // the object to a remote application by means of a Web Service...
            // https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization?view=netframework-4.7.2
            // Link contains the classes necessary for serializing and deserializing objects.

            // JOSE: This is basically what i have been trying to test. Success!
            // https://stackoverflow.com/questions/5166486/how-to-print-values-from-json-type-object-to-console-in-c-sharp
            // Output:
            // Loaded '/usr/local/share/dotnet/shared/Microsoft.NETCore.App/2.1.9/System.Runtime.Serialization.Primitives.dll'.Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
            // Loaded '/usr/local/share/dotnet/shared/Microsoft.NETCore.App/2.1.9/System.Diagnostics.TraceSource.dll'.Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
            // Loaded '/usr/local/share/dotnet/shared/Microsoft.NETCore.App/2.1.9/System.Data.Common.dll'.Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
            // Loaded '/usr/local/share/dotnet/shared/Microsoft.NETCore.App/2.1.9/System.Xml.ReaderWriter.dll'.Module was built without symbols.
            // { "Classrooms":null}
            Console.WriteLine();
            Console.WriteLine("TESTING SerializeObject (PathDataController.cs)----------------------------------------");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(classroomObject));
            Console.WriteLine();

            // JOSE: Web API deserializes from the request body meaning a stream of
            // bytes is converted into an object, as you can see by the output.
            // Output: shortestpathUARK.Models.JsonDataTransferObject
            /*Console.WriteLine("TESTING Web API (PathDataController.cs)----------------------------------------");
            Console.WriteLine(classroomObject);
            Console.WriteLine();

            // JOSE: This would throw an error. Trying to deserialize...when
            // deserialization has already occured.
            // Output: Exception thrown: 'Newtonsoft.Json.JsonReaderException' in Newtonsoft.Json.dll
            Console.WriteLine("TESTING DeserializeObject (PathDataController.cs)----------------------------------------");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.DeserializeObject<JsonDataTransferObject>(classroomObject.ToString()));
            Console.WriteLine();*/

            // JOSE: Seems like a long way of doing serialization like above...Printing
            // the same result...Yeah this is not necessary, but leave it for now.
            // Might be helpful in understanding the process.
            // https://stackoverflow.com/questions/38793151/deserialize-nested-json-into-c-sharp-objects
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(classroomObject);
            using (var sr = new StringReader(jsonString))
            using (var jr = new JsonTextReader(sr))
            {
                var serial = new JsonSerializer();
                serial.Formatting = Newtonsoft.Json.Formatting.Indented;
                var obj = serial.Deserialize<JsonDataTransferObject>(jr);

                var reserializedJSON = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);

                Console.WriteLine("Re-serialized JSON: ");
                Console.WriteLine(reserializedJSON);
            }

            // TESTING
            //classroomObject = repository.Add(classroomObject);

            return classroomObject;
        }

        /** 
         * TODO: Use this fancier method once you get the method above working.
         * If you can get it to work 'CreateResponse' causes error.        
         * 
         * Ideally we want the HTTP response to include the following:
         *         
         * Response code: By default, the Web API framework sets the response code
         * to 200 (OK). But according to the HTTP/1.1 protocol, when a POST request
         * results in the creation of a resource, the server should reply with
         * status 201 (Created).
         * 
         * Location: JOSE: Not necessary for now (or at all) in my opinion since
         * the Client is not getting anything from the server.       
        */
        /*
        [HttpPost("[action]")]
        public HttpResponseMessage PostClassrooms(Classrooms classroom)
        {
            classroom = repository.Add(classroom);
            var response = Request.CreateResponse<Classrooms>(HttpStatusCode.Created, classroom);
            return response;
        }*/
    }
}
