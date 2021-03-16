using Api.Application.Exceptions;
using Api.Domain.Dtos.InsertUser;
using Api.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Application.UseCases.Commands
{
    public class InserUserRequestValidation : AbstractValidator<InsertUserRequest>
    {
        public InserUserRequestValidation()
        {
            RuleFor(user => user.UserEmail).NotEmpty().NotNull()
                .Matches(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$")
                .OnAnyFailure(x => {
                    throw new UserDetailsException(ErrorCodes.INVALID_USER_EMAILID);
                });

            RuleFor(person => person.FirstName).NotNull().NotEmpty()
                .Matches(@"^[A-Za-z0-9]+$")
                .OnAnyFailure(parameter => {
                    throw new UserDetailsException(ErrorCodes.INVALID_USER_FIRSTORLASTNAME);
                });

            RuleFor(person => person.LastName).NotNull().NotEmpty()
                .Matches(@"^[A-Za-z0-9]+$")
                .OnAnyFailure(parameter => {
                    throw new UserDetailsException(ErrorCodes.INVALID_USER_FIRSTORLASTNAME);
                });

            RuleFor(person => person.UserStatus).NotNull().NotEmpty()
                .Custom((parameter, context) =>
                {
                    if (parameter != UserAccessType.FullAccess.ToString()
                        && parameter != UserAccessType.StandardAccess.ToString()
                        && parameter != UserAccessType.ViewOnlyAccess.ToString())
                    {
                        throw new UserDetailsException(ErrorCodes.INVALID_USER_ACCESSTYPE);
                    }
                });
            RuleFor(person => person.PhoneNumber).NotNull().NotEmpty()
                .Matches("^\\d{10}$")
                .OnAnyFailure(parameter => {
                    throw new UserDetailsException(ErrorCodes.INVALID_USER_FIRSTORLASTNAME);
                });
        }
    }
}
