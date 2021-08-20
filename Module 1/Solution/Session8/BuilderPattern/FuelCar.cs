namespace Session8.BuilderPattern
{
    public class FuelCar : Car
    {
        public string TypeOfFuel { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"- {TypeOfFuel}";
        }
    }
}
