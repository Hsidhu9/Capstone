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
        public void AddUser(UserModel user)
        {
            _userContext.Add(user);
            _userContext.SaveChanges();
        }

        public void UpdateUser(UserModel user)
        {
            _userContext.Attach(user).State = EntityState.Modified;
            _userContext.SaveChanges();
        }

        public async Task<UserModel> GetUser(int Id)
        {
           
            return await _userContext.UserModels.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> GetAll()
        {
            return await _userContext
                 .UserModels
                 .Include(s => s.Role)
                 .ToListAsync();
           
        }
    }
}
