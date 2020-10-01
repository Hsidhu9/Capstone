using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace Shift_Picker.Components 
{
    public partial class ScheduleVM: OwningComponentBase
    {
        public string BeginOfWeek { get; set; }
        public string EndOfWeek { get; set; }
        public string Day1Week { get; set; }
        public string Day2Week { get; set; }
        public string Day3Week { get; set; }
        public string Day4Week { get; set; }
        public string Day5Week { get; set; }
        public string Day6Week { get; set; }
        public string Day7Week { get; set; }

        public DateTime Today { get; set; }

        private DateTime BeginOfWeekDateTime { get; set; }

        private DateTime EndOfWeekDateTime { get; set; }

        [Inject]
        protected IModalService ModalService { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Today = DateTime.Now;
            BeginOfWeekDateTime = DateTime.Now.AddDays(-(int)Today.DayOfWeek);
            EndOfWeekDateTime = DateTime.Now.AddDays(6 - (int)Today.DayOfWeek);
            BeginOfWeek = BeginOfWeekDateTime.ToString("MM/dd/yyyy");
            EndOfWeek = EndOfWeekDateTime.ToString("MM/dd/yyyy");
            Day1Week = BeginOfWeekDateTime.ToString("MM/dd/yyyy");
            Day2Week = BeginOfWeekDateTime.AddDays(1).ToString("MM/dd/yyyy");
            Day3Week = BeginOfWeekDateTime.AddDays(2).ToString("MM/dd/yyyy");
            Day4Week = BeginOfWeekDateTime.AddDays(3).ToString("MM/dd/yyyy");
            Day5Week = BeginOfWeekDateTime.AddDays(4).ToString("MM/dd/yyyy");
            Day6Week = BeginOfWeekDateTime.AddDays(5).ToString("MM/dd/yyyy");
            Day7Week = BeginOfWeekDateTime.AddDays(6).ToString("MM/dd/yyyy");


        }
        
        protected void GetNextWeek()
        {
            DateTime sevenDaysFromPreviousWeek = EndOfWeekDateTime.AddDays(1);
            BeginOfWeekDateTime = sevenDaysFromPreviousWeek;
            EndOfWeekDateTime = sevenDaysFromPreviousWeek.AddDays(6);
            BeginOfWeek = BeginOfWeekDateTime.ToString("MM/dd/yyyy");
            EndOfWeek = EndOfWeekDateTime.ToString("MM/dd/yyyy");
            Day1Week = BeginOfWeekDateTime.ToString("MM/dd/yyyy");
            Day2Week = BeginOfWeekDateTime.AddDays(1).ToString("MM/dd/yyyy");
            Day3Week = BeginOfWeekDateTime.AddDays(2).ToString("MM/dd/yyyy");
            Day4Week = BeginOfWeekDateTime.AddDays(3).ToString("MM/dd/yyyy");
            Day5Week = BeginOfWeekDateTime.AddDays(4).ToString("MM/dd/yyyy");
            Day6Week = BeginOfWeekDateTime.AddDays(5).ToString("MM/dd/yyyy");
            Day7Week = BeginOfWeekDateTime.AddDays(6).ToString("MM/dd/yyyy");

        }

        protected void GetLastWeek()
        {
            DateTime sevenDaysFromNextWeek = BeginOfWeekDateTime.AddDays(-7);
            BeginOfWeekDateTime = sevenDaysFromNextWeek;
            EndOfWeekDateTime = sevenDaysFromNextWeek.AddDays(6);
            BeginOfWeek = BeginOfWeekDateTime.ToString("MM/dd/yyyy");
            EndOfWeek = EndOfWeekDateTime.ToString("MM/dd/yyyy");
            Day1Week = BeginOfWeekDateTime.ToString("MM/dd/yyyy");
            Day2Week = BeginOfWeekDateTime.AddDays(1).ToString("MM/dd/yyyy");
            Day3Week = BeginOfWeekDateTime.AddDays(2).ToString("MM/dd/yyyy");
            Day4Week = BeginOfWeekDateTime.AddDays(3).ToString("MM/dd/yyyy");
            Day5Week = BeginOfWeekDateTime.AddDays(4).ToString("MM/dd/yyyy");
            Day6Week = BeginOfWeekDateTime.AddDays(5).ToString("MM/dd/yyyy");
            Day7Week = BeginOfWeekDateTime.AddDays(6).ToString("MM/dd/yyyy");

        }

        protected void OpenManageShiftsModal()
        {
            ModalService.Show<ManageShiftModal>("Manage Shifts");
        }
    }
}
