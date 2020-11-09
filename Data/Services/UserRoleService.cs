using Microsoft.EntityFrameworkCore;
using ShiftPicker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftPicker.Data.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly UserContext _userContext;

        /// <summary>
        /// The UserContext (Database context) is passed to the constrcutor from Dependency injection container, 
        /// also known as IServiceCollection, We had added the DbContext in Startup.cs as services.AddDbContext()
        /// </summary>
        /// <param name="userContext"></param>
        public UserRoleService(UserContext userContext)
        {
            _userContext = userContext;
        }

        /// <summary>
        /// Creating a user role
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns></returns>
        public async Task CreateUserRole(UserRole userRole)
        {
            await _userContext.UserRoles.AddAsync(userRole);
            await _userContext.SaveChangesAsync();
        }

        /// <summary>
        /// Getting all the User Roles
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserRole>> GetAll()
        {
            return await _userContext.UserRoles.ToListAsync();
        }
    }
}
