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
    /// Code behind for ShiftReports components
    /// </summary>
    public class ShiftReportsVM : OwningComponentBase
    {
        private IShiftDetailService ShiftDetailService => ScopedServices.GetService<IShiftDetailService>();
        private IUserService UserService => ScopedServices.GetService<IUserService>();
        private IShiftService ShiftService => ScopedServices.GetService<IShiftService>();

        /// <summary>
        /// Getting the logged in User from the Dependency Inhjection container, which was injected as singleton
        /// </summary>
        [Inject]
        protected LoginModel LoggedInUser { get; set; }

        protected List<ShiftReportModel> AllShiftReports { get; set; } = new List<ShiftReportModel>();
        protected List<ShiftModel> Shifts { get; set; } = new List<ShiftModel>();
        protected async override Task OnInitializedAsync()
        {
            Shifts = ShiftDetailService.GetAllShifts();
            foreach(ShiftModel shift in Shifts)
            {
                foreach (ShiftDetailModel shiftDetails in shift.ShiftDetails)
                {
                    UserModel employee = await UserService.GetUserById(shiftDetails.PickedByEmployee);
                    // creating new aobject of shiftReportModel
                    ShiftReportModel shiftReportModel = new ShiftReportModel();
                    shiftReportModel.FirstName = employee.FirstName;
                    shiftReportModel.LastName = employee.LastName;
                    shiftReportModel.UserName = employee.UserName;
                    shiftReportModel.StartTime = shift.StartTime;
                    shiftReportModel.EndTime = shift.EndTime;
                    shiftReportModel.Date = shift.StartTime.Date;
                    // adding items to shiftReportModel list
                    AllShiftReports.Add(shiftReportModel);
                }
            }
        }
    }
}
