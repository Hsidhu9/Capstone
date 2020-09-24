using Microsoft.AspNetCore.Components;
using ShiftPicker.Data.Models;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shift_Picker.Components
{
    public class EditEmployeeVM : ComponentBase
    {
        [Parameter]
        public int EmployeeId { get; set; }
        [Parameter]
        public UserModel Employee { get; set; }

        [Inject]
        protected IUserService UserService { get; set; }
        [Inject]
        protected IUserRoleService UserRoleService { get; set; }

        [Parameter]
        public List<UserRole> UserRoles { get; set; }

        protected async override Task OnParametersSetAsync()
        {
            Employee = await UserService.GetUser(EmployeeId);
            UserRoles = await UserRoleService.GetAll();
            await base.OnParametersSetAsync();
        }
    }
}
