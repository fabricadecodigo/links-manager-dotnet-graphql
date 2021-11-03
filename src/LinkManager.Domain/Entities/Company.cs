using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LinkManager.Domain.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Guid UserId { get; set; }
    }
}