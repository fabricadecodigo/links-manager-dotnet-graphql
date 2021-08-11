using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace LinkManager.Domain.src.Entities
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