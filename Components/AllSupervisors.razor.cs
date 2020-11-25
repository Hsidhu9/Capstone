using Microsoft.AspNetCore.Components;
using ShiftPicker.Data.Models;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;

namespace Shift_Picker.Components
{
    /// <summary>
    ///  Code behind of All Supervisors Component
    /// </summary>
    public partial class AllSupervisorsVM: OwningComponentBase
    {
        /// <summary>
        /// Getting the UserService from dependency Injection Container, which was injected as scoped
        /// </summary>
        private IUserService UserService => ScopedServices.GetService<IUserService>();
        [CascadingParameter]
        protected Task<AuthenticationState> AuthenticationStateTask { get; set; }
        /// <summary>
        /// Getting the logged in User from the Dependency Inhjection container, which was injected as singleton
        /// </summary>

        protected UserModel LoggedInUser { get; set; }

        /// <summary>
        /// All the suprevisors, these are populated upon page load from the db
        /// </summary>
        protected List<UserModel> AllUsers { get; set; } = new List<UserModel>();
        /// <summary>
        /// This method is called when the page is loaded
        /// </summary>
        protected async override Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateTask;
            if (int.TryParse(authState.User.Claims.Where(s => s.Type == "UserId").Select(s => s.Value).FirstOrDefault(), out int userId))
                LoggedInUser = await UserService.GetUser(userId);
            AllUsers = await UserService.GetAllSupervisors();
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
