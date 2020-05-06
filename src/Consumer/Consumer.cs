using Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace Consumer
{
    class Consumer
    {
        static void Main(string[] args)
        {
            ConsoleText();

            var connFactory = new ConnectionFactory
            {
                HostName = RmqConfig.HostName,
                VirtualHost = RmqConfig.VirtualHost,
                UserName = RmqConfig.UserName,
                Password = RmqConfig.Password
            };

            using (var connection = connFactory.CreateConnection("Test connection - consumer"))
            {
                using (var channel = connection.CreateModel())
                {
                    //utowrzenie infry RMQ
                    RmqConfig.SetupRabbitMQInfrastructure(channel);
                    CreatePatientCreatedConsumer(channel);
                    CreatePatientDeletedConsumer(channel);
                    CreatePatientLogConsumer(channel);

                    Console.ReadLine();
                }
            }
        }
        
        static void CreatePatientCreatedConsumer(IModel channel)
        {
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sedner, eventArgs) =>
            {
                var body = eventArgs.Body;
                var message = System.Text.Encoding.UTF8.GetString(body.ToArray());
                Console.WriteLine($"[CreatePatientCreatedConsumer] Received: {message}");

            };

            channel.BasicConsume(
                queue: RmqConfig.PatientCreatedQueue, 
                autoAck: true, 
                consumer: consumer);
        }

        static void CreatePatientDeletedConsumer(IModel channel)
        {
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sedner, eventArgs) =>
            {
                var body = eventArgs.Body;
                var message = System.Text.Encoding.UTF8.GetString(body.ToArray());
                Console.WriteLine($"[CreatePatientDeletedConsumer] Received: {message}");

            };

            channel.BasicConsume(
                queue: RmqConfig.PatientDeletedQueue,
                autoAck: true,
                consumer: consumer);
        }

        static void CreatePatientLogConsumer(IModel channel)
        {
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sedner, eventArgs) =>
            {
                var body = eventArgs.Body;
                var message = System.Text.Encoding.UTF8.GetString(body.ToArray());
                Console.WriteLine($"[LogConsumer] Received: {message}");

            };

            channel.BasicConsume(
                queue: RmqConfig.PatientLogQueue,
                autoAck: true,
                consumer: consumer);
        }

        static void ConsoleText()
        {
            Console.Title = "Demo - consumer RMQ";
            Console.WriteLine("[Consumer] Start.");            
        }
    }
}
