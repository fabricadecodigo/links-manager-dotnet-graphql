using System;

namespace LinkManager.Domain.src.Entities
{
    public class Link : Entity
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public bool Active { get; set; }
        public Guid CompanyId { get; set; }
    }
}