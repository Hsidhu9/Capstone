using Microsoft.AspNetCore.Components;
using ShiftPicker.Data.Models;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shift_Picker.Components.Employees
{
    public partial class EditEmployee : ComponentBase
    {
        protected int EmployeeId { get; set; }
        protected UserModel Employee { get; set; }

        [Inject]
        protected IUserService UserService { get; set; }
        [Inject]
        protected IUserRoleService UserRoleService { get; set; }

        protected List<UserRole> UserRoles;


        protected async override Task OnInitializedAsync()
        {
            Employee = await UserService.GetUser(EmployeeId);
            UserRoles = await UserRoleService.GetAll();
        }
    }
}
