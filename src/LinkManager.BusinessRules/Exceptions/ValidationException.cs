using FluentValidation.Results;
using HotChocolate;
using System.Collections.Generic;
using System.Linq;

namespace LinkManager.BusinessRules.Exceptions
{
    public class ValidationException : GraphQLException
    {
        public ValidationException(string message, List<ValidationFailure> errors) : base(
            new List<IError>()
            {
                ErrorBuilder.New().SetMessage(message).SetCode("VALIDATION_EXCEPTION").Build(),
            }
            .Concat(
                errors
                    .Select(e => ErrorBuilder.New().SetMessage(e.ErrorMessage).Build())
                    .ToList()
            )
        )
        {
        }
    }
}