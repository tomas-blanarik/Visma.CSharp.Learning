using System;
using System.Linq;
using Session2.Abstractions;

namespace Session2.Classes
{
    public sealed partial class Train : ITrain
    {
        public Train(params IWagon[] wagons)
        {
            if (wagons == null || wagons.Length == 0)
            {
                throw new ArgumentNullException(nameof(wagons));
            }

            if (wagons.Length > _maxWagonsCount)
            {
                throw new ArgumentException($"Maximum number of wagons behind the train is {_maxWagonsCount}");
            }

            _wagons = wagons.ToList();
            _wagons.Sort();
        }

        internal void PrintWagons()
        {
            Console.WriteLine("Hello from locomotive!");
            int index = 1;
            foreach (IWagon wagon in _wagons)
            {
                Console.WriteLine($"{index}. wagon - {wagon.GetType().Name}");
                Console.WriteLine($"Free seats: {wagon.FreeSeats}, Total seats: {wagon.TotalSeats}");
                Console.WriteLine("----------------------------------------------------------------");
                ++index;
            }
        }
    }
}
