using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ServiceBusADConsumer
{
    public class ServiceBusConnector
    {
        public static string connectionString = "Endpoint=sb://zortea.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=PAW8J4mD+4Og72G+V/ojD3S9jY2Jh/cT0r14qAKyoJI=";
        public static string queueName = "users";
        static IQueueClient queueClient = new QueueClient(connectionString, queueName);

        // handle received messages
        public async Task MessageHandler(Message message)
        {
            var client = new QueueClient(connectionString, queueName);

            User user = JsonConvert.DeserializeObject<User>(message.Body.ToString());

            var dbConnector = new DataBaseConnector();
            await dbConnector.CreateUsersInDB(user);

            // complete the message. messages is deleted from the queue. 
            await client.CompleteAsync(message.SystemProperties.LockToken);
        }

        // handle any errors when receiving messages
        public Task ErrorHandler(ExceptionReceivedEventArgs exception)
        {
            Console.WriteLine(exception.ToString());
            return Task.CompletedTask;
        }
    }
}
