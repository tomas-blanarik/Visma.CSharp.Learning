using System;
using Session2.Enums;

namespace Session2.Classes
{
    public class RestaurantWagon : RegularWagon
    {
        public override int FreeSeats => 0;

        public override int TotalSeats => 0;

        public override WagonClassEnum WagonClass => WagonClassEnum.Third;

        public override void ReserveSeat(int seat)
        {
            throw new Exception("This wagon doesn't support reserving seats");
        }

        public override void ReserveSeats(params int[] seats)
        {
            throw new Exception("This wagon doesn't support reserving seats");
        }
    }
}
