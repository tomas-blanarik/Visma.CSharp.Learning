using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Session6.Attributes;

namespace Session6
{
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            //Reflection();
            //Linq();
            Attributes();

            Console.ReadKey();
        }

        public static void Reflection()
        {
            Console.WriteLine("######### Reflection #########");
            Console.WriteLine();

            //Type type = typeof(int);

            Class a = new Class { Msg = "Hello" };
            Type aType = a.GetType();

            PropertyInfo msgProperty = aType.GetProperty(nameof(Class.Msg));
            string obj = msgProperty.GetValue(a) as string;
            Console.WriteLine(obj);

            Assembly current = Assembly.GetExecutingAssembly();
            Type[] types = current.GetTypes();
            foreach (Type type in types)
            {
                if (type == typeof(IDependency))
                {

                }
            }
        }

        public interface IDependency
        {

        }

        public interface ITransient
        {

        }

        public static void Process(object obj)
        {
            Type type = typeof(IDisposable);

            if (obj.GetType() == typeof(string))
            {

            }
        }

        public static void Linq()
        {
            Console.WriteLine("######### Linq #########");
            Console.WriteLine();

            int[] scores = new int[] { 65, 75, 68, 95 };

            // select every score above 70
            IEnumerable<int> query =
                from score in scores
                where score > 70
                orderby score
                select score;

            IEnumerable<int> query2 = scores.Where(score => score > 70).ToList();

            List<int> scoresAbove = new List<int>();
            foreach (int score in scores)
            {
                if (score > 70)
                {
                    scoresAbove.Add(score);
                }
            }
        }

        public static void Attributes()
        {
            Console.WriteLine("######### Attributes #########");
            Console.WriteLine();

            FirstClass first = new FirstClass();
            Assembly assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(AuthorAttribute))).ToList();
            foreach (var type in types)
            {
                var attrs = type.GetCustomAttributes<AuthorAttribute>().ToList();
                attrs.ForEach(x => Console.WriteLine(x.Name));
            }
        }
    }
}
