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
        private readonly LoginModel _loginModel;

        public LoginService(UserContext userContext, LoginModel loginModel)
        {
            _userContext = userContext;
            _loginModel = loginModel;
        }


        public bool Authenticate()
        {
           UserModel user =  _userContext.UserModels.Include(s => s.Role)
                                .Where(s => s.UserName.Equals(_loginModel.User.UserName) && 
           s.Password.Equals(_loginModel.User.Password)).FirstOrDefault();
             
            if(user == null) 
                return false;
            else
            {
                _loginModel.IsAuthenticated = true;
                _loginModel.User = user;
                return true;
            }
        }
    }
}
