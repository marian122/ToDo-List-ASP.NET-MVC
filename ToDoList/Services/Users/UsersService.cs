using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Services.Users.Interfaces;

namespace ToDoList.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> userManager;

        public UsersService(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task<string> GetUserIdAsync(ClaimsPrincipal claims)
        {
            var userId = await this.userManager.GetUserAsync(claims);

            return userId.Id;
        }
    }
}
