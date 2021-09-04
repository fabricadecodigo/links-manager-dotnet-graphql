namespace LinkManager.BusinessRules
{
    public abstract class BusinessRuleResponse<TPayload>
    {
        public TPayload Payload { get; set; }
    }
}