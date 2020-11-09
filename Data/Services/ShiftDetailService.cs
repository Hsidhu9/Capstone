using Microsoft.EntityFrameworkCore;
using Shift_Picker.Data.Models;
using ShiftPicker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftPicker.Data.Services
{
    public class ShiftDetailService : IShiftDetailService
    {
        private readonly UserContext _userContext;

        public ShiftDetailService(UserContext userContext)
        {
            _userContext = userContext;
        }
        public void AddShiftDetail(ShiftDetailModel ShiftDetail)
        {
            _userContext.ShiftDetailModels.Add(ShiftDetail);
            _userContext.SaveChanges();
        }

        public List<ShiftDetailModel> GetAllShiftsForEmployee(int employeeId)
        {
            var shiftSelectedbByEmployee = _userContext.ShiftDetailModels.Include(s => s.Shift).Where(s => s.PickedByEmployee == employeeId)
                .ToList();
            return shiftSelectedbByEmployee;
        }
        public void UpdateShiftDetail(ShiftDetailModel ShiftDetail)
        {
            throw new NotImplementedException();
        }

        public ShiftDetailModel GetShiftDetail(int Id)
        {
            return new ShiftDetailModel();
        }

        public void DeleteShiftDetail(ShiftDetailModel shiftDetail)
        {
            _userContext.ShiftDetailModels.Remove(shiftDetail);
            _userContext.SaveChanges();
        }

        public void CancelShiftDetail(ShiftDetailModel shiftDetail)
        {
            shiftDetail.IsCancelRequest = true;
            _userContext.SaveChanges();
        }

        public List<CancelRequestModel> GetCancelshiftRequests()
        {
            var cancelShiftRequests = _userContext.ShiftDetailModels.Include(s => s.Shift).Join(_userContext.UserModels,
                shiftDetail => shiftDetail.PickedByEmployee,
                user => user.Id,
                (shiftDetail, user) =>
                new {
                    shiftDetail,
                    user
                }).
                Where(s => s.shiftDetail.IsCancelRequest == true)
                .ToList();
            List<CancelRequestModel> cancelRequestModels = new List<CancelRequestModel>();

            foreach(var cancelShiftRequest in cancelShiftRequests)
            {
                var cancelRequestModel = new CancelRequestModel
                {

                    ShiftDetails = cancelShiftRequest.shiftDetail,
                    UserName = cancelShiftRequest.user.UserName,
                    UserId = cancelShiftRequest.user.Id
                };
                cancelRequestModels.Add(cancelRequestModel);
            }

            return cancelRequestModels;
        }

        public void DisapproveCancelShiftDetail(ShiftDetailModel shiftDetail)
        {
            shiftDetail.IsCancelRequest = false;
            _userContext.SaveChanges();
        }
    }
}
