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
            _userContext.UserModels.Update(user);
            _userContext.SaveChanges();
        }

        public async Task<UserModel> GetUser(int Id)
        {
           
            var user =  await _userContext
                                .UserModels
                                .Include(s => s.Role)
                .FirstOrDefaultAsync(a => a.Id == Id);
            return user;
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> GetAllEmployees()
        {
            List<UserModel> employees = await _userContext
                                        .UserRoles
                                        .Include(s => s.Users)
                                        .Where(s => s.RoleName.ToUpper().Equals("EMPLOYEE"))
                                        .Select(s => s.Users.ToList())
                                        .FirstOrDefaultAsync();


            return employees;
        }


        public async Task<List<UserModel>> GetAllSupervisors()
        {
            List<UserModel> supervisors = await _userContext
                                          .UserRoles
                                          .Include(s => s.Users)
                                          .Where(s => s.RoleName.ToUpper().Equals("SUPERVISOR"))
                                          .Select(s => s.Users.ToList())
                                          .FirstOrDefaultAsync();
            return supervisors;
        }
    }
}
