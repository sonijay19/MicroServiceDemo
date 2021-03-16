using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Domain.Dtos.GetUserDetails;
using Api.Domain.Entities.Models;
using Api.Infrastructure.Interface;
using MediatR;

namespace Api.Application.UseCases.Commands.GetUserDetails
{
    public class GetUserDetailsRequestHandler : IRequestHandler<GetUserDetailsRequest, GetUserDetailsResponse>
    {
        private readonly IGetUserDetails getUserDetails;
        public GetUserDetailsRequestHandler(IGetUserDetails userDetails)
        {
            getUserDetails = userDetails;
        }
        public async Task<GetUserDetailsResponse> Handle(GetUserDetailsRequest request, CancellationToken cancellationToken)
        {
            var userInfo = await getUserDetails.GetUserInformationAsync(request);
            if(userInfo is null)
            {
                return null;
            }
            return userInfo;
        }
    }
}
