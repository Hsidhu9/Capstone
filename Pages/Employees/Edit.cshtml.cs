using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shift_Picker.Pages;
using ShiftPicker.Data;
using ShiftPicker.Data.Services;

namespace ShiftPicker.Data.Models
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class EditModel : RoleNamePageModel
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;

        public EditModel(IUserService userService, IUserRoleService userRoleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
        }

        [BindProperty]
        public UserModel UserModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserModel = await _userService.GetUser(id.Value);
            var roles = await _userRoleService.GetAll();
            PopulateUserRolesAsync(roles);

            if (UserModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _userService.UpdateUser(UserModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToPage("./Index");
        }

    }
}
