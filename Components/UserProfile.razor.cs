using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using ShiftPicker.Data.Models;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shift_Picker.Components
{
    /// <summary>
    ///  Code behind of User Profile Component
    /// </summary>
    public class UserProfileViewModel : OwningComponentBase
    {
        private IUserService UserService => ScopedServices.GetService<IUserService>();
        [Inject]
        protected LoginModel LoggedInUser { get; set; }


        protected void UpdateEmployee()
        {
            UserService.UpdateUser(LoggedInUser.User);
        }
    }
}
