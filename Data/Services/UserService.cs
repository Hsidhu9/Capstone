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

        /// <summary>
        /// The UserContext (Database context) is passed to the constrcutor from Dependency injection container, 
        /// also known as IServiceCollection, We had added the DbContext in Startup.cs as services.AddDbContext()
        /// </summary>
        /// <param name="userContext"></param>
        public UserService(UserContext userContext)
        {
            _userContext = userContext;
        }
        /// <summary>
        /// Adding a user to db
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(UserModel user)
        {
            _userContext.UserModels.Add(user);
            _userContext.SaveChanges();
        }
        /// <summary>
        /// updateing the user in db
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(UserModel user)
        {
            _userContext.UserModels.Update(user);
            _userContext.SaveChanges();
        }
        /// <summary>
        /// Get a user by user id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<UserModel> GetUser(int Id)
        {
            var user =  await _userContext
                                .UserModels
                                .Include(s => s.Role)
                .FirstOrDefaultAsync(a => a.Id == Id);
            return user;
        }

        public async Task<UserModel> GetUserByIdAsync(int Id)
        {
            UserModel user = await _userContext
                                .UserModels
                                .Where(s => s.Id == Id).FirstOrDefaultAsync();
            return user;
        }

        public UserModel GetUserById(int Id)
        {
            UserModel user = _userContext
                                .UserModels
                                .Where(s => s.Id == Id).FirstOrDefault();
            return user;
        }

        /// <summary>
        /// Getting the users with role = employee
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Getting the users with role = supervisor
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// deactivating  a user
        /// </summary>
        /// <param name="userModel"></param>
        public void DeactivateUser(UserModel userModel)
        {
            userModel.isActive = false;
             _userContext.UserModels.Update(userModel);
            _userContext.SaveChanges();
        }
        /// <summary>
        /// Activating  a user
        /// </summary>
        /// <param name="userModel"></param>
        public void ActivateUser(UserModel userModel)
        {
                userModel.isActive = true;
            _userContext.UserModels.Update(userModel);
            _userContext.SaveChanges();
        }

        public async Task<UserModel> GetUserByUsername(string username)
        {
            return await _userContext.UserModels.Include(s => s.Role)
                                .Where(s => s.UserName.Equals(username)).FirstOrDefaultAsync();
        }
    }
}
