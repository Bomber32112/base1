using System.Diagnostics;
using System.Drawing;
using System.Drawing.Interop;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks.Dataflow;

namespace Parapa
{
    internal class Program
    {
        /*
        static void Main(string[] args)
        {
            //Graphics graphics = Graphics.FromHwnd(Process.GetCurrentProcess().MainWindowHandle);
            //Pen pen = new Pen(Color.Green, 2);
            //    while (true)
            //    {
            //        graphics.DrawLine(pen, 156, 100, 546, 546);
            //    }
            Console.WriteLine();
            Employees employees = new Employees();
            Job job = new Job();
            employees.jobs = job;
            Customer customer = new Customer();
            Table table = new Table();
            Address address = new Address();
            var program = new Program();
            //var method = program.GetType().GetMethod(Console.ReadLine());
            //method.Invoke(program, null);
            job.Name = "dsa";
            Console.WriteLine(employees.jobs.Name);
            Job[] jobs = new Job[2];
            employees.name = "sda";
            employees.surname = "asd";
            employees.patronymic = "dsa";
            for (int i = 0; i < 2; i++)
            {
                jobs[i] = new Job();
                jobs[i].Name = "job";
            }
            employees.jobs = jobs[0];
            Console.WriteLine(employees.jobs.Name);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine(assembly.GetManifestResourceStream("Program"));
            
        }
        */
        static void StartBuild() 
        {
            Console.WriteLine("Список комманд - help");
        }
        static void Help() 
        {
            Console.WriteLine("");
        }


    }        
     class Job
     {
        public int indexOfJob { get; set; }
        public string? Name { get; set; }
     }
     class Employees
     {
         public Job jobs { get; set; }
         public string name { get; set; }
         public string surname { get; set; }
         public string patronymic { get; set; }
         public int passport { get; set; }
         public long phoneNumber { get; set; }
     }
     class Customer
     {
         public string name { get; set; }
         public string surname { get; set; }
         public TimeOnly reservationTime { get; set; }
         public long phoneNumber { get; set; }
     }
     class Table 
     {
         public int number { get; set; }
         public TimeOnly reservationTime { get; set; }
     }
     class Address
     {
        public string street { get; set; }
        public int number { get; set; }
    }
}
namespace Testing
{
    public class Student 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronimic { get; set; }
        public DateTime Birth { get; set; }
        public Group Group { get; set; }
    }

    public class Group
    {
        public int Number { get; set; }
        public Special Special { get; set; }
    }

    public class Special
    {
        public string Title { get; set; }
    }
    public static class Model 
    {
        public static Special Spec(string title) 
        { 
            Special special = new Special();
            special.Title = title;
            return special; 
        }
        public static Group Group(int number, Special special) 
        {
            Group group = new Group();
            group.Number = number;
            group.Special = special;
            return group;
        }
        public static Student Student(string FirstName, string LastName, string Patronimic, DateTime Birth, Group Group) 
        {
            Student student = new Student();
            student.FirstName = FirstName;
            student.LastName = LastName;
            student.Patronimic = Patronimic;
            student.Birth = Birth;
            student.Group = Group;
            return student;
        }
        public static void Main(string[] args) 
        {
            var t = Assembly.GetExecutingAssembly().GetType("Testing.Student");
            var student = (Student)Activator.CreateInstance(t);
            var pInfo = t.GetProperty("FirstName");
            pInfo.SetValue(student, "new name");
            var str = pInfo.GetValue(student).ToString();
            Console.WriteLine(str);
            int.TryParse(Console.ReadLine(), out int number);
            Student[] students = new Student[number];
            for (int i = 0; i < students.Length; i++) 
            {
                Console.WriteLine("Введите имя студента ");
                string FirstName = Console.ReadLine();
                Console.WriteLine("Введите фамилию студента ");
                string LastName = Console.ReadLine();
                Console.WriteLine("Введите отчество студента ");
                string Patronimic = Console.ReadLine();
                Console.WriteLine("Введите дату рождения студента ");
                DateTime.TryParse(Console.ReadLine(), out DateTime date);
                Console.WriteLine("Введите номер группы студента ");
                int.TryParse(Console.ReadLine(), out int groupNum);
                Console.WriteLine("Введите название специальности, на которой учится студент ");
                students[i] = Student(FirstName, LastName, Patronimic, date, Group(number, Spec(Console.ReadLine())));

            }
            Student student1 = Student("Гордон", "Фримен", "Фрименович", DateTime.Now, Group(123, Spec("Атомная инжинерия")));
            Student student2 = Student("Гордон", "Фримен", "Фрименович", DateTime.Now, Group(123, Spec("Атомная инжинерия")));


        }
    }
        public enum Commands 
        {
            FirstName,
            LastName,
            Patronimic,
            Birth,
            GroupNum,
            SpecTitle

        }
}
