using System;

namespace Publisher
{
    class Producer
    {
        static void Main(string[] args)
        {
            ConsoleText();
            Console.ReadLine();
        }

        static void ConsoleText()
        {
            Console.Title = "Demo - Producer RMQ";
            Console.WriteLine("[Producer] Start.");
        }
    }
}
