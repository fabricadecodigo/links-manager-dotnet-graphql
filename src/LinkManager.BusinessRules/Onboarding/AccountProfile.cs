using AutoMapper;
using LinkManager.BusinessRules.Companies.Requests;
using LinkManager.BusinessRules.Onboarding.Requests;
using LinkManager.BusinessRules.Onboarding.Responses;
using LinkManager.BusinessRules.Users.Requests;

namespace LinkManager.BusinessRules.Onboarding
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<CreateAccountRequestUser, CreateUserRequest>();
            CreateMap<CreateAccountRequestCompany, CreateCompanyRequest>();
        }
    }
}