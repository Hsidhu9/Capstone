using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.DependencyInjection;
using ShiftPicker.Data.Models;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace Shift_Picker.Components 
{
    /// <summary>
    ///  Code behind of Schedules Component
    /// </summary>
    public partial class ScheduleVM : OwningComponentBase
    {
        #region DaysAndWeeks
        public string BeginOfWeek { get; set; }
        public string EndOfWeek { get; set; }
        public DateTime Day1Week { get; set; }
        public DateTime Day2Week { get; set; }
        public DateTime Day3Week { get; set; }
        public DateTime Day4Week { get; set; }
        public DateTime Day5Week { get; set; }
        public DateTime Day6Week { get; set; }
        public DateTime Day7Week { get; set; }

        public DateTime Today { get; set; }

        private DateTime BeginOfWeekDateTime { get; set; }

        private DateTime EndOfWeekDateTime { get; set; }



        protected int[] allDayHours = new int[24];

        public List<DateTime> AllDaysOfWeek
        {
            get
            {
                return new List<DateTime>
                { Day1Week,Day2Week, Day3Week, Day4Week, Day5Week, Day6Week, Day7Week };
            }
        }



        protected DateTime CreatedStartDateTime { get; set; }

        protected DateTime CreatedEndDateTime { get; set; }

        protected int NumberOfEmployeesNeeded { get; set; }
        #endregion
        protected string ErrorMessage { get; set; }

        protected List<ShiftModel> AllAvailableShifts{get;set;}

        [Inject]
        protected LoginModel LoggedInUser { get; set; }
        protected Dictionary<string,int?> SelectedShiftsElementIds { get; set; } = new Dictionary<string, int?>();

        private IShiftService ShiftService => ScopedServices.GetService<IShiftService>();

        private IShiftDetailService ShiftDetailService => ScopedServices.GetService<IShiftDetailService>();
        protected override void OnInitialized()
        {
            SetGrid();
            SetAllHours();
            PopulateShifts();
        }
        
        /// <summary>
        /// Populating all the shifts created for the week in display
        /// </summary>

        private void PopulateShifts()
        {
            AllAvailableShifts = ShiftService.GetShiftsForDateRange(Day1Week, Day7Week.AddHours(24));
            foreach(var shift in AllAvailableShifts)
            {
                for (int i = shift.StartTime.Hour; i < shift.EndTime.Hour; i++)
                {
                    if(!SelectedShiftsElementIds.ContainsKey(shift.StartTime.Date.ToString() + i))
                        SelectedShiftsElementIds.Add(shift.StartTime.Date.ToString() + i, shift.Id);
                }
            }
        }
        protected void SetAllHours()
        {
            int i = 0;
            foreach (var x in allDayHours)
            {
                allDayHours[i] = i;
                i++;
            }
        }

        protected void SetGrid()
        {
            var currentTimeZone = TimeZoneInfo.FindSystemTimeZoneById("US Mountain Standard Time");
            Today = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, currentTimeZone);
            BeginOfWeekDateTime = Today.AddDays(-(int)Today.DayOfWeek).Date;
            EndOfWeekDateTime = Today.AddDays(6 - (int)Today.DayOfWeek).Date;
            BeginOfWeek = BeginOfWeekDateTime.ToString("M");
            EndOfWeek = EndOfWeekDateTime.ToString("M");
            Day1Week = BeginOfWeekDateTime.Date;
            Day2Week = BeginOfWeekDateTime.AddDays(1);
            Day3Week = BeginOfWeekDateTime.AddDays(2);
            Day4Week = BeginOfWeekDateTime.AddDays(3);
            Day5Week = BeginOfWeekDateTime.AddDays(4);
            Day6Week = BeginOfWeekDateTime.AddDays(5);
            Day7Week = BeginOfWeekDateTime.AddDays(6);
        }
        
        protected void GetNextWeek()
        {
            DateTime sevenDaysFromPreviousWeek = EndOfWeekDateTime.AddDays(1);
            BeginOfWeekDateTime = sevenDaysFromPreviousWeek.Date;
            EndOfWeekDateTime = sevenDaysFromPreviousWeek.AddDays(6).Date;
            BeginOfWeek = BeginOfWeekDateTime.ToString("M");
            EndOfWeek = EndOfWeekDateTime.ToString("M");
            Day1Week = BeginOfWeekDateTime;
            Day2Week = BeginOfWeekDateTime.AddDays(1);
            Day3Week = BeginOfWeekDateTime.AddDays(2);
            Day4Week = BeginOfWeekDateTime.AddDays(3);
            Day5Week = BeginOfWeekDateTime.AddDays(4);
            Day6Week = BeginOfWeekDateTime.AddDays(5);
            Day7Week = BeginOfWeekDateTime.AddDays(6);
            PopulateShifts();
        }

        protected void GetLastWeek()
        {
            DateTime sevenDaysFromNextWeek = BeginOfWeekDateTime.AddDays(-7);
            BeginOfWeekDateTime = sevenDaysFromNextWeek.Date;
            EndOfWeekDateTime = sevenDaysFromNextWeek.AddDays(6).Date;
            BeginOfWeek = BeginOfWeekDateTime.ToString("M");
            EndOfWeek = EndOfWeekDateTime.ToString("M");
            Day1Week = BeginOfWeekDateTime;
            Day2Week = BeginOfWeekDateTime.AddDays(1);
            Day3Week = BeginOfWeekDateTime.AddDays(2);
            Day4Week = BeginOfWeekDateTime.AddDays(3);
            Day5Week = BeginOfWeekDateTime.AddDays(4);
            Day6Week = BeginOfWeekDateTime.AddDays(5);
            Day7Week = BeginOfWeekDateTime.AddDays(6);
            PopulateShifts();
        }

        protected void AddShifts(DateTime startDateTime, DateTime endDateTime , int numberOfEmployeedNeeded)
        {
            ShiftModel shiftModel = new ShiftModel()
            {
                StartTime = startDateTime,
                EndTime = endDateTime,
                EmployeesNeeded = numberOfEmployeedNeeded,
                CreatedBy = LoggedInUser.User.Id
            };

            ShiftService.AddShift(shiftModel);
        }

        protected void SelectedShiftAsEmployee(int shiftId)
        {
            if(LoggedInUser.User.RoleId == 4)
            {
                ShiftDetailModel shiftDetail = new ShiftDetailModel
                {
                    PickedByEmployee = LoggedInUser.User.Id,
                    ShiftId = shiftId
                };

                ShiftDetailService.AddShiftDetail(shiftDetail);

            }

        }

    }
}
