using System;
using Session2.Abstractions;

namespace Session2.Classes
{
    public partial class Train
    {
        public int GetFreeSeats(IWagon wagon)
        {
            if (_wagons.Contains(wagon))
            {
                return wagon.FreeSeats;
            }
            else
            {
                throw new ArgumentException("Wagon is not present behind the train");
            }
        }

        public void ReserveSeat(IWagon wagon, int seat)
        {
            if (_wagons.Contains(wagon))
            {
                wagon.ReserveSeat(seat);
            }
            else
            {
                throw new ArgumentException("Wagon is not present behind the train");
            }
        }

        public void ReserveSeats(IWagon wagon, params int[] seats)
        {
            if (_wagons.Contains(wagon))
            {
                wagon.ReserveSeats(seats);
            }
            else
            {
                throw new ArgumentException("Wagon is not present behind the train");
            }
        }
    }
}
