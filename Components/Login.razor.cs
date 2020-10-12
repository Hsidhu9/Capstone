using Microsoft.AspNetCore.Components;
using ShiftPicker.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.SessionStorage;

namespace Shift_Picker.Components
{
    /// <summary>
    /// Code behind of Login Component
    /// </summary>
    public class LoginVM : OwningComponentBase
    {
        private ILoginService LoginService => ScopedServices.GetService<ILoginService>();
        protected UserModel User { get; set; }

        [Inject]
        protected LoginModel LoggingInUser { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            User = new UserModel();
        }

        protected  void ValidateUser()
        {
            LoggingInUser.User = User;
            LoginService.Authenticate();
            NavigationManager.NavigateTo(NavigationManager.BaseUri, true);
            return;
        }
    }

}





