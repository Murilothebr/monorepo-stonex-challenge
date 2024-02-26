using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductApi.Entities;

/// <summary>
/// Represents the base entity for MongoDB collections.
/// </summary>
public abstract class BaseEntity
{
    [BsonElement("_id")]
    public ObjectId Id { get; set; }
}
