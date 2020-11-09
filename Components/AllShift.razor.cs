using Microsoft.AspNetCore.Components;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShiftPicker.Data.Models;

namespace Shift_Picker.Components
{
    /// <summary>
    /// Code behind of All Shifts Component
    /// </summary>
    public class AllShiftVM : OwningComponentBase
    {
        /// <summary>
        /// Getting the ShiftDetailService from dependency Injection Container, which was injected as scoped
        /// </summary>
        private IShiftDetailService ShiftDetailService => ScopedServices.GetService<IShiftDetailService>();
        protected List<ShiftModel> AllShifts { get; set; } = new List<ShiftModel>();

        public DateTime Today { get; set; }

        /// <summary>
        /// All the Shifts Selected by the Logged In User, this is populated from db upon page load
        /// </summary>
        protected List<ShiftDetailModel> AllShiftDetails { get; set; } = new List<ShiftDetailModel>();

        /// <summary>
        /// Getting the logged in User from the Dependency Inhjection container, which was injected as singleton
        /// </summary>
        [Inject]
        protected LoginModel LoggedInUser { get; set; }

        /// <summary>
        /// This method is called when the page is loaded
        /// </summary>
        protected override void OnInitialized()
        {
            //converting times based on US Mountain standard time, as it does not get the correct time when deployed to azure
            var currentTimeZone = TimeZoneInfo.FindSystemTimeZoneById("US Mountain Standard Time");
            Today = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, currentTimeZone);

            AllShiftDetails =  ShiftDetailService.GetAllShiftsForEmployee(LoggedInUser.User.Id);
            AllShifts = AllShiftDetails.Select(s => s.Shift).ToList();
        }
        
        /// <summary>
        /// MEthod to Cancel the shift as an Employee
        /// </summary>
        /// <param name="shiftDetail"></param>
        protected void CancelShiftDetails(ShiftDetailModel shiftDetail)
        {
            ShiftDetailService.CancelShiftDetail(shiftDetail);
        }
             
    }
    
}
