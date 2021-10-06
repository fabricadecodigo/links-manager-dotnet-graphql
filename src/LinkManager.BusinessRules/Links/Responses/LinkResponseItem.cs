using System;

namespace LinkManager.BusinessRules.Links.Responses
{
    public class LinkResponseItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Uri { get; set; }
        public bool Active { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}