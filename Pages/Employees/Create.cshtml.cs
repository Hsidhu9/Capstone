using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shift_Picker.Pages;
using ShiftPicker.Data;
using ShiftPicker.Data.Services;

namespace ShiftPicker.Data.Models
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class CreateModel : RoleNamePageModel
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;

        public CreateModel(IUserService userService, IUserRoleService userRoleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
        }

        public async  Task<IActionResult> OnGet()
        {
            var roles = await _userRoleService.GetAll();
            PopulateUserRolesAsync(roles);
            return Page();
        }


        
        

        [BindProperty]
        public UserModel UserModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _userService.AddUser(UserModel);

            return RedirectToPage("./Index");
        }
    }
}
