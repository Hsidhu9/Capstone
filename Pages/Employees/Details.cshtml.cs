using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShiftPicker.Data;

namespace ShiftPicker.Data.Models
{
    public class DetailsModel : PageModel
    {
        private readonly ShiftPicker.Data.UserContext _context;

        public DetailsModel(ShiftPicker.Data.UserContext context)
        {
            _context = context;
        }

        public UserModel UserModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserModel = await _context.UserModels.FirstOrDefaultAsync(m => m.Id == id);

            if (UserModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
