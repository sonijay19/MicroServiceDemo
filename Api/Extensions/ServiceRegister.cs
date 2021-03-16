using Api.Infrastructure.Interface;
using Api.Infrastructure.UserOperations.GetUserDetails;
using Api.Infrastructure.UserOperations.InsertUser;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Extensions
{
    public static class ServiceRegister
    {
        public static void RegisterInterface(IServiceCollection services)
        {
            services.AddSingleton<IUserDetailsInsert, InsertUserInformation>();
            services.AddSingleton<IGetUserDetails, GetUserInformation>();
        }
    }
}
