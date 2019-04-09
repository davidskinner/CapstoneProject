using System;
using System.Collections.Generic;
using shortestpathUARK.Models;

/** 
 * C# is strongly typed, so we need to create a model. A model is an object
 * that represents the data in your application.
*/
namespace shortestpathUARK.Models
{
    public class JsonDataTransferObject
    {
        // JOSE: It's possible a different definition is needed (e.g. List)
        public Classrooms[] classrooms { get; set; }
    }

    /** TODO: Define necessary methods. */
    public interface IJsonDataTransferObjectRepository
    {
        // TESTING
        JsonDataTransferObject Add(JsonDataTransferObject classroom);
    }

    public class JsonDataTransferObjectRepository : IJsonDataTransferObjectRepository
    {
        /** 
        * TODO: Implement the necessary methods. This method is more or less a template
        * for other methods.    
        */
        private List<JsonDataTransferObject> classroomsList = new List<JsonDataTransferObject>();

        public JsonDataTransferObject Add(JsonDataTransferObject classroom)
        {
            if (classroom == null)
            {
                throw new ArgumentNullException("classroom");
            }

            classroomsList.Add(classroom);

            return classroom;
        }
    }
}
