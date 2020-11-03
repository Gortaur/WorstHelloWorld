using Autofac;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Worst_Hello_world.Configuration;
using WorstHelloWorld.Infrastructure.Sorting;
using WorstHelloWorld.Interface.Core.Providers;

namespace Worst_Hello_world.Utilities
{
    public static class Console
    {
        static Console()
        {
            var iocContainer = AutofacConfig.Configure();
            _helloWorldProvider = iocContainer.Resolve<IHelloWorldProvider>(); ;
        }

        public static char ReadKey()
        {
            var helloWorld = _helloWorldProvider.GetHelloWorld().ConfigureAwait(false).GetAwaiter().GetResult();
            System.Console.WriteLine(helloWorld);
            System.Console.ReadKey();
            return 'F';
        }

        public static void WriteLine(string str)
        {
            if (System.String.IsNullOrWhiteSpace(str)) 
            {
                Console.WriteLine("Write something, you, filthy casual!");
                return;
            }
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            if (str.Length <= 5)
            {
                OutputTask(str, cancellationToken).GetAwaiter().GetResult();
            }
            else
            {
                var taskList = new List<Task>();
                for (int i = 0; i < 10; i++)
                {
                    taskList.Add(OutputTask(str, cancellationToken));
                }
                Task.WhenAny(taskList);
                cancellationTokenSource.Cancel();
            }

            System.Console.WriteLine(outputResult);
            System.Console.WriteLine($"Elapsed time seconds:{elapsedTimeSeconds}");
        }

        private static Task OutputTask(string input, CancellationToken token)
        {
            System.Console.WriteLine("Thread Started");
            var sb = new StringBuilder();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var sortedArray = BogoBogoSort.Sort(input.ToCharArray(), input, token);
            stopwatch.Stop();

            if (sortedArray == null)
            {
                return Task.CompletedTask;
            }

            foreach (var character in sortedArray)
            {
                sb.Append(character.ToString());
            }
            outputResult = sb.ToString();
            elapsedTimeSeconds = stopwatch.ElapsedMilliseconds / 1000.0;
            return Task.CompletedTask;
        }

        private static readonly IHelloWorldProvider _helloWorldProvider;
        private static string outputResult;
        private static double elapsedTimeSeconds;
    }
}
