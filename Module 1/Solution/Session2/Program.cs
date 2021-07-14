using System;
using Session2.Abstractions;
using Session2.Classes;

namespace Session2
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var wagon1 = new RegularWagon(10);
            var wagon2 = new RegularWagon(20);
            var restaurant = new RestaurantWagon();

            ITrain train = new Train(
                wagon1, wagon2,
                new PremiumWagon(5), new PremiumWagon(10),
                restaurant, new RestaurantWagon(),
                new RegularWagon(2)
            );

            ((Train)train).PrintWagons();
            Console.WriteLine($"Total seats behind the train is: {train.TotalSeats}");

            train.ReserveSeat(wagon1, 1);
            try
            {
                train.ReserveSeat(wagon1, 1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }

            try
            {
                train.ReserveSeat(restaurant, 5);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString()); ;
            }

            Console.ReadKey();
        }
    }
}
