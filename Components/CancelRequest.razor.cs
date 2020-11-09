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
    /// <summary>
    /// Code behind for Cancel Shift Component
    /// </summary>
    public class CancelRequestVM : OwningComponentBase
    {
        /// <summary>
        /// All the Shifts Selected by the Logged In User, this is populated from db upon page load
        /// </summary>
        private IShiftDetailService ShiftDetailService => ScopedServices.GetService<IShiftDetailService>();

        /// <summary>
        /// All the cancellation requests, these are populated upon page load from db
        /// </summary>
        protected List<CancelRequestModel> AllCancellationRequests { get; set; } = new List<CancelRequestModel>();
        /// <summary>
        /// This method is called when the page is loaded
        /// </summary>
        protected override void OnInitialized()
        {
            AllCancellationRequests = ShiftDetailService.GetCancelshiftRequests();
        }

        /// <summary>
        /// Method to Approve the Cancellation as a supervisor/manager
        /// </summary>
        /// <param name="shiftDetailModel"></param>
        protected void ApproveCancellation(ShiftDetailModel shiftDetailModel)
        {
            //delete the shift details
            ShiftDetailService.DeleteShiftDetail(shiftDetailModel);

        }

        /// <summary>
        /// Method to Disapprove the Cancellation as a supervisor/manager
        /// </summary>
        /// <param name="shiftDetailModel"></param>
        protected void DisapproveCancellation(ShiftDetailModel shiftDetailModel)
        {
            //set the iscancelRequest of the shiftdetail to false
            ShiftDetailService.DisapproveCancelShiftDetail(shiftDetailModel);
        }
    }
}
