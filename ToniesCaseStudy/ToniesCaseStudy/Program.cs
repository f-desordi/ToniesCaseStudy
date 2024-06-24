using System.Diagnostics;
using System.Runtime.CompilerServices;
using TestEngine;

namespace ToniesCaseStudy
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Process? process = null;
            try
            {
                Console.WriteLine("Start GUI...");
                // Start UI to be tested.
                string enviromentPath = System.Environment.GetEnvironmentVariable("PATH") ?? "";
                var paths = enviromentPath.Split(';');
                var exePath = paths.Select(x => Path.Combine(x, "python.exe"))
                                   .Where(x => File.Exists(x))
                                   .First();

                process = Process.Start(exePath, "start_gui.pyw");

                // Wait for initialization
                Thread.Sleep(500);

                // Create test interface
                Program.TestStepDefinitions.Interface = new TestInterface();

                Console.WriteLine();
                Console.WriteLine("StartTesting ...");
                Console.WriteLine($"{"Test Step Name",-40}| Result|    Entry==Expected|    Label==Expected");
                Console.WriteLine($"----------------------------------------------------------------------------------------");
                // Execute and log test steps
                foreach(TestStep testStep in Program.TestStepDefinitions)
                {
                    testStep.Execute();

                    Console.WriteLine(testStep);
                }

                Console.WriteLine();
                Console.WriteLine("Overall result: " + Program.TestStepDefinitions.Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey(true);
                
                process?.Kill();
            }
        }
    }
}
