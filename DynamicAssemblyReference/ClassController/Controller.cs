using DynamicAssemblyReference;

namespace ClassController
{
    public class Controller
    {
        public string GetStudentName()
        {
            Student student = new Student()
            {
                Name = "Tom",
                Age = 5
            };
            return student.Name;
        }
    }
}
