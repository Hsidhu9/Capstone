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
        public bool Authenticate(LoginModel loginModel)
        {
            return true;
        }
    }
}
