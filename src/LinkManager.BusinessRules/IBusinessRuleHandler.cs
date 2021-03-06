using System.Threading.Tasks;

namespace LinkManager.BusinessRules
{
    public interface IBusinessRuleHandler<TRequest>
        where TRequest : BusinessRuleRequest
    {
        Task ExecuteAsync(TRequest request);
    }

    public interface IBusinessRuleHandler<TResponse, TPayload>
        where TResponse : BusinessRuleResponse<TPayload>
    {
        Task<TResponse> ExecuteAsync();
    }

    public interface IBusinessRuleHandler<TRequest, TResponse, TPayload>
        where TRequest : BusinessRuleRequest
        where TResponse : BusinessRuleResponse<TPayload>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}