using P03_StudentSystem.Student;

namespace P03_StudentSystem
{
    class StartUp
    {
        static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();
            while (studentSystem.ParseCommand()) ;
        }
    }
}
