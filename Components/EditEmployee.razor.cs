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
        /// <summary>
        /// Employee Id of the User being editted, this employeeid is received as a paramter from previous page, when loaded
        /// </summary>
        [Parameter]
        public int EmployeeId { get; set; }

        /// <summary>
        /// The user being editted
        /// </summary>
        protected UserModel Employee { get; set; } = new UserModel();
        /// <summary>
        /// Getting the logged in User from the Dependency Inhjection container, which was injected as singleton
        /// </summary>
        [Inject]
        protected LoginModel LoggedInUser { get; set; }
        /// <summary>
        /// The Navigation Manager that is given by the Framework to navigat from one page to another
        /// </summary>
        [Inject]
        protected NavigationManager NavManager { get; set; }
        /// <summary>
        /// Getting the UserRoleService from dependency Injection Container, which was injected as scoped
        /// </summary>
        private IUserRoleService UserRoleService => ScopedServices.GetService<IUserRoleService>();
        /// <summary>
        /// Getting the UserService from dependency Injection Container, which was injected as scoped
        /// </summary>
        private IUserService UserService => ScopedServices.GetService<IUserService>();
        /// <summary>
        /// All the UserRoles, they are populated upon page load from db
        /// </summary>
        protected List<UserRole> UserRoles { get; set; } = new List<UserRole>();

        /// <summary>
        /// This method is called when the page is loaded and paramters are set
        /// </summary>
        /// <returns></returns>
        protected async override Task OnParametersSetAsync()
        {
            Employee = await UserService.GetUser(EmployeeId);
            UserRoles = await UserRoleService.GetAll();
            await base.OnParametersSetAsync();
        }
        /// <summary>
        /// Methof to update the user
        /// </summary>
        protected void UpdateEmployee()
        {
            UserService.UpdateUser(Employee);
        }
    }
}
