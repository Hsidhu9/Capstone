using Microsoft.AspNetCore.Components;
using ShiftPicker.Data.Models;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Shift_Picker.Components
{
    /// <summary>
    ///  Code behind of All Supervisors Component
    /// </summary>
    public partial class AllSupervisorsVM: OwningComponentBase
    {
        private IUserService UserService => ScopedServices.GetService<IUserService>();

        [Inject]
        protected LoginModel LoggedInUser { get; set; }
        protected List<UserModel> AllUsers { get; set; } = new List<UserModel>();

        protected async override Task OnInitializedAsync()
        {
            AllUsers = await UserService.GetAllSupervisors();
        }

        public void ActivateUser(UserModel userModel)
        {
            UserService.ActivateUser(userModel);
        }

        public void DeactivateUser(UserModel userModel)
        {
            UserService.DeactivateUser(userModel);
        }
    }
}
