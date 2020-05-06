using Common;
using RabbitMQ.Client;
using System;

namespace Publisher
{
    class Producer
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

            using (var connection = connFactory.CreateConnection("Test connection"))
            {
                using (var channel = connection.CreateModel())
                {
                    //utowrzenie infry RMQ
                    RmqConfig.SetupRabbitMQInfrastructure(channel);
                                       

                    //przygotowanie wiaodmosci
                    var message = "Wiadomosc od Producera1";
                    var rmqMessage = System.Text.Encoding.UTF8.GetBytes(message);

                    //publ event
                    Console.WriteLine("[Producer] Sending evenbt");

                    channel.BasicPublish(
                        exchange: RmqConfig.PatientExchange,
                        routingKey: RmqConfig.PatientDeletedRoutingKey,
                        basicProperties: null,
                        body: rmqMessage);



                    //var message2 = "Wiadomosc od Producera2";
                    //var rmqMessage2 = System.Text.Encoding.UTF8.GetBytes(message2);

                    ////publ event
                    //Console.WriteLine("[Producer2] Sending evenbt");

                    //channel.BasicPublish(
                    //    exchange: RmqConfig.PatientExchange,
                    //    routingKey: RmqConfig.PatientDeletedRoutingKey,
                    //    basicProperties: null,
                    //    body: rmqMessage2);

                    Console.ReadLine();
                }

            }

            
        }

        static void ConsoleText()
        {
            Console.Title = "Demo - Producer RMQ";
            Console.WriteLine("[Producer] Start.");
        }
    }
}
