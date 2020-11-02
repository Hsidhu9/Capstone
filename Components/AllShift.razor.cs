﻿using Microsoft.AspNetCore.Components;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShiftPicker.Data.Models;

namespace Shift_Picker.Components
{
    public class AllShiftVM : OwningComponentBase
    {
        private IShiftDetailService ShiftDetailService => ScopedServices.GetService<IShiftDetailService>();
        protected List<ShiftModel> AllShifts { get; set; } = new List<ShiftModel>();

        protected List<ShiftDetailModel> AllShiftDetails { get; set; } = new List<ShiftDetailModel>();
        [Inject]
        protected LoginModel LoggedInUser { get; set; }
        protected override void OnInitialized()
        {
            AllShiftDetails =  ShiftDetailService.GetAllShiftsForEmployee(LoggedInUser.User.Id);
            AllShifts = AllShiftDetails.Select(s => s.Shift).ToList();
        }
        
        protected void CancelShiftDetails(ShiftDetailModel shiftDetail)
        {
            ShiftDetailService.CancelShiftDetail(shiftDetail);
        }
             
    }
    
}
