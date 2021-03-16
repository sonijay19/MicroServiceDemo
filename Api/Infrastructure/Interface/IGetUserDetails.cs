using Api.Domain.Dtos.GetUserDetails;
using Api.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.Interface
{
    public interface IGetUserDetails
    {
        Task<GetUserDetailsResponse> GetUserInformationAsync(GetUserDetailsRequest userDetails);
    }
}
