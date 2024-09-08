using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 2 && args[0] == "--core")
        {
            Console.WriteLine($"Executable running on core {args[1]}");
            // Simulate some work
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine($"Executable on core {args[1]} completed its work");
        }
        else
        {
            Console.WriteLine("Invalid arguments. Use: --core <core-id>");
        }
    }
}