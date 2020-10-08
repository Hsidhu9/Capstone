using Microsoft.AspNetCore.Components;
using ShiftPicker.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShiftPicker.Data;

namespace Shift_Picker.Components
{
    public class LoginVM : OwningComponentBase
    {
        private ILoginService LoginService => ScopedServices.GetService<ILoginService>();
        protected UserModel User { get; set; }

        protected async override Task OnInitializedAsync()
        {
            User = new UserModel();
        }

        protected void ValidateUser()
        {
            LoginModel loginModel = new LoginModel();
            loginModel.UserName = User.UserName;
            loginModel.Password = User.Password;
            LoginService.Authenticate(loginModel);
            
        }
    }

}





