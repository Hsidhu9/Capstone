using ShiftPicker.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShiftPicker.Data.Services
{
    public interface IUserRoleService
    {
        Task CreateUserRole(UserRole userRole);
        Task<List<UserRole>> GetAll();
    }
}