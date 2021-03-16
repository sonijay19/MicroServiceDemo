using Api.Domain.Dtos.GetUserDetails;
using Api.Domain.Entities.Models;
using Api.Domain.Enums;
using Api.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.UserOperations.GetUserDetails
{
    public class GetUserInformation : IGetUserDetails
    {
        public async Task<GetUserDetailsResponse> GetUserInformationAsync(GetUserDetailsRequest userDetails)
        {
            try
            {
                var context = new UserDetailsContext();
                var userInformation = context.UserDetails.Where(user => user.UserEmail == userDetails.UserEmail).SingleOrDefault();
                GetUserDetailsResponse userResponse = new GetUserDetailsResponse();
                userResponse.FirstName = userInformation.FirstName;
                userResponse.LastName = userInformation.LastName;
                userResponse.PhoneNumber = userInformation.PhoneNumber;
                userResponse.UserEmail = userInformation.UserEmail;
                userResponse.UserType = ((UserAccessType)userInformation.UserTypeId).ToString();
                return userResponse;
            }
            catch (Exception e)
            {
                throw;
                return null;
            }
        }
    }
}
