using ShiftPicker.Data.Models;

namespace ShiftPicker.Data.Services
{
    public interface IShiftService
    {
        void AddShift(ShiftModel Shift);
        void DeleteShift(int id);
        ShiftModel GetShift(int Id);
        void UpdateShift(ShiftModel Shift);
    }
}