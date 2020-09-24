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
    public partial class CreateEmployeeVM : OwningComponentBase
    {
        protected UserModel Employee { get; set; } = new UserModel();

        [Inject]
        protected NavigationManager NavManager { get; set; }

        private IUserRoleService UserRoleService =>ScopedServices.GetService<IUserRoleService>();

        private IUserService UserService => ScopedServices.GetService<IUserService>();

        protected List<UserRole> UserRoles { get; set; } = new List<UserRole>();



        protected async override Task OnInitializedAsync()
        {
            
            UserRoles =  await UserRoleService.GetAll();
            await base.OnParametersSetAsync();
        }

        public  async Task AddEmployee()
        {
            await UserService.AddUser(Employee);
            NavManager.NavigateTo("/showAllEmployees");
        }
    }
}
