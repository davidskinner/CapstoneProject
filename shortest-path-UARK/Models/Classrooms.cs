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

    public interface IClassroomsRepository
    {
        Classrooms Add(Classrooms classroom);
    }

    public class ClassroomsRepository : IClassroomsRepository
    {
        private List<Classrooms> classrooms = new List<Classrooms>();

        public Classrooms Add(Classrooms classroom)
        {
            if (classroom == null)
            {
                throw new ArgumentNullException("classroom");
            }

            classrooms.Add(classroom);

            // TESTING
            Console.WriteLine("TESTINGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG");
            foreach (var item in classrooms)
            {
                Console.WriteLine(item);
            }

            return classroom;
        }
    }
}
