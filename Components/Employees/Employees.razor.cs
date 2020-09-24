using Microsoft.AspNetCore.Components;
using ShiftPicker.Data.Services;
using ShiftPicker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shift_Picker.Components.Employees
{
    public partial class AllEmployees : ComponentBase
    {
        [Inject]
        protected IUserService UserService { get; set; }

        protected List<UserModel> AllUsers { get; set; }

        protected async override Task OnInitializedAsync()
        {
            AllUsers = await UserService.GetAll();
        }


    }
}
