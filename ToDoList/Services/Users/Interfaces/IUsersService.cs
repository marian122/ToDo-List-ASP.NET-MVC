using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ToDoList.Services.Users.Interfaces
{
    public interface IUsersService
    {
        Task<string> GetUserIdAsync(ClaimsPrincipal claims);
    }
}
