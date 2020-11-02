using Shift_Picker.Data.Models;
using ShiftPicker.Data.Models;
using System.Collections.Generic;

namespace ShiftPicker.Data.Services
{
    /// <summary>
    /// Abstraction of Shift Detail Service
    /// </summary>
    public interface IShiftDetailService
    {
        void AddShiftDetail(ShiftDetailModel ShiftDetail);
        void CancelShiftDetail(ShiftDetailModel shiftDetail);
        void DeleteShiftDetail(ShiftDetailModel shiftDetail);
        void DisapproveCancelShiftDetail(ShiftDetailModel shiftDetail);
        List<ShiftDetailModel> GetAllShiftsForEmployee(int employeeId);
        List<CancelRequestModel> GetCancelshiftRequests();
        ShiftDetailModel GetShiftDetail(int Id);
        void UpdateShiftDetail(ShiftDetailModel ShiftDetail);
    }
}