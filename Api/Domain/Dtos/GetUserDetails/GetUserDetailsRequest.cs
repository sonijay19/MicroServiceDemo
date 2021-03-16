using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities.Models;
using MediatR;

namespace Api.Domain.Dtos.GetUserDetails
{
    public class GetUserDetailsRequest : IRequest<GetUserDetailsResponse>
    {
        public string UserEmail { get; set; }
    }
}
