using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShiftPicker.Data;
using ShiftPicker.Data.Models;
using ShiftPicker.Data.Services;

namespace ShiftPicker.Pages.UserRoles
{

    [IgnoreAntiforgeryToken(Order = 1001)]
    public class CreateModel : PageModel
    {
        private readonly IUserRoleService _userRoleService;

        public CreateModel(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserRole UserRole { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var emptyRole = new UserRole();

            await _userRoleService.CreateUserRole(UserRole);
            return RedirectToPage("./Index");
        }
    }
}
