using System;

namespace Session1
{
    class Program
    {
        // stack
        static void Main(string[] args)
        {
            new Train().Process();
            Console.ReadKey();
            //Console.WriteLine("Hello World!");

            //// abstraction
            //// encapsulation
            //// inheritance
            //// polymorphism - override, overloading

            //// object vs. class
            //Car car2;
            //Car car = new Car();

            //// struct
            //Train train = new Train();
            //string str = "Hello";

            //// heap memory
            //// stack memory

            //// copy by refernece - classes
            //// copy by value - struct, primitive types
            //ChangeTrainName(train);
            //ChangeString(str);

            //// immutable

            //// interface
            //Car lambo = new Car();
            //Truck truck = new Truck();

            //Process(lambo);
            //Process(truck);

            //IReadProcessor processor = new FileReadProcessor();
            //processor.Read();

            //var developer = new Developer();
            //developer.Seniority = (int)DeveloperSeniority.Architect;
            //DeveloperSeniority seniority = (DeveloperSeniority)developer.Seniority;

            //var strSeniority = "Junior";
            //DeveloperSeniority seniority2 = Enum.Parse<DeveloperSeniority>(strSeniority, true); // throw
            //DeveloperSeniority seniority3;
            //if (Enum.TryParse<DeveloperSeniority>(strSeniority, out seniority3))
            //{

            //}

            //// object Method(Type type)
            //// T Method<T>();

            //var logger = new Logger("CSharp");
            //logger.Log("Hello world");
            ////logger.Name = "Java";

            //int a = 15;
            //ProcessInteger(ref a);

            //float b = 15.0f;
            //object o = b;
            //a = (int)o;
        }

        public static void ProcessDateTime(ref DateTime date)
        {

        }

        public static void ProcessInteger(ref int a)
        {
            a = 10;
        }

        public static void Process(DeveloperSeniority seniority)
        {
            switch (seniority)
            {
                case DeveloperSeniority.Junior:
                    {
                        break;
                    }

                case DeveloperSeniority.Medior:
                    {
                        break;
                    }

                case DeveloperSeniority.Senior:
                    {
                        break;
                    }

                case DeveloperSeniority.Lead:
                    {
                        break;
                    }

                case DeveloperSeniority.Architect:
                    {
                        break;
                    }

                case DeveloperSeniority.CTO:
                    {
                        break;
                    }

                default:
                    {
                        break;
                    }
            }

            //
        }

        public static void Process(ICar car)
        {
            // direct-casting
            // safe-casting
            // as

            Car directCasting;
            try
            {
                directCasting = (Car)car; // runtime exception
            }
            catch (Exception e)
            {

            }


            Car safeCasting = car as Car; // null in case car is not type of Car
            if (safeCasting == null)
            {
            }

            if (car is Car car2)
            {
                car2.Lock();
            }
            else if (car is Truck truck2)
            {
                Truck truck = truck2;
                truck.LowerRamp();
            }
        }

        // stack
        public static void ChangeString(string str)
        {
            str = str.ToLower();
        }

        // stack
        public static void ChangeTrainName(Train train)
        {
            train.Model = "";
        }
    }

    public class MyClass
    {
        private string _name;
        private string _description;
        private string _version;

        private MyClass()
        {

            // singleton - one instance in the whole program
        }

        public MyClass(string name)
        {
            if (name == null)
            {
                // throw some exception
            }

            _name = name;
        }

        public MyClass(string name, string description) : this(name)
        {
            _description = description;
        }

        public MyClass(string name, string description, string version) : this(name, description)
        {
            _version = version;
        }
    }

    public class SomeLogger : Logger
    {
        private readonly Logger _logger;

        public SomeLogger(Logger logger) : base(null)
        {
            _logger = logger;
            _version = "1.0";
            Method();
        }

        public void MethodA()
        {
            _logger.Log("Hi");
        }
    }

    public class Logger
    {
        //private string _name;
        protected string _version;
        internal string _patch;
        protected internal string protectedResource;

        // const
        public const string DefaultLoggerName = "Logger";
        public static readonly string DefaultStaticLoggerName = "Logger";

        private readonly string _name;

        public Logger(string name)
        {
            _name = name;
            _version = "0.0";
        }

        protected void Method() { }

        public void Log(string text)
        {
            Console.WriteLine(_name + " - " + text);// CSharp - Hello world
        }

        private class LogStuff
        {

        }
    }

    public class Developer
    {
        public int Seniority { get; set; }
    }

    public class Car : ICar
    {
        public Car()
        { }

        public Car(string param)
        {
        }

        public string Vin;

        public string Model { get; set; }
        public string Name => string.Empty;

        public void Set(string model)
        {
            Model = model;
        }

        public string Get()
        {
            return Model;
        }

        // ...

        public void Lock() { }

        public void Ride()
        {

        }
    }

    public class Truck : ICar
    {
        public string Model { get; }

        public void Ride()
        {
        }

        public void LowerRamp() { }

        public void Ride(string a)
        {

        }
    }

    public class Train
    {
        public string Model;
        public string Vin;
        // ...

        public void Ride()
        {
        }

        public void Lock() { }
        private void A() { }
        protected void Method() { }
        internal void Internal() { }

        // method overloading
        public void Process()
        {
            // highest number in array
            int maxValue = int.MinValue;
            int minValue = int.MaxValue;

            // lowest number in array
            int[] array = new[] { 1, 50, 3, 70, 34, 22, 16, 99 }; // starts with index 0
            foreach (int number in array)
            {
                // find highest number
                if (number > maxValue)
                {
                    maxValue = number;
                }

                if (number < minValue)
                {
                    minValue = number;
                }
            }

            Console.WriteLine($"Max value: {maxValue}");
            Console.WriteLine($"Min value: {minValue}");

            for (int i = 0; i < array.Length; i++)
            {
                int number = array[i];
            }
        }
    }

    public interface ICar
    {
        // everything is public
        string Model { get; }
        void Ride() { }
        void Ride(string a) => Ride();
    }

    public class FileReadProcessor : IReadProcessor
    {
        // open file
        private void Open() { }
        // close file
        public void Close() { }
        // READ content
        // flush file
        public string Read()
        {
            Open();
            // read
            Close();
            return "";
        }
    }

    public class ConfigurationReadProcessor : IReadProcessor
    {
        // get config
        public object GetConfiguration() { return new object(); }

        // READ content
        public string Read()
        {
            object config = GetConfiguration();
            // do some logic with it
            // return
            return config as string;
        }
    }

    public interface IReadProcessor
    {
        public string Read();
    }

    public interface A
    {
        public string Method();
    }

    public interface B
    {
        public string Method();
    }

    public class Foo : A, B
    {
        public string Method()
        {
            throw new NotImplementedException();
        }
    }

    public enum DeveloperSeniority
    {
        Junior,
        Medior,
        Senior,
        Lead,
        Architect,
        CTO
    }


}
