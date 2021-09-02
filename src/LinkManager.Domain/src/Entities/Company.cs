using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace LinkManager.Domain.src.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Guid UserId { get; set; }
    }
}