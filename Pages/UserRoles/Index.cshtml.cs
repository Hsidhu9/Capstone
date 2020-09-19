using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShiftPicker.Data;
using ShiftPicker.Data.Models;
using ShiftPicker.Data.Services;

namespace ShiftPicker.Pages.UserRoles
{
    public class IndexModel : PageModel
    {
        private readonly IUserRoleService _userRoleService;

        public IndexModel(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        public IList<UserRole> UserRole { get;set; }

        public async Task OnGetAsync()
        {
            UserRole = await _userRoleService.GetAll();
        }
    }
}
