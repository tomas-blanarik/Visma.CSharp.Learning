using System;

namespace Session8.BuilderPattern
{
    public interface ICarBuilder
    {
        ICarBuilder SetModel(string model);
        ICarBuilder SetColor(string color);
        ICarBuilder SetProductionDate(DateTime? date);
        ICar Build();
    }
}
