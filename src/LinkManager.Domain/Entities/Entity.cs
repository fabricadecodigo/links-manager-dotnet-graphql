using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LinkManager.Domain.Entities
{
    public abstract class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}