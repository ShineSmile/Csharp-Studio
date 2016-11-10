using DynamicAssemblyReffence;

namespace ClassController
{
    public class Controller
    {
        Student student = new Student()
        {
            Name = "Tom",
            Age = 5
        };

        public string GetStudentName()
        {
            return student.Name;
        }
    }
}
