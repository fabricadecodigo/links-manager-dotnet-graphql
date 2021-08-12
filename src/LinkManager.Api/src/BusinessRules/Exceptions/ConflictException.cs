using HotChocolate;
using System;

namespace LinkManager.Api.src.BusinessRules.Exceptions
{
    public class ConflictException : GraphQLException
    {
        public ConflictException(string message) : base(message)
        {
        }
    }
}