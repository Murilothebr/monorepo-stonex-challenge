using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using ProductApi.Repository.Interface;
using System.Linq.Expressions;
using ProductApi.Models;
using ProductApi.Entities;

namespace ProductApi.Repository;

public class MongoRepository<T> : IMongoRepository<T> where T : BaseEntity
{
    private readonly IMongoCollection<T> _collection;

    public MongoRepository(IMongoDbSettings settings)
    {
        if (settings == null)
            throw new ArgumentNullException(nameof(settings));

        if (string.IsNullOrEmpty(settings.ConnectionString) || string.IsNullOrEmpty(settings.DatabaseName))
            throw new ArgumentException("ConnectionString and DatabaseName cannot be null or empty",
                nameof(settings.ConnectionString));

        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _collection = database.GetCollection<T>(settings.CollectionName);
    }

    public void InsertOne(T document)
        => _collection.InsertOneAsync(document);

    public async Task InsertOneAsync(T document)
        => await _collection.InsertOneAsync(document);

    public async Task<T> GetOneAsync(string id)
        => await _collection.FindAsync(x => x.Id.Equals(new ObjectId(id))).Result.FirstOrDefaultAsync();

    public async Task<T> GetOneAsyncBySku(string sku)
    {
        var filter = Builders<T>.Filter.Eq("SKU", sku);
        var result =  await _collection.FindAsync(filter);
        return result.FirstOrDefault();
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
         => await _collection.Find(_ => true).ToListAsync();

    public async Task UpdateOneAsync(string id, T newDocument)
    {
        var objectId = ObjectId.Parse(id);
        var filter = Builders<T>.Filter.Eq("_id", objectId);

        newDocument.Id = objectId;

        await _collection.ReplaceOneAsync(filter, newDocument);
    }

    public async Task DeleteOneAsync(string id)
    {
        var objectId = ObjectId.Parse(id);
        var filter = Builders<T>.Filter.Eq("_id", objectId);
        await _collection.DeleteOneAsync(filter);
    }

    public void InsertMany(ICollection<T> documents)
        => _collection.InsertManyAsync(documents);

    public async Task InsertManyAsync(ICollection<T> documents)
        => await _collection.InsertManyAsync(documents);
}
