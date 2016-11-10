using System;
using System.Reflection;

namespace DynamicAssemblyReffence
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFile(Environment.CurrentDirectory + @"\ClassController.dll");
            Type type = assembly.GetType("ClassController.Controller");
            object instance = assembly.CreateInstance("ClassController.Controller");

            MethodInfo method = type.GetMethod("GetStudentName");
            var result = method.Invoke(instance, null);

            Console.WriteLine(result);
            Console.Read();
        }
    }
}
