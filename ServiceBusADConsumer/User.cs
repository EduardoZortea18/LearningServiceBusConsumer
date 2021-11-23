namespace ServiceBusADConsumer
{
    public class User
    {
        public string Name { get; set; }
        public string AzureAdId { get; set; }

        public User(string name, string azureAdId)
        {
            Name = name;
            AzureAdId = azureAdId;
        }
    }
}
