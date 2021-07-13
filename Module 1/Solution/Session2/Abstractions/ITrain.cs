namespace Session2.Abstractions
{
    public interface ITrain
    {
        public void ReserveSeat(IWagon wagon, int seat);
        public void ReserveSeats(IWagon wagon, params int[] seats);
        public int GetFreeSeats(IWagon wagon);
        public int TotalSeats { get; }
    }
}
