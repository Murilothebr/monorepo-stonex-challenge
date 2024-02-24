namespace ProductApi.Models;

public interface IMongoDbSettings
{
    string DatabaseName { get; set; }
    string ConnectionString { get; set; }
     string CollectionName { get; set; } 
}

public class MongoDbSettings : IMongoDbSettings
{
    public string DatabaseName { get; set; } = null!;
    public string ConnectionString { get; set; } = null!;
    public string CollectionName { get; set; } = null!;
}
