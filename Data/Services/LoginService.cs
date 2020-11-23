using Microsoft.EntityFrameworkCore;
using ShiftPicker.Data.Models;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftPicker.Data
{
    public class LoginService : ILoginService
    {
        private readonly UserContext _userContext;
        /// <summary>
        /// The UserContext (Database context) is passed to the constrcutor from Dependency injection container, 
        /// also known as IServiceCollection, We had added the DbContext in Startup.cs as services.AddDbContext()
        /// </summary>
        /// <param name="userContext"></param>
        public LoginService(UserContext userContext)
        {
            _userContext = userContext;
        }


        public LoginModel Authenticate(string userName, string password)
        {
            UserModel user =  _userContext.UserModels.Include(s => s.Role)
                                .Where(s => s.UserName.Equals(userName) && 
           s.Password.Equals(password)).FirstOrDefault();
             
            if(user != null && user.isActive) 
            {
                LoginModel loginModel = new LoginModel();

                loginModel.IsAuthenticated = true;
                loginModel.User = user;
                return loginModel;
            }
            return null;
        }
    }
}
