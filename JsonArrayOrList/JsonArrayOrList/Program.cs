using System;
using System.Collections.Generic;
using static JsonArrayOrList.SerializationUtil;

namespace JsonArrayOrList
{
    static class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student()
            {
                Name = "Jim",
                Age = 233
            };
            Student s2 = new Student()
            {
                Name = "Tom",
                Age = 666,
            };
            Student s3 = new Student()
            {
                Name = "Kate",
                Age = 123
            };
            List<Student> studentList = new List<Student> { s1, s2, s3 };
            Student[] studentArray = new Student[] { s1, s2, s3 };
            Console.WriteLine("Student List:  \n{0}\n", Serialize(studentList));
            Console.WriteLine("Student Array: \n{0}\n", Serialize(studentArray));
            Console.Read();
        }
    }
}
