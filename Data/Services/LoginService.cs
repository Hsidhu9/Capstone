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
        public LoginService(UserContext userContext)
        {
            _userContext = userContext;
        }
        public bool Authenticate(LoginModel loginModel)
        {
           UserModel user = _userContext.UserModels.Where(s => s.UserName.Equals(loginModel.User.UserName) && 
           s.Password.Equals(loginModel.User.Password)).FirstOrDefault();
             
            if(user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
