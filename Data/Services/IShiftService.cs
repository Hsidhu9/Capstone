using ShiftPicker.Data.Models;
using System;
using System.Collections.Generic;

namespace ShiftPicker.Data.Services
{
    /// <summary>
    /// Abstraction of Shift Service
    /// </summary>
    public interface IShiftService
    {
        void AddShift(ShiftModel Shift);
        void DeleteShift(int id);
        List<ShiftModel> GetShiftsForDateRange(DateTime startDateTime, DateTime endDateTime);
        void UpdateShift(ShiftModel Shift);
    }
}