using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Leonardo
{
    public record FibonacciResult(int Input, int Result);

    public static class Fibonacci
    {
        public static int GetFibonacci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            else
            {
                return GetFibonacci(n - 1) + GetFibonacci(n - 2);
            }
        }


        public static async Task<List<FibonacciResult>> Results(string[] strings)
        {
            var tasks = new List<Task<FibonacciResult>>();

            foreach (var input in strings)
            {
                var int32 = Convert.ToInt32(input);
                var r = Task.Run(() =>
                {
                    var result = Fibonacci.GetFibonacci(int32);
                    return new FibonacciResult(int32, result);
                });

                tasks.Add(r);
            }

            var results = new List<FibonacciResult>();
            foreach (var task in tasks)
            {
                var r = await task;
                results.Add(r);
            }

            return results;
        }
    }
}

