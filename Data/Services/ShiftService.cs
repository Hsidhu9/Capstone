using Microsoft.EntityFrameworkCore;
using ShiftPicker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftPicker.Data.Services
{
    public class ShiftService : IShiftService
    {
        private readonly UserContext _userContext;

        public ShiftService(UserContext userContext)
        {
            _userContext = userContext;
        }
        public void AddShift(ShiftModel Shift)
        {
            _userContext.ShiftModels.Add(Shift);
            _userContext.SaveChanges();
        }

        public void UpdateShift(ShiftModel Shift)
        {
            throw new NotImplementedException();
        }

        public List<ShiftModel> GetShiftsForDateRange(DateTime startDateTime, DateTime endDateTime)
        {
            return _userContext
                .ShiftModels
                .Include(s => s.ShiftDetails)
                .Where(s => s.StartTime >= startDateTime && s.EndTime <= endDateTime)
                .ToList();
        }

        public void DeleteShift(int id)
        {
            throw new NotImplementedException();
        }
    }
}
