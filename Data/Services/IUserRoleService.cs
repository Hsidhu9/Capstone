using ShiftPicker.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShiftPicker.Data.Services
{
    /// <summary>
    /// Abstraction of User Role Service
    /// </summary>
    public interface IUserRoleService
    {
        Task CreateUserRole(UserRole userRole);
        Task<List<UserRole>> GetAll();
    }
}