
using RabbitMQ.Client;

namespace Common
{
    public static class RmqConfig
    {
        public const string PatientExchange = "patient-exchange";        

        public const string PatientCreatedQueue = "patient-created-queue";
        public const string PatientCreatedRoutingKey = "patient.created";

        public const string PatientDeletedQueue = "patient-deleted-queue";
        public const string PatientDeletedRoutingKey = "patient.deleted";

        public const string PatientLogQueue = "patient-log-queue";
        public const string PatientLogRoutingKey = "patient.*";


        public const string HostName = "localhost";
        public const string VirtualHost = "rmq";
        public const string UserName = "guest";
        public const string Password = "guest";

        public static void SetupRabbitMQInfrastructure(IModel channel)
        {
            
            //exchange            
            channel.ExchangeDeclare(
                exchange: RmqConfig.PatientExchange, 
                type: ExchangeType.Topic, 
                durable: true, 
                autoDelete: false, 
                arguments: null);

            

            //kolejki           
            channel.QueueDeclare(
                queue: RmqConfig.PatientCreatedQueue, 
                durable: true, 
                exclusive: false, 
                autoDelete: false, 
                arguments: null);

            channel.QueueDeclare(
                queue: RmqConfig.PatientDeletedQueue, 
                durable: true, 
                exclusive: false, 
                autoDelete: false, 
                arguments: null);

            channel.QueueDeclare(
                queue: RmqConfig.PatientLogQueue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            // bindings            
            channel.QueueBind(
                queue: RmqConfig.PatientCreatedQueue, 
                exchange: RmqConfig.PatientExchange, 
                routingKey: RmqConfig.PatientCreatedRoutingKey);

            channel.QueueBind(
                queue: RmqConfig.PatientDeletedQueue,
                exchange: RmqConfig.PatientExchange,
                routingKey: RmqConfig.PatientDeletedRoutingKey);

            channel.QueueBind(
                queue: RmqConfig.PatientLogQueue,
                exchange: RmqConfig.PatientExchange,
                routingKey: RmqConfig.PatientLogRoutingKey);
        }
    }
}
