using System;
using System.Diagnostics;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace GetCompliance.Application.Queue
{
    public class DocumentQueue : IQueue
    {
        public void PutMessage(Message message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string msg = "Hello World!";
                var body = Encoding.UTF8.GetBytes(msg);

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", msg);
            }
        }


        public Message GetMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += OnConsumerOnReceived;
                consumer.Registered += ConsumerOnRegistered;
                channel.BasicConsume(queue: "hello",
                                     noAck: true,
                                     consumer: consumer);
            }

            return null;
        }

        private void ConsumerOnRegistered(object sender, ConsumerEventArgs consumerEventArgs)
        {
            Trace.Write("Registered");
        }

        private void OnConsumerOnReceived(object model, BasicDeliverEventArgs ea)
        {
            var message = Encoding.UTF8.GetString(ea.Body);
            Trace.Write("[x] Received {0}", message);
        }
    }
}
