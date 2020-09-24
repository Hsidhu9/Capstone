using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using ShiftPicker.Data.Models;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shift_Picker.Components.Employees
{
    public partial class CreateEmployee : ComponentBase
    {
        protected UserModel Employee { get; set; }

        [Inject]
        protected NavigationManager NavManager { get; set; }

        [Inject]
        protected IUserRoleService UserRoleService { get; set; }

        protected List<UserRole> UserRoles;

        protected async override Task OnInitializedAsync()
        {
            UserRoles = await UserRoleService.GetAll();
            Employee = new ShiftPicker.Data.Models.UserModel();
        }

        protected async Task AddEmployee()
        {

            NavManager.NavigateTo("/employee", forceLoad: true);
        }
    }
}
