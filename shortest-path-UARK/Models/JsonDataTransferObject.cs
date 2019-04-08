using System;
using System.Collections.Generic;
using shortestpathUARK.Models;

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
        //JsonDataTransferObject Add(JsonDataTransferObject classroom);
    }

    /** 
     * TODO: Implement the necessary methods. This method is more or less a template
     * for other methods.    
    */
    public class JsonDataTransferObjectRepository : IJsonDataTransferObjectRepository
    {
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
