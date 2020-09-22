using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shift_Picker.Pages.Schedules
{
    public class CreateShiftsModel : PageModel
    {
        public string CurrentDate { get; set; }
        public CreateShiftsModel()
        {

        }
        public void OnGet()
        {

        }



        public void GetWeek()
        {
            
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            int currentWeek = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

        }
    }
}