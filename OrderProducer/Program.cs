using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProducer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                Uri = new Uri("amqps://qmxuhgri:iCVIIpjCErxVOlx8f6tekdFAUeksHAL5@dog.lmq.cloudamqp.com/qmxuhgri")
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Declare the queue
                channel.QueueDeclare(queue: "orderQueue",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                for (int i = 1; i <= 5; i++)
                {
                    string orderMessage = $"Order {i} - Customer {i}";
                    var body = Encoding.UTF8.GetBytes(orderMessage);

                    // Publish message
                    channel.BasicPublish(exchange: "",
                                         routingKey: "orderQueue",
                                         basicProperties: null,
                                         body: body);

                    Console.WriteLine($"✅ Order Sent: {orderMessage}");
                }
            }
            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
        }
    }
}
