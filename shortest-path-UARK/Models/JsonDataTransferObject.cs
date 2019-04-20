using System;
using System.Collections.Generic;

/** 
 * C# is strongly typed, so we need to create a model. A model is an object
 * that represents the data in your application.
*/
namespace shortestpathUARK.Models
{
    public class JsonDataTransferObject
    {
        public Classrooms[] classrooms { get; set; }
    }

    /** 
     * TODO: Define necessary methods. */
    public interface IJsonDataTransferObjectRepository
    {
        //...
    }

    public class JsonDataTransferObjectRepository : IJsonDataTransferObjectRepository
    {
        /** 
        * TODO: Implement the necessary methods.
        * ...
        */
    }
}
