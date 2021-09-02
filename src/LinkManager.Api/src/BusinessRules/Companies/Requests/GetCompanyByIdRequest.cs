using HotChocolate;
using System;

namespace LinkManager.Api.src.BusinessRules.Companies.Requests
{
    public class GetCompanyByIdRequest : BusinessRuleRequest
    {
        [GraphQLIgnore]
        public Guid UserId { get; set; }
    }
}