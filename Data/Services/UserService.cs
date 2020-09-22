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

        public async Task UpdateUser(UserModel user)
        {
            _userContext.Attach(user).State = EntityState.Modified;
            await _userContext.SaveChangesAsync();
        }

        public async Task<UserModel> GetUser(int Id)
        {
            return await _userContext.UserModels.FirstOrDefaultAsync(a => a.Id == Id);
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
