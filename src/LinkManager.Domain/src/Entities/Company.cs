using System;

namespace LinkManager.Domain.src.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public Guid UserId { get; set; }
    }
}