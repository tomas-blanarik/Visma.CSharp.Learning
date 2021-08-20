using System;

namespace Session8.BuilderPattern
{
    public interface ICar
    {
        string Color { get; set; }
        DateTime? DateOfProduction { get; set; }
        string Model { get; set; }
    }
}