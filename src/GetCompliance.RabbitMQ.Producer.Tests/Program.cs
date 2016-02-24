using System;
using System.Text;
using GetCompliance.Application.Queue;

namespace GetCompliance.RabbitMQ.Producer.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the messages to be put in the 'test' queue:");
            while (true)
            {
                var message = Console.ReadLine() ?? "";
                var producer = new RabbitMqQueueManager();
                producer.PutMessage("test", Encoding.UTF8.GetBytes(message));
                Console.WriteLine("Message registered successfully");
            }
        }
    }
}
