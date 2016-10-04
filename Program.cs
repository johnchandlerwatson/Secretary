using System.Diagnostics;
using System;

namespace SecretaryApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // args = new string[3];
            // args[0] = "100";
            // args[1] = "100";
            // args[2] = ".3";

            var numberOfTests = GetArgInt(args, 0);
            var numberOfApplicants = GetArgInt(args, 1);
            var eulerConst = GetArgDec(args, 2);
            
            var testRunner = new TestsRunner(numberOfTests, numberOfApplicants, eulerConst);
            var watch = new Stopwatch();
            watch.Start();
            testRunner.Run();
            watch.Stop();
            Console.WriteLine($"The tests ran in {watch.Elapsed.Milliseconds} milliseconds.");
            Console.ReadKey();
        }

        private static int GetArgInt(string[] args, int index)
        {
            if (string.IsNullOrEmpty(args[index])) return 1;
            var numberOfTests = 1;
            int.TryParse(args[index], out numberOfTests);
            return numberOfTests;
        }
        private static decimal GetArgDec(string[] args, int index)
        {
            if (string.IsNullOrEmpty(args[index])) return 1m;
            var eulerConst = 1m;
            decimal.TryParse(args[index], out eulerConst);
            return eulerConst;
        }
    }
}
