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

        /// <summary>
        /// The UserContext (Database context) is passed to the constrcutor from Dependency injection container, 
        /// also known as IServiceCollection, We had added the DbContext in Startup.cs as services.AddDbContext()
        /// </summary>
        /// <param name="userContext"></param>
        public ShiftService(UserContext userContext)
        {
            _userContext = userContext;
        }

        /// <summary>
        /// Adding shift, when shift is created by supervisor/manager
        /// </summary>
        /// <param name="Shift"></param>
        public ShiftModel AddShift(ShiftModel Shift)
        {
          var x = _userContext.ShiftModels.Add(Shift);
            _userContext.SaveChanges();
            return x.Entity;
        }
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="Shift"></param>
        public void UpdateShift(ShiftModel Shift)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Getting shifts, shift details for a date range
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public List<ShiftModel> GetShiftsForDateRange(DateTime startDateTime, DateTime endDateTime)
        {
            return _userContext
                .ShiftModels
                .Include(s => s.ShiftDetails)
                .Where(s => s.StartTime >= startDateTime && s.EndTime <= endDateTime)
                .ToList();
        }

        /// <summary>
        /// Not implemented yet
        /// </summary>
        /// <param name="id"></param>
        public void DeleteShift(int id)
        {
            throw new NotImplementedException();
        }
    }
}
