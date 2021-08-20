using System;

namespace Session8.BuilderPattern
{
    public class Car : ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public DateTime? DateOfProduction { get; set; }

        public override string ToString()
        {
            return $"{Model} - {Color} - {DateOfProduction}";
        }
    }
}
