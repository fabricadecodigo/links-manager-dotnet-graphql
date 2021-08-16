using HotChocolate;
using System;

namespace LinkManager.Api.src.BusinessRules.Companies.Requests
{
    public class GetCompanyByIdRequest : BusinessRuleRequest
    {
        public Guid Id { get; set; }
        
        [GraphQLIgnore]
        public Guid UserId { get; set; }
    }
}