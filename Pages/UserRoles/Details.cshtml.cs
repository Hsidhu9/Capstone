using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShiftPicker.Data;
using ShiftPicker.Data.Models;

namespace ShiftPicker.Pages.UserRoles
{
    public class DetailsModel : PageModel
    {
        private readonly ShiftPicker.Data.UserContext _context;

        public DetailsModel(ShiftPicker.Data.UserContext context)
        {
            _context = context;
        }

        public UserRole UserRole { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserRole = await _context.UserRoles.FirstOrDefaultAsync(m => m.Id == id);

            if (UserRole == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
