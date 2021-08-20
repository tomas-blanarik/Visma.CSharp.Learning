using System;

namespace Session5
{
    public class Program
    {
        //public delegate void Print(string msg);

        public Action BeforeSend { get; set; }
        public Action<string> AfterSend { get; set; }

        public Func<int, string> TransformFunction = x => x.ToString();

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /*
             namespaces
             using pattern
             IDisposable
             working with Streams
             extension methods
             anonymous methods and objects
             design patterns #1 - singleton
            */

            // I/O
            // MemoryStream buffer = File.ReadAsync // bytes
            // Close the stream

            //using StreamReader reader = File.OpenText(@"TextFile1.txt");
            //string line = string.Empty;
            //while ((line = reader.ReadLine()) != null) // FiraCode
            //{
            //    Console.WriteLine(line);
            //}

            //string email = "tomas.blanarik@gmail.com";

            //if (StringHelper.IsEmailAddress(email))
            //{

            //}

            //if (email.IsEmailAddress())
            //{

            //}

            //Print print = PrintToConsole;
            //Print print2 = new Print(PrintToConsole);
            //Print print3 = msg => PrintToConsole(msg);

            //print.Invoke("Hello World");
            //print2.Invoke("Hello World");
            //print3("Hello World");

            //Print console = delegate (string msg)
            //{
            //    Console.WriteLine(msg);
            //};

            //console("Hello world");

            // Singleton - instance of the class exists only once in the program life-cycle

            //Action<string> action = msg =>
            //{
            //    Console.WriteLine(msg);
            //    Console.WriteLine();
            //};

            //Func<string, string> func = (str) => str + " Hello world";
            //Func<int, double, string> process = (i, d) => $"{i} + {d}";

            //action("Hello world");

            //string result = func("Tomas is saying");

            //Configure(options =>
            //{
            //    //options.Host = "localhost";
            //});

            Singleton.Instance.Print("Hello World");

            // work with stream
            Console.ReadKey();
        }

        public static void Configure(Action<object> configureOptions)
        {
            configureOptions.Invoke(new object());
            // continue
        }

        public static void PrintToConsole(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void PrintToFile(string msg)
        {

        }
    }
}
