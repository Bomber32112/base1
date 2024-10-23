using System.Diagnostics;
using System.Drawing;
using System.Drawing.Interop;
using System.Reflection;
using System.Threading.Tasks.Dataflow;

namespace Parapa
{
    internal class Program
    {
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
