using System;

namespace Consumer
{
    class Consumer
    {
        static void Main(string[] args)
        {
            ConsoleText();           
           
            Console.ReadLine();
        }
        
        static void ConsoleText()
        {
            Console.Title = "Demo - consumer RMQ";
            Console.WriteLine("[Consumer] Start.");            
        }
    }
}
