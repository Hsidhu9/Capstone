using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShiftPicker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shift_Picker.Pages
{
    public class RoleNamePageModel : PageModel
    {
        public List<SelectListItem> UserRoles { get; set; }
        public void PopulateUserRolesAsync(List<UserRole> roles)
        {
            UserRoles = new List<SelectListItem>();
            roles.ForEach(s =>
            UserRoles.Add(
            new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.RoleName
            }));

            var emptyItem = new SelectListItem
            {
                Value = null,
                Text = "-- Select Role --"
            };

            UserRoles.Insert(0, emptyItem);
        }
    }
}
