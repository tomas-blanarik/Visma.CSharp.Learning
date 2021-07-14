using System.Collections.Generic;
using System.Linq;
using Session2.Abstractions;

namespace Session2.Classes
{
    public partial class Train
    {
        private const int _maxWagonsCount = 10;
        private readonly List<IWagon> _wagons;

        public int TotalSeats => _wagons.Sum(wagon => wagon.TotalSeats);
    }
}
