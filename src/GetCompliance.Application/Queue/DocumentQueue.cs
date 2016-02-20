﻿using System;
using System.Diagnostics;
using System.Net;
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
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                channel.QueueDeclare(queue: "parse_document",
                                     durable: true,
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
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                channel.QueueDeclare(queue: "parse_document",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {

                    var message = Encoding.UTF8.GetString(ea.Body);
                    Trace.Write("[x] Received {0}", message);
                    // ReSharper disable once AccessToDisposedClosure
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };
                consumer.Registered += ConsumerOnRegistered;
                channel.BasicConsume(queue: "hello",
                                     noAck: false,
                                     consumer: consumer);
            }

            return null;
        }

        private void ConsumerOnRegistered(object sender, ConsumerEventArgs consumerEventArgs)
        {
            Trace.Write("Registered");
        }

    }
}
