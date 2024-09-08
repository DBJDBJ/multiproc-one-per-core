using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        int coreCount = Environment.ProcessorCount;
        Console.WriteLine($"Number of CPU cores: {coreCount}");

        Task[] tasks = new Task[coreCount];

        for (int i = 0; i < coreCount; i++)
        {
            int coreIndex = i;
            tasks[i] = Task.Run(() => RunExecutable(coreIndex));
        }

        await Task.WhenAll(tasks);
        Console.WriteLine("All executables have completed.");
    }

    static void RunExecutable(int coreIndex)
    {
        string executablePath = "path/to/your/coreworker.exe";
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = executablePath,
            Arguments = $"--core {coreIndex}",
            UseShellExecute = false,
            RedirectStandardOutput = true
        };

        using (Process process = Process.Start(startInfo))
        {
            Console.WriteLine($"Started coreworker on core {coreIndex}");
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine($"coreworker on core {coreIndex} completed. Output: {output}");
        }
    }
}