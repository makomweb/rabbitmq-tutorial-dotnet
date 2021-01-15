using System;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;

namespace Send
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting sender.");

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

                string message = "Hello World!";
                var bytes = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                    routingKey: "hello",
                                    basicProperties: null,
                                    body: bytes);
                Console.WriteLine(" [x] Sent {0}", message);

                for(var i = 1; i < 20; i++)
                {
                    await Task.Delay(500);

                    message = $"Hello {i}.";
                    bytes = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                        routingKey: "hello",
                                        basicProperties: null,
                                        body: bytes);

                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
