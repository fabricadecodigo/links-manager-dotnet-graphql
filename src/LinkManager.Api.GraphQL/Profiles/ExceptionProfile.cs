using AutoMapper;
using HotChocolate;
using LinkManager.Api.GraphQL.Exceptions;
using LinkManager.BusinessRules.Exceptions;
using System;

namespace LinkManager.Api.GraphQL.Profiles
{
    public class ExceptionProfile : Profile
    {
        public ExceptionProfile()
        {
            CreateMap<Exception, GraphQLException>()
                .ForMember(m => m.Data, c => c.Ignore());
            CreateMap<ConflictException, ApiConflictException>()
                .ForMember(m => m.Data, c => c.Ignore());
            CreateMap<NotFoundException, ApiNotFoundException>()
                .ForMember(m => m.Data, c => c.Ignore());
            CreateMap<UnauthorizedException, ApiUnauthorizedException>()
                .ForMember(m => m.Data, c => c.Ignore());
            CreateMap<UnprocessableEntityException, ApiUnprocessableEntityException>()
                .ForMember(m => m.Data, c => c.Ignore());
        }
    }
}