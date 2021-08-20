using System;

namespace Session8.BuilderPattern
{
    public class CarBuilder : ICarBuilder
    {
        protected string _color;
        protected string _model;
        protected DateTime? _date;

        public virtual ICar Build()
        {
            return new Car
            {
                Model = _model,
                Color = _color,
                DateOfProduction = _date
            };
        }

        public ICarBuilder SetColor(string color)
        {
            _color = color;
            return this;
        }

        public ICarBuilder SetModel(string model)
        {
            _model = model;
            return this;
        }

        public ICarBuilder SetProductionDate(DateTime? date)
        {
            _date = date;
            return this;
        }
    }
}
