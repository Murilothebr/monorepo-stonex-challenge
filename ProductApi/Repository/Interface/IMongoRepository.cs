using MongoDB.Driver;
using ProductApi.Entities;
using System.Linq.Expressions;

namespace ProductApi.Repository.Interface;


public interface IMongoRepository<T> where T : BaseEntity
{
    void InsertOne(T document);

    Task InsertOneAsync(T document);

    void InsertMany(ICollection<T> documents);

    Task InsertManyAsync(ICollection<T> documents);

    Task<T> GetOneAsync(string id);

    Task UpdateOneAsync(string id, T newDocument);

    Task<IEnumerable<T>> GetAllAsync();

    Task DeleteOneAsync(string id);
}
