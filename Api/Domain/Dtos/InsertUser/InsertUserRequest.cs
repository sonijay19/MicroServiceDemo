using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.InsertUser
{
    public class InsertUserRequest : IRequest<bool>
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public string UserStatus { get; set; }
        public string PhoneNumber { get; set; }
    }
}
