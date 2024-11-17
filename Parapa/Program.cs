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
            byte[] newPlayer = new byte[20];
            newPlayer = Encoding.UTF8.GetBytes(game.FirstPlayer.Name);
            newPlayer[16] = game.FirstPlayer.MaxHP;
            newPlayer[17] = game.FirstPlayer.CurrentHP;
            newPlayer[18] = game.FirstPlayer.DamagePower;
            newPlayer[19] = game.FirstPlayer.HealPower;
            //byte size = (byte)newPlayer.Length;
            //Array.Resize(ref newPlayer, size+3);
            //newPlayer[size] = game.FirstPlayer.CurrentHP;
            //newPlayer[size+1] = game.FirstPlayer.DamagePower;
            //newPlayer[size+2] = game.FirstPlayer.HealPower;
            return newPlayer; // Структура: первые 16..н байтов - ник игрока, следующий байт - хп игрока на данный момент, следующий - сила урона, следующий - сила хила
        }
        internal Character FirstPlayer { get; set; }
        internal Character SecondPlayer { get; set; }








        static void UDP_server()
        {
            int port = 1234;
            Socket serv = new Socket(SocketType.Dgram, ProtocolType.Udp);
            EndPoint EndPoint1 = new IPEndPoint(IPAddress.Any, port);
            EndPoint EndPoint2 = new IPEndPoint(IPAddress.Any, port);
            serv.Bind(EndPoint1);
            byte[] dataForClient = new byte[1000];
            byte[] data = new byte[1000];
            byte[] player1Data = new byte[19];
            byte[] player2Data = new byte[19];

            List<(IPAddress Ip, int port)> ls = new List<(IPAddress Ip, int port)>(2);

            while(true) 
            {
                EndPoint IP = new IPEndPoint(IPAddress.Any, port);
                serv.ReceiveFrom(player1Data, ref IP);
                IPEndPoint IPINFO = (IPEndPoint)IP;


                for (int i = 0; i < ls.Count; i++)
                    if (ls[i].Ip.Equals(IPINFO.Address) && ls[i].port == IPINFO.Port) { goto end; }
                ls.Add((IPINFO.Address, IPINFO.Port));
            end:;
                ls.ForEach(x => Console.WriteLine(x.ToString()));
                if (ls.Count == 2) break;
            }

            EndPoint1 = new IPEndPoint(ls[0].Ip, ls[0].port);
            EndPoint2 = new IPEndPoint(ls[1].Ip, ls[1].port);
           
            Console.WriteLine($"test123456{((IPEndPoint)EndPoint1)} {((IPEndPoint)EndPoint2)}");
            bool forThread = false;
            Thread tread = new Thread(()=>{ while (true) { serv.SendTo(Encoding.UTF8.GetBytes("Ожидание первого игрока"), EndPoint2); Thread.Sleep(1500); if (forThread) break; }});
            tread.Start();
            while (true)
            {
                anotherOne:
                try
                { serv.ReceiveFrom(player1Data, ref EndPoint1); }
                catch { goto anotherOne;}
                if (((IPEndPoint)EndPoint1).ToString() == new IPEndPoint(ls[0].Ip, ls[0].port).ToString())
                    break;
            }
            forThread = true;
            serv.SendTo(Encoding.UTF8.GetBytes("Ожидание первого игрока закончено"), EndPoint2);

            while (true)
            {
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
            byte[] data = new byte[1];
            byte[] playerData = new byte[19];
            byte[] servData = new byte[1000];
            byte[] correctedSD = new byte[0];//zalupa
            s.SendTo(data, EndPoint);
            goto test;
            while (true)
            {
                
                data = Encoding.UTF8.GetBytes(Console.ReadLine());
                s.SendTo(data, EndPoint);
                if (s.Available != 0)
                {
                    break;
                }
            }
            test:
            s.ReceiveFrom(servData, ref EndPoint);
            bool firstOrNot = false;
            if (servData[0] == 1) firstOrNot = true;
            while (true)
            {
                if (s.Available != 0)
                {
                    Array.Resize(ref servData, s.Available);
                    int recvsize = s.ReceiveFrom(servData, ref EndPoint);
                    

                    Console.WriteLine(Encoding.UTF8.GetString(servData));
                }
            }

            }
    }
}

