namespace Session2.Abstractions
{
    public interface IWagon : IAbstractWagon
    {
        public int FreeSeats { get; }
        public int TotalSeats { get; }
        public void ReserveSeat(int seat);
        public void ReserveSeats(params int[] spaces);
    }
}
