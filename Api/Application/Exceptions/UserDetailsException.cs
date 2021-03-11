using Api.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Application.Exceptions
{
    public class UserDetailsException : Exception
    {
        public readonly ErrorCodes _errorConstant;
        public UserDetailsException(ErrorCodes errorCodes) :
            base(errorCodes.ToString())
        {
            this._errorConstant = errorCodes;
        }
    }
}
