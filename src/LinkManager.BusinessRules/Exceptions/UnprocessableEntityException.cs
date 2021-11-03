using HotChocolate;
using System;

namespace LinkManager.BusinessRules.Exceptions
{
    public class UnprocessableEntityException : GraphQLException
    {
        public UnprocessableEntityException(string message) : base(
            ErrorBuilder.New().SetMessage(message).SetCode("UNPROCESSABLE_ENTITY_EXCEPTION").Build()
        )
        {
        }
    }
}