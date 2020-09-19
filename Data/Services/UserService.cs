using Microsoft.EntityFrameworkCore;
using ShiftPicker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftPicker.Data.Services
{
    public class UserService : IUserService
    {
        private readonly UserContext _userContext;

        public UserService(UserContext userContext)
        {
            _userContext = userContext;
        }
        public async Task  AddUser(UserModel user)
        {
            await _userContext.UserModels.AddAsync(user);
            await _userContext.SaveChangesAsync();
        }

        public void UpdateUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public UserModel GetUser(int Id)
        {
            return new UserModel();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public  async Task<List<UserModel>> GetAll()
        {
           return await _userContext
                        .UserModels
                        .Include(u => u.Role)
                        .ToListAsync();
        }
    }
}
