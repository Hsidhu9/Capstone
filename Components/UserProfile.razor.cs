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
        /// <summary>
        /// Getting the UserService from dependency Injection Container, which was injected as scoped
        /// </summary>
        private IUserService UserService => ScopedServices.GetService<IUserService>();

        /// <summary>
        /// Getting the logged in User from the Dependency Inhjection container, which was injected as singleton
        /// </summary>
        [Inject]
        protected LoginModel LoggedInUser { get; set; }

        /// <summary>
        /// Method to update the Logged in User's profile
        /// </summary>
        protected void UpdateEmployee()
        {
            UserService.UpdateUser(LoggedInUser.User);
        }
    }
}
