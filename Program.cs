using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // Stopwatch to determine the execution time for an application
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Calculate prime number up until limit
            int limit = 10000000;
            long total = 0;

            // Is prime?
            Func<int, bool> isPrime = x =>
            {
                if (x == 1) return false;
                if (x == 2) return true;

                var boundary = (int)Math.Floor(Math.Sqrt(x));

                for (int i = 2; i <= boundary; i++)
                {
                    if (x % i == 0) return false;
                }

                return true;
            };

            total = Enumerable.Range(0, limit).AsParallel().Where(isPrime).Sum(x => (long)x);

            stopwatch.Stop();

            var ts = stopwatch.Elapsed;

            Console.WriteLine($"Sum of prime numbers below {limit}: {total}");

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
}
