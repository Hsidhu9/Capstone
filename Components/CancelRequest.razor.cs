using Microsoft.AspNetCore.Components;
using Shift_Picker.Data.Models;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using ShiftPicker.Data.Models;

namespace Shift_Picker.Components
{
    public class CancelRequestVM : OwningComponentBase
    {
        private IShiftDetailService ShiftDetailService => ScopedServices.GetService<IShiftDetailService>();
        protected List<CancelRequestModel> AllCancellationRequests { get; set; } = new List<CancelRequestModel>();

        protected override void OnInitialized()
        {
            AllCancellationRequests = ShiftDetailService.GetCancelshiftRequests();
        }

        protected void ApproveCancellation(ShiftDetailModel shiftDetailModel)
        {
            //delete the shift details
            ShiftDetailService.DeleteShiftDetail(shiftDetailModel);

        }

        protected void DisapproveCancellation(ShiftDetailModel shiftDetailModel)
        {
            //set the iscancelRequest of the shiftdetail to false
            ShiftDetailService.DisapproveCancelShiftDetail(shiftDetailModel);
        }
    }
}
