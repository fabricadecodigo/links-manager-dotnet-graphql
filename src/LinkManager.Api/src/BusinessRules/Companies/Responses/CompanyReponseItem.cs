using System;

namespace LinkManager.Api.src.BusinessRules.Companies.Responses
{
    public class CompanyReponseItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}