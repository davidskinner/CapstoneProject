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
        /** 
         * Provide the IJsonDataTransferObjectRepository as a constructor parameter
         * using constructor injection (i.e. dependency injection).
         * TODO: We might need the Web API Dependency Resolver.        
        */
        private readonly IJsonDataTransferObjectRepository _repository;

        public PathDataController(IJsonDataTransferObjectRepository repository)
        {
            _repository = repository;
        }

        /** 
         * TESTING...      
         * ..."not the best design"...better approach see the link.
         * https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/dependency-injection 
        */
        //static readonly IJsonDataTransferObjectRepository repository = new JsonDataTransferObjectRepository();

        /** 
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
         * [FromBody]- To force Web API to read a simple type from the request body.
         * Web API will use a media-type formatter to read the value from the request body.
         * When a parameter has [FromBody], Web API uses the Content-Type (e.g. "application/json")
         * header to select a formatter.
         * 
         * https://docs.microsoft.com/en-us/aspnet/web-api/overview/older-versions/creating-a-web-api-that-supports-crud-operations
         * Create a resource. The client sends an HTTP POST request.
         * The method takes a parameter of type...In Web API, parameters
         * w/ complex types are deserialized from the request body. We expect the
         * client to send a serialized representation of a classrooms object, in
         * ...JSON format.
         * 
         * Ideally we want the HTTP response to include the following:
         * Response code: By default, the Web API framework sets the response code
         * to 200 (OK). But according to the HTTP/1.1 protocol, when a POST request
         * results in the creation of a resource, the server should reply with
         * status 201 (Created).
         * Location: When the server creates a resource, it should include the URI
         * of the new resource in the Location header of the response.        
         * 
         * JOSE: Microsoft documentation seems to be outdated. Syntax described is
         * incorrect, therefore ignore the sample method.    
         * 
         * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/serialization/
         * Serialization is the process of converting an object into a stream of
         * bytes to store the object or transmit it to memory. Main purpose
         * is to save the state of an object in order to be able to recreate
         * it when needed. Reverse process is called deserialization.
         * Through serialization, a developer can perform actions like sending
         * the object to a remote application by means of a Web Service...
         * 
         * JOSE: Web API deserializes (i.e. stream of bytes is converted into an object)
         * the parameter from the request body. Hence, we serialize (i.e. convert an
         * object into a stream of bytes).        
         * 
         * TODO: Implement method and add proper HTTP response.
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

            // TESTING
            //classroomObject = _repository.Add(classroomObject);

            return classroomObject;
        }
    }
}
