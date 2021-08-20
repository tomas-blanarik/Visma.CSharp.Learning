using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Session7
{
    public sealed class Program
    {
        // Thread
        // Performance tunning
        // 1. convert everything to async/await

        public static async Task Main(string[] args)
        {
            /*
                async programming
                Thread vs. Task
                ConfigureAwait - GUI, client libraries
                async void
                synchronization
            */

            CancellationTokenSource cts = new CancellationTokenSource();

            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready - {0}", Thread.CurrentThread.ManagedThreadId);

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = MakeToastWithButterAndJamAsync(2, cts.Token);

            var listOfTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (listOfTasks.Count > 0)
            {
                cts.Cancel();
                Task finishedTask = await Task.WhenAny(listOfTasks);

                if (finishedTask.IsFaulted || finishedTask.IsCanceled || !finishedTask.IsCompletedSuccessfully)
                {
                    Console.WriteLine("Task failed - {0}", finishedTask.Exception?.Message);
                }

                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("eggs are ready - {0}", Thread.CurrentThread.ManagedThreadId);
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready - {0}", Thread.CurrentThread.ManagedThreadId);
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready - {0}", Thread.CurrentThread.ManagedThreadId);
                }

                listOfTasks.Remove(finishedTask);
            }

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready - {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Breakfast is ready! - {0}", Thread.CurrentThread.ManagedThreadId);
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice - {0}", Thread.CurrentThread.ManagedThreadId);
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast - {0}", Thread.CurrentThread.ManagedThreadId);

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast - {0}", Thread.CurrentThread.ManagedThreadId);

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int slices, CancellationToken cancellationToken = default)
        {
            Toast toast = await ToastBreadAsync(slices, cancellationToken);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static async Task<Toast> ToastBreadAsync(int slices, CancellationToken cancellationToken = default)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster - {0}", Thread.CurrentThread.ManagedThreadId);
            }

            Console.WriteLine("Start toasting... - {0}", Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(5000);
            Console.WriteLine("Remove toast from toaster - {0}", Thread.CurrentThread.ManagedThreadId);

            if (cancellationToken.IsCancellationRequested)
            {
                throw new Exception("Cancellation is requested");
            }

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan - {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("cooking first side of bacon... - {0}", Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000);

            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon - {0}", Thread.CurrentThread.ManagedThreadId);
            }

            Console.WriteLine("cooking the second side of bacon... - {0}", Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000);
            Console.WriteLine("Put bacon on plate - {0}", Thread.CurrentThread.ManagedThreadId);

            return new Bacon();
        }

        private static Egg FryEgg(int howMany)
        {
            return FryEggsAsync(howMany).Result;
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan... - {0}", Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000);
            Console.WriteLine($"cracking {howMany} eggs - {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("cooking the eggs ... - {0}", Thread.CurrentThread.ManagedThreadId);
            //await WaitForEggToFinishAsync();
            Console.WriteLine("Put eggs on plate - {0}", Thread.CurrentThread.ManagedThreadId);

            return new Egg();
        }

        private static async Task WaitForEggToFinishAsync()
        {
            int temp = 0;
            while (true) // 100.000
            {
                temp += 1;

                // read sensor
                int currentTemp = temp;
                if (currentTemp >= 100)
                {
                    break;
                }

                await Task.Delay(150);
            }
        }

        //Task // void
        //Task<Coffee> // with return type
        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee - {0}", Thread.CurrentThread.ManagedThreadId);
            return new Coffee();
        }
    }
}
