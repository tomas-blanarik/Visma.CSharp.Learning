using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Session4
{
    public sealed class Program
    {
        public static async Task Main(string[] args)
        {
            /*
                Error handling using try-catch-finally
                - finally block
                - multiple catch blocks
                - creating custom exceptions
                - throw; vs. throw ex;
            */

            CancellationTokenSource source = new CancellationTokenSource();

            var httpClient = new HttpClient();
            try
            {
                var task = httpClient.GetAsync("https://google.com", source.Token);
                //source.Cancel();
                var result = await task;
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine(await result.Content.ReadAsStringAsync());
                }
            }
            catch (HttpRequestException ex)
            {
                // call a logger
                // at HttpClient.GetAsync(string? url) line: 86
                //throw;

                // at Session4.Main(string[] args) line: 31
                //throw ex;

                // this is an API error
            }
            catch (InvalidOperationException ex)
            {
                // this could be a wrong parameter in the httpClient
            }
            catch (Exception ex)
            {
                // this is everything else
            }
            finally
            {
                try
                {
                    httpClient.Dispose();
                }
                catch (Exception e)
                {
                    // handle the exception
                }
            }
        }
    }
}
