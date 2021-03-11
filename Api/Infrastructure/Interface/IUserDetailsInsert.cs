using Api.Domain.Dtos.InsertUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.Interface
{
    public interface IUserDetailsInsert
    {
        Task<bool> InsertUserDetailsAsync(InsertUserRequest userRequest);
    }
}
