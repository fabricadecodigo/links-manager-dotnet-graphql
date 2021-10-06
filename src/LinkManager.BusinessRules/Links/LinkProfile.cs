using AutoMapper;
using LinkManager.BusinessRules.Links.Requests;
using LinkManager.BusinessRules.Links.Responses;
using LinkManager.Domain.Entities;

namespace LinkManager.BusinessRules.Links
{
    public class LinkProfile : Profile
    {
        public LinkProfile()
        {
            CreateMap<CreateLinkRequest, Link>();
            CreateMap<Link, LinkResponseItem>();
        }
    }
}