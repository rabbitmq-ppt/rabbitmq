
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

        public static void SetupRabbitMQInfrastructure()
        {
            //exchange            

            //kolejki           

            // bindings            
        }
    }
}
