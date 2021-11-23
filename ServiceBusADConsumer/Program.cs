using System;

namespace ServiceBusADConsumer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceBusConnector = new ServiceBusConnector();
            var dbConnector = new DataBaseConnector();

            try
            {
                serviceBusConnector.MessageHandler();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
