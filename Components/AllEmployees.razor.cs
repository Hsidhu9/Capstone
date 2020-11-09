using ShiftPicker.Data.Services;
using Microsoft.Extensions.DependencyInjection;
using ShiftPicker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Shift_Picker.Components
{
    /// <summary>
    ///  Code behind of All Employees Component
    /// </summary>
    public partial class AllEmployeesVM : OwningComponentBase
    {
        /// <summary>
        /// Getting the UserService from dependency Injection Container, which was injected as scoped
        /// </summary>
        private IUserService UserService => ScopedServices.GetService<IUserService>();

        /// <summary>
        /// All the employees, these are populated upon page load from the db
        /// </summary>
        protected List<UserModel> AllUsers { get; set; } = new List<UserModel>();

        /// <summary>
        /// This method is called when the page is loaded
        /// </summary>
        protected async override Task OnInitializedAsync()
        {
            AllUsers = await UserService.GetAllEmployees();
        }

        /// <summary>
        /// Activating the selected user
        /// </summary>
        /// <param name="userModel"></param>
        public void ActivateUser(UserModel userModel)
        {
            UserService.ActivateUser(userModel);
        }

        /// <summary>
        /// Deactiating the selected user
        /// </summary>
        /// <param name="userModel"></param>
        public void DeactivateUser(UserModel userModel)
        {
            UserService.DeactivateUser(userModel);
        }
    }
}
