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
    /// Code behind for Creating User
    /// </summary>
    public partial class CreateEmployeeVM : OwningComponentBase
    {
        /// <summary>
        /// The User to be created
        /// </summary>
        protected UserModel Employee { get; set; } = new UserModel();

        /// <summary>
        /// The Navigation Manager that is given by the Framework to navigat from one page to another
        /// </summary>
        [Inject]
        protected NavigationManager NavManager { get; set; }
        /// <summary>
        /// Getting the UserRoleService from dependency Injection Container, which was injected as scoped
        /// </summary>
        private IUserRoleService UserRoleService =>ScopedServices.GetService<IUserRoleService>();

        /// <summary>
        /// Getting the UserService from dependency Injection Container, which was injected as scoped
        /// </summary>
        private IUserService UserService => ScopedServices.GetService<IUserService>();

        /// <summary>
        /// All the UserRoles, they are populated upon page load from db
        /// </summary>
        protected List<UserRole> UserRoles { get; set; } = new List<UserRole>();


        /// <summary>
        /// This method is called when the page is loaded
        /// </summary>
        /// <returns></returns>
        protected async override Task OnInitializedAsync()
        {
            
            UserRoles =  await UserRoleService.GetAll();
            await base.OnParametersSetAsync();
        }

        /// <summary>
        /// Methof to add a user
        /// </summary>
        public  void AddEmployee()
        {
            UserService.AddUser(Employee);
            NavManager.NavigateTo("/showAllEmployees");
        }
    }
}
