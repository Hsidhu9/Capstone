using Microsoft.AspNetCore.Mvc;
using ShiftPicker.Data.Models;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftPicker.Data.Controller
{
    public class ShiftDetailController : ControllerBase
    {
        private readonly IShiftDetailService _ShiftDetailService;

        public ShiftDetailController(IShiftDetailService ShiftDetailService)
        {
            _ShiftDetailService = ShiftDetailService;
        }
        // GET: ShiftDetail/Details/5
        [HttpGet]
        public ShiftDetailModel Get(int id)
        {

            return _ShiftDetailService.GetShiftDetail(id);
        }


        // POST: ShiftDetail/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post([FromBody]ShiftDetailModel ShiftDetail)
        {
            try
            {
                _ShiftDetailService.AddShiftDetail(ShiftDetail);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return new ViewResult();
            }
        }

        // GET: ShiftDetail/Edit/5
        public void Edit([FromBody]ShiftDetailModel ShiftDetail)
        {
            _ShiftDetailService.UpdateShiftDetail(ShiftDetail);
        }


        // POST: ShiftDetail/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public void Delete(int id)
        {
            try
            {
                _ShiftDetailService.DeleteShiftDetail(id);

            }
            catch
            {
                throw;
            }
        }
    }
}
