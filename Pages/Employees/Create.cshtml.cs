using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShiftPicker.Data;
using ShiftPicker.Data.Services;

namespace ShiftPicker.Data.Models
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;

        public CreateModel(IUserService userService, IUserRoleService userRoleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
        }

        public async Task<IActionResult> OnGet()
        {
            await PopulateRolesDropDownList();
            return Page();
        }

        public async Task PopulateRolesDropDownList(
           object selectedRole = null)
        {
            var userRoles  = await _userRoleService.GetAll();
            RoleNames = new SelectList(userRoles, nameof(UserRole.Id), nameof(UserRole.RoleName), selectedRole);
        }

        [BindProperty]
        public UserModel UserModel { get; set; }

        public SelectList RoleNames { get; set; }

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
