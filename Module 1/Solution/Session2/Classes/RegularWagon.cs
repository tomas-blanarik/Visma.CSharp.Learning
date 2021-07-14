using System;
using System.Collections.Generic;
using System.Linq;
using Session2.Abstractions;
using Session2.Enums;

namespace Session2.Classes
{
    public class RegularWagon : AbstractWagon, IWagon
    {
        // true - occupied
        // false - free
        // 1 - false
        // 2 - false
        private readonly Dictionary<int, bool> _seats;

        public virtual int FreeSeats => _seats.Count(x => !x.Value);

        public virtual int TotalSeats { get; }

        public virtual WagonClassEnum WagonClass => WagonClassEnum.Second;

        protected RegularWagon()
        { }

        public RegularWagon(int totalSeats)
        {
            TotalSeats = totalSeats;
            _seats = new Dictionary<int, bool>(totalSeats);
            for (int i = 1; i <= TotalSeats; i++)
            {
                _seats.Add(i, false);
            }
        }

        // 10 seats
        // 1 - 10
        public virtual void ReserveSeat(int seat)
        {
            if (seat < 1 || seat > TotalSeats)
            {
                throw new ArgumentException($"Seat id should be within 1 and {TotalSeats}");
            }

            if (_seats.ContainsKey(seat) && _seats[seat])
            {
                throw new ArgumentException($"Seat {seat} is already taken");
            }

            // seat at position seat is set to true - reserved
            _seats[seat] = true;
        }

        public virtual void ReserveSeats(params int[] seats)
        {
            if (seats == null || seats.Length == 0)
            {
                throw new ArgumentNullException(nameof(seats));
            }

            List<Exception> errors = new List<Exception>();
            foreach (int seat in seats)
            {
                try
                {
                    ReserveSeat(seat);
                }
                catch (Exception e)
                {
                    errors.Add(e);
                }
            }

            if (errors.Count > 0)
            {
                throw new AggregateException(errors);
            }
        }

        public int CompareTo(IWagon other)
        {
            if (other == null)
            {
                return 1;
            }

            if (WagonClass < other.WagonClass)
            {
                return -1;
            }
            else if (WagonClass > other.WagonClass)
            {
                return 1;
            }

            return 0;
        }

        public override int GetHashCode()
        {
            return WagonClass.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return ((RegularWagon)obj).Id == Id;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Wagon id: {Id}");
            Console.WriteLine($"Free seats: {FreeSeats}, Total seats: {TotalSeats}");
            Console.WriteLine("----------------------------------------------------");
        }
    }
}
