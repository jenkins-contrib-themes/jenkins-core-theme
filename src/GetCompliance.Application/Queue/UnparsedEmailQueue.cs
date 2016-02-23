using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace GetCompliance.Application.Queue
{
    public class UnparsedEmailQueue
    {
        public void PutMessage(UnparsedEmailMessage unparsedEmailMessage)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                
                channel.QueueDeclare(queue: "unparsed_emails",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = unparsedEmailMessage.SerializeAsBytes();


                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                channel.BasicPublish(exchange: "",
                                     routingKey: "",
                                     basicProperties: properties,
                                     body: body);

                Console.WriteLine("[x] Sent");
            }
        }


        public void GetMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "unparsed_emails",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {

                    var message = new UnparsedEmailMessage(ea.Body);
                    Trace.Write("[x] Received {0}", message.Filename);
                    // ReSharper disable once AccessToDisposedClosure
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };
                consumer.Registered += ConsumerOnRegistered;
                channel.BasicConsume(queue: "unparsed_emails",
                                     noAck: false,
                                     consumer: consumer);
            }
        }

        private void ConsumerOnRegistered(object sender, ConsumerEventArgs consumerEventArgs)
        {
            Trace.Write("Registered");
        }

    }
}
