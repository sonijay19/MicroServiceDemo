using Api.Application.Exceptions;
using Api.Domain.Dtos.GetUserDetails;
using Api.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Application.UseCases.Commands.GetUserDetails
{
    public class GetUserDetailsRequestValidation : AbstractValidator<GetUserDetailsRequest>
    {
        public GetUserDetailsRequestValidation()
        {
            RuleFor(user => user.UserEmail).NotEmpty().NotNull()
                .Matches(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$")
                .OnAnyFailure(x => {
                    throw new UserDetailsException(ErrorCodes.INVALID_USER_EMAILID);
                });
        }
    }
}
