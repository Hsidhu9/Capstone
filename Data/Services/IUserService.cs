using ShiftPicker.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShiftPicker.Data.Services
{
    /// <summary>
    /// Abstraction of User Service
    /// </summary>
    public interface IUserService
    {
        void AddUser(UserModel user);
        void DeleteUser(int id);
        Task<List<UserModel>> GetAllEmployees();

        Task<List<UserModel>> GetAllSupervisors();
        Task<UserModel> GetUser(int Id);
        void UpdateUser(UserModel user);
    }
}