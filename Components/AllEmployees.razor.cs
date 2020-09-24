using Microsoft.AspNetCore.Components;
using ShiftPicker.Data.Services;
using ShiftPicker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shift_Picker.Helpers;

namespace Shift_Picker.Components
{
    public partial class AllEmployeesVM : ComponentBase
    {
        private IUserService UserService => Control.GetService<IUserService>();

        [Inject]
        public ScopeControl Control { get; set; }
        protected List<UserModel> AllUsers { get; set; } = new List<UserModel>();

        protected async override Task OnInitializedAsync()
        {
            AllUsers = await UserService.GetAll();
            Control.ClearScope();
        }


    }
}
