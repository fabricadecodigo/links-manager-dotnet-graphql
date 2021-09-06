using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace LinkManager.Domain.Entities
{
    public class Link : Entity
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public bool Active { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Guid CompanyId { get; set; }
    }
}