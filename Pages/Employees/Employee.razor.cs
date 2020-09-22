using Microsoft.AspNetCore.Components;
using ShiftPicker.Data.Services;
using ShiftPicker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shift_Picker.Pages.Employees
{
    public class Employee : ComponentBase
    {
        [Inject]
        protected IUserService UserService { get; set; }

        protected List<UserModel> AllUsers { get; set; } = new List<UserModel>();

        protected async override  Task OnParametersSetAsync()
        {
            AllUsers = await UserService.GetAll();
        }

        
    }
}
