using ShiftPicker.Data.Models;

namespace ShiftPicker.Data.Services
{
    public interface IShiftDetailService
    {
        void AddShiftDetail(ShiftDetailModel ShiftDetail);
        void DeleteShiftDetail(int id);
        ShiftDetailModel GetShiftDetail(int Id);
        void UpdateShiftDetail(ShiftDetailModel ShiftDetail);
    }
}