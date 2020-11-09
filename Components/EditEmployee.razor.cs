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
    ///  Code behind of Edit Employee Component
    /// </summary>
    public class EditEmployeeVM : OwningComponentBase
    {
        [Parameter]
        public int EmployeeId { get; set; }
        protected UserModel Employee { get; set; } = new UserModel();

        [Inject]
        protected LoginModel LoggedInUser { get; set; }
        [Inject]
        protected NavigationManager NavManager { get; set; }

        private IUserRoleService UserRoleService => ScopedServices.GetService<IUserRoleService>();

        private IUserService UserService => ScopedServices.GetService<IUserService>();

        protected List<UserRole> UserRoles { get; set; } = new List<UserRole>();
        protected async override Task OnParametersSetAsync()
        {
            Employee = await UserService.GetUser(EmployeeId);
            UserRoles = await UserRoleService.GetAll();
            await base.OnParametersSetAsync();
        }

        protected void UpdateEmployee()
        {
            UserService.UpdateUser(Employee);
        }
    }
}
