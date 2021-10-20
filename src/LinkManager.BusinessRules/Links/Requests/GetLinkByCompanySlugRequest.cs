namespace LinkManager.BusinessRules.Links.Requests
{
    public class GetLinkByCompanySlugRequest : BusinessRuleRequest
    {
        public string Slug { get; set; }
    }
}