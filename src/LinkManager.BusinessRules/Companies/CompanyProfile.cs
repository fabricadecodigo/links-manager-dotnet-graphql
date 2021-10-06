using AutoMapper;
using LinkManager.BusinessRules.Companies.Requests;
using LinkManager.BusinessRules.Companies.Responses;
using LinkManager.Domain.Entities;

namespace LinkManager.BusinessRules.Companies
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CreateCompanyRequest, Company>();
            CreateMap<UpdateCompanyRequest, Company>();
            CreateMap<Company, CompanyResponseItem>();
        }
    }
}