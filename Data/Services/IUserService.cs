using ShiftPicker.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShiftPicker.Data.Services
{
    public interface IUserService
    {
        Task AddUser(UserModel user);
        void DeleteUser(int id);
        Task<List<UserModel>> GetAll();
        Task<UserModel> GetUser(int Id);
        Task UpdateUser(UserModel user);
    }
}