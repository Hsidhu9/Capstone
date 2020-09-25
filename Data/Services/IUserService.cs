using ShiftPicker.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShiftPicker.Data.Services
{
    public interface IUserService
    {
        void AddUser(UserModel user);
        void DeleteUser(int id);
        Task<List<UserModel>> GetAll();
        Task<UserModel> GetUser(int Id);
        void UpdateUser(UserModel user);
    }
}