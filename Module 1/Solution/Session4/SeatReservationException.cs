using System;

namespace Session4
{
    public class SeatReservationException : Exception
    {
        public const string DefaultMessageFormat = "Seat {0} cannot be reserved";

        public SeatReservationException(int seat)
            : base(string.Format(DefaultMessageFormat, seat))
        { }

        public SeatReservationException(int seat, Exception innerException)
            : base(string.Format(DefaultMessageFormat, seat), innerException)
        { }

        //public override string Message => string.Format(DefaultMessageFormat, _seat);
    }
}
