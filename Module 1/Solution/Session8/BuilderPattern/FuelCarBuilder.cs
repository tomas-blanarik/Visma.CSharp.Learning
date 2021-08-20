namespace Session8.BuilderPattern
{
    public class FuelCarBuilder : CarBuilder
    {
        private string _typeOfFuel;

        public void SetFuel(string typeOfFuel)
        {
            _typeOfFuel = typeOfFuel;
        }

        public override ICar Build()
        {
            return new FuelCar
            {
                TypeOfFuel = _typeOfFuel,
                Color = _color,
                Model = _model,
                DateOfProduction = _date
            };
        }
    }
}
