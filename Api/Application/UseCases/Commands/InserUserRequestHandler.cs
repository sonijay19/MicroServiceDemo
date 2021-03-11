using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Domain.Dtos.InsertUser;
using Api.Infrastructure.Interface;
using MediatR;

namespace Api.Application.UseCases.Commands
{
    public class InserUserRequestHandler : IRequestHandler<InsertUserRequest, bool>
    {
        private readonly IUserDetailsInsert userDetailsInsert;
        public InserUserRequestHandler(IUserDetailsInsert insertUserDetails)
        {
            userDetailsInsert = insertUserDetails;
        }
        public async Task<bool> Handle(InsertUserRequest request, CancellationToken cancellationToken)
        {
            var demo = await userDetailsInsert.InsertUserDetailsAsync(request);
            return demo;
        }
    }
}
