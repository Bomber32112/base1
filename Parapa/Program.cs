using System.Diagnostics;
using System.Drawing;
using System.Drawing.Interop;
using System.Net.Sockets;
using System.Net;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks.Dataflow;
using System.ComponentModel.Design;
using System.Text.Json.Nodes;
using System.Security.Cryptography.X509Certificates;

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
            /*
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
            */
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
namespace SimpleGame
{
    internal class Character
    {
        public void Info()
        {
            Console.WriteLine($"Имя: {Name}\n Текущее здоровье:{CurrentHP}\n Текущая сила лечения:{HealPower}\n Текущая сила урона:{DamagePower}");
        }
        internal string Name { get; set; }
        internal byte MaxHP { get; set; }
        internal byte CurrentHP { get; set; }
        internal byte HealPower { get; set; }
        internal byte DamagePower { get; set; }
    }
    internal class Game
    {
        public static void Main(string[] args)
        {
            start:
            Console.WriteLine("Cli or Serv");
            string input = Console.ReadLine();
            if (input == "Serv")
            {
                Thread thread = new Thread(UDP_server);
                thread.Start();
            }
            else if (input == "Cli")
            {
                Thread thread1 = new Thread(UDP_client);
                thread1.Start();
            }
            else
            {
                Console.WriteLine("Invalid");
                goto start;
            }
        }
        public byte[] CreatePlayesrs() 
        {
            Random random = new Random();
            Game game = new Game();
            backToNick:
            Console.WriteLine("Введите ник игрока не больше 16-ти символов: ");
            game.FirstPlayer.Name = Console.ReadLine();
            if (game.FirstPlayer.Name.Length > 16) goto backToNick;
            game.FirstPlayer.CurrentHP = game.FirstPlayer.MaxHP = 20;
            game.FirstPlayer.DamagePower = (byte)random.Next(3, 6);
            game.FirstPlayer.HealPower = (byte)random.Next(1, 4);
            byte[] newPlayer;
            newPlayer = Encoding.UTF8.GetBytes(game.FirstPlayer.Name);
            byte size = (byte)newPlayer.Length;
            Array.Resize(ref newPlayer, size+3);
            newPlayer[size] = game.FirstPlayer.CurrentHP;
            newPlayer[size+1] = game.FirstPlayer.DamagePower;
            newPlayer[size+2] = game.FirstPlayer.HealPower;
            return newPlayer;
        }
        internal Character FirstPlayer { get; set; }
        internal Character SecondPlayer { get; set; }








        static void UDP_server()
        {
            int port = 1234;
            Socket serv = new Socket(SocketType.Dgram, ProtocolType.Udp);
            EndPoint EndPoint1 = new IPEndPoint(IPAddress.Any, port);
            serv.Bind(EndPoint1);
            byte[] dataForClient = new byte[1000];
            byte[] data = new byte[1000];
            byte[] player1Data = new byte[19];
            byte[] player2Data = new byte[19];

            List<(IPAddress Ip, int port)> ls = new List<(IPAddress Ip, int port)>(2);
            List<IPEndPoint> ends = new List<IPEndPoint>();
            while (ends.Count < 2) 
            {
                serv.ReceiveFrom(player1Data, ref EndPoint1);
                if (ends.FirstOrDefault(s => s.Port == ((IPEndPoint)EndPoint1).Port) == null)
                {
                    IPEndPoint IPINFO = (IPEndPoint)EndPoint1;
                    ends.Add(IPINFO);
                }
                /*
                for (int i = 0; i < ls.Count; i++)
                    if (ls[i].Ip == IPINFO.Address && ls[i].port == IPINFO.Port) { goto end; }
                ls.Add((IPINFO.Address, IPINFO.Port));
                end:;

                if (ls.Count == 2) break;*/
            }
            /*
            EndPoint1 = new IPEndPoint(ls[0].Ip, ls[0].port);
            EndPoint EndPoint2 = new IPEndPoint(ls[1].Ip, ls[1].port);
            */
            //
            //EndPoint EndPoint3 = new IPEndPoint(IPAddress.Any, port);
            //while (((IPEndPoint)EndPoint3).Address.Address != EndPoint1IP.Address.Address)
            //{
            //    serv.SendTo(Encoding.UTF8.GetBytes("Ожидание первого игрока"), EndPoint2IP);
            //    serv.ReceiveFrom(player1Data, ref EndPoint1);
            //}
            //serv.SendTo(Encoding.UTF8.GetBytes("Ожидание первого игрока закончено"), EndPoint2IP);
            //while (((IPEndPoint)EndPoint3).Address.Address != EndPoint2IP.Address.Address)
            //{
            //    serv.SendTo(Encoding.UTF8.GetBytes("Ожидание второго игрока"), EndPoint1IP);
            //    serv.ReceiveFrom(player1Data, ref EndPoint1);
            //}
            //serv.SendTo($"Ожидание второго игрока закончено", EndPoint1IP);
            IPEndPoint EndPoint1IP = ends[0];
            IPEndPoint EndPoint2IP = ends[1];
            serv.SendTo(Encoding.UTF8.GetBytes("Ожидание данных от первого игрока"), EndPoint1IP);
            serv.ReceiveFrom(player1Data, ref EndPoint1);
            serv.SendTo(Encoding.UTF8.GetBytes("Ожидание данных от второго игрока"), EndPoint2IP);
            serv.ReceiveFrom(player2Data, ref EndPoint1);


            Console.WriteLine("все игроки в сборе");
            while (true)
            {
                GC.Collect();
                if (serv.ReceiveFrom(data,ref EndPoint1) > 0) {
                    dataForClient = Encoding.UTF8.GetBytes("52");
                    IPEndPoint IPINFO = (IPEndPoint)EndPoint1;
                    serv.SendTo(dataForClient, IPINFO);
                    Console.WriteLine($"by comp 3: {Encoding.UTF8.GetString(data)} info= {IPINFO.Address} {IPINFO.Port}"); 
                    Array.Fill<byte>(data, 0); 
                }
            }

        }

        static void UDP_client()
        {
            int port = 1234;
            Console.WriteLine("Введите IP-адресс");
            IPAddress IP = IPAddress.Parse($"{Console.ReadLine()}");
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //s.Connect(IP, port);
            EndPoint EndPoint = new IPEndPoint(IP, port);
            byte[] data;
            byte[] servData = new byte[1000];
            while (true)
            {
                
                data = Encoding.UTF8.GetBytes(Console.ReadLine());
                s.SendTo(data, EndPoint);
                if (s.Available != 0)
                {
                    s.ReceiveFrom(servData, ref EndPoint);
                    Console.WriteLine(Encoding.UTF8.GetString(servData));
                }
            }

        }
    }
}

