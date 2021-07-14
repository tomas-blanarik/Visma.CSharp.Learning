using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Session3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /*
             Collections in C#
                - lists, arrays, linked list
                - dictionary
                - hash-set
                - queue, stack
                - introduction to generics
                generic programming
            */

            // non-generic
            // generic

            List<string> list = new();
            IEnumerable<string> enumerable = Array.Empty<string>();
            HashSet<string> collection = new HashSet<string>();
            IList<string> iList = new List<string>();

            List<Regex> regexList = enumerable
                .Where(x => x.Contains("*"))
                .Select(x => new Regex(x))
                .ToList();

            Dictionary<int, Dictionary<string, int>> peoplesDictionary = new();

            list.Add("hey");
            list.Add("hey");

            collection.Add("hey");
            collection.Add("hey");

            Queue<int> queue;
            Stack<int> stack;

            var repository = new Repository<Person>();
            var repository2 = new Repository<Person, int>();

            var person = new Person();
            Male male = person.Convert<Male>();
        }
    }

    public interface IDomain
    {
        public int Id { get; set; }
    }

    public class Male : IDomain
    {
        public int Id { get; set; }
    }

    public class Person : IDomain
    {
        public Person()
        {

        }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public T Convert<T>() where T : IDomain, new()
        {
            T returnObject = new T();
            returnObject.Id = Id;
            return returnObject;
        }
    }

    public class Repository<T, K> : Repository<T> where T : class, IDomain, new()
    {
        public K Key { get; set; }
    }

    public class Repository<T> where T : class, IDomain, new()
    {
        public T Create(T entity)
        {
            T newEntity = new T();
            return entity;
        }

        public T Read(int key) { return default; }

        public T Update(T entity) { return entity; }

        public void Delete(T entity) { }
    }
}
