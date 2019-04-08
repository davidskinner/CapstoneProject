using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace shortestpathUARK.Models
{
    /** 
     * C# is strongly typed, so we need to create a model. A model is an object
     * that represents the data in your application.
    */
    public class Classrooms
    {
        /** 
         * Properties of Classrooms model.      
        */
        public string className { get; set; }
        public string buildingName { get; set; }
        public string classTime { get; set; }
    }
}
