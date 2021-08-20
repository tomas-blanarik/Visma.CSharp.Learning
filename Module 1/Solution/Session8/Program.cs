using System;
using Session8.BuilderPattern;

namespace Session8
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            ICarBuilder builder = new CarBuilder();
            ICar car = builder.SetModel("Ford Kuga")
                .SetColor("black")
                .SetProductionDate(DateTime.Parse("2017-07-20"))
                .Build();

            //Factory factory = new Factory();

            //Card creditCard = factory.CreateGoldCard();
            //Card goldCard = new GoldCardFactory().CreateCard();

            // transient
            // scoped
            // singleton

            /*
                S - single responsibility principle
                O - open/closed principle
                L - liskov substitution principle
                I - interface segregation principle
                D - dependency inversion principle
            */

            //IRepository repository = new Repository();
            //IService service = new Service(repository);

            //var payments = service.GetPayments();
        }
    }
}
