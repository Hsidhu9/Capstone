using ShiftPicker.Data.Models;

namespace ShiftPicker.Data.Services
{
    /// <summary>
    /// Abstraction of Shift Detail Service
    /// </summary>
    public interface IShiftDetailService
    {
        void AddShiftDetail(ShiftDetailModel ShiftDetail);
        void DeleteShiftDetail(int id);
        ShiftDetailModel GetShiftDetail(int Id);
        void UpdateShiftDetail(ShiftDetailModel ShiftDetail);
    }
}