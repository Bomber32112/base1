using System.Diagnostics;
using System.Drawing;
using System.Drawing.Interop;
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
            Job[] job = new Job[  2];
            employees.jobs = job;
            
        }



    }        
        class Job
        {
            public string? Name { get; set; }
        }
        struct Employees
        {
            public Job[] jobs;
            public string name;
            public string surname;
            public string patronymic;
            public int passport;
            public long phoneNumber; 

            public Employees(string n, string s, string pat, int pass, int phone) // j - job, n - name, s - surname, pat - patronymic, 
            {
                this.name = n; this.surname = s;
                this.patronymic = pat; this.passport = pass; 
                this.phoneNumber = phone;
            }
        }
        struct Customer
        {
            public string name;
            public string surname;
            public TimeOnly reservationTime;
            public long phoneNumber;
            public Customer(string n, string s, long phone, TimeOnly res)
            {
                this.name = n; this.surname = s; this.phoneNumber = phone;
                this.reservationTime = res;
            }
        }
        struct Table 
        {
            public int number; public TimeOnly c;
            public Table(int number, TimeOnly c) 
            {
                this.number = number; this.c = c;
            }
        }
        struct Address
        {
            public string name;
            public int number;
            public Address(string name, int number) { this.name = name; this.number = number; }
        }
}
