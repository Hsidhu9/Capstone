using ShiftPicker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftPicker.Data.Services
{
    public class ShiftDetailDetailService : IShiftDetailService
    {
        private readonly UserContext _userContext;

        public ShiftDetailDetailService(UserContext userContext)
        {
            _userContext = userContext;
        }
        public void AddShiftDetail(ShiftDetailModel ShiftDetail)
        {
            _userContext.ShiftDetailModels.Add(ShiftDetail);
            _userContext.SaveChanges();
        }

        public void UpdateShiftDetail(ShiftDetailModel ShiftDetail)
        {
            throw new NotImplementedException();
        }

        public ShiftDetailModel GetShiftDetail(int Id)
        {
            return new ShiftDetailModel();
        }

        public void DeleteShiftDetail(int id)
        {
            throw new NotImplementedException();
        }
    }
}
