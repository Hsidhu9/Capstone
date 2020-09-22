using Microsoft.AspNetCore.Components;
using ShiftPicker.Data;
using ShiftPicker.Data.Models;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shift_Picker.Pages.Employees
{
    public class CreateEmployee : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public IUserRoleService UserRoleService { get; set; }

        public UserModel Employee { get; set; }
        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();

        protected async override Task OnParametersSetAsync()
        {
            UserRoles = await UserRoleService.GetAll();
        }
    }
}
