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

        /// <summary>
        /// Constructor, this gets all the used services or database context i.e UserContext from dependency Injection container
        /// </summary>
        /// <param name="userContext"></param>
        public ShiftDetailService(UserContext userContext)
        {
            _userContext = userContext;
        }

        /// <summary>
        /// Adding Shift Detail
        /// </summary>
        /// <param name="ShiftDetail"></param>
        public void AddShiftDetail(ShiftDetailModel ShiftDetail)
        {
            _userContext.ShiftDetailModels.Add(ShiftDetail);
            _userContext.SaveChanges();
        }

        /// <summary>
        /// Getting all the shifts by user Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public List<ShiftDetailModel> GetAllShiftsForEmployee(int employeeId)
        {
            var shiftSelectedbByEmployee = _userContext.ShiftDetailModels.Include(s => s.Shift).Where(s => s.PickedByEmployee == employeeId)
                .ToList();
            return shiftSelectedbByEmployee;
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="ShiftDetail"></param>
        public void UpdateShiftDetail(ShiftDetailModel ShiftDetail)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="Id"></param>
        public ShiftDetailModel GetShiftDetail(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Hard Deleteing the shift detail from database, when approving cancellation requests
        /// </summary>
        /// <param name="shiftDetail"></param>
        public void DeleteShiftDetail(ShiftDetailModel shiftDetail)
        {
            _userContext.ShiftDetailModels.Remove(shiftDetail);
            _userContext.SaveChanges();
        }

        /// <summary>
        /// Request to cancel a shift
        /// </summary>
        /// <param name="shiftDetail"></param>
        public void CancelShiftDetail(ShiftDetailModel shiftDetail)
        {
            shiftDetail.IsCancelRequest = true;
            _userContext.SaveChanges();
        }

        /// <summary>
        /// Getting the shifts. shift Details those had a cancellation request
        /// </summary>
        /// <returns></returns>
        public List<CancelRequestModel> GetCancelshiftRequests()
        {
            //Join b/w user and shift detail table
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

        /// <summary>
        /// Setting IsCancel Request= false, when disapproving cancellation requests
        /// </summary>
        /// <param name="shiftDetail"></param>
        public void DisapproveCancelShiftDetail(ShiftDetailModel shiftDetail)
        {
            shiftDetail.IsCancelRequest = false;
            _userContext.SaveChanges();
        }

        /// <summary>
        /// Getting all the shifts and shift details from DB.
        /// </summary>
        /// <returns></returns>
        public List <ShiftModel>  GetAllShifts()
        {
            List<ShiftModel> shifts = new List<ShiftModel>();
            shifts = _userContext.ShiftModels.Include(s => s.ShiftDetails).ToList();
            return shifts; 
        }
    }
}
