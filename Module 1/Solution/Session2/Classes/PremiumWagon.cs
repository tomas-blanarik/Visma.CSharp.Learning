using Session2.Enums;

namespace Session2.Classes
{
    public class PremiumWagon : RegularWagon
    {
        public PremiumWagon(int totalSeats) : base(totalSeats)
        { }

        public override WagonClassEnum WagonClass => WagonClassEnum.First;
    }
}
