using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using GetCompliance.Application.Queue;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace GetCompliance.RabbitMQ.Consumer.Tests
{
    class Program
    {
        public class FakeConsumer : IQueueConsumer
        {
            public void Consume(byte[] message)
            {
                Console.WriteLine("Message received: " + Encoding.UTF8.GetString(message));
            }
        }

        static void Main(string[] args)
        {
            using (var manager = new RabbitMqQueueManager())
            {
                manager.RegisterConsumer("test", new FakeConsumer());
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
        }
    }
}
