using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShiftPicker.Data.Models;
using ShiftPicker.Data.Services;

namespace ShiftPicker.Data.Controller
{
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _ShiftService;

        public ShiftController(IShiftService ShiftService)
        {
            _ShiftService = ShiftService;
        }
        // GET: Shift/Details/5
        [HttpGet]
        public ShiftModel Get(int id)
        {

            return new ShiftModel();
        }


        // POST: Shift/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post([FromBody]ShiftModel Shift)
        {
            try
            {
                _ShiftService.AddShift(Shift);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return new ViewResult();
            }
        }

        // GET: Shift/Edit/5
        public void Edit([FromBody]ShiftModel Shift)
        {
            _ShiftService.UpdateShift(Shift);
        }


        // POST: Shift/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public void Delete(int id)
        {
            try
            {
                _ShiftService.DeleteShift(id);

            }
            catch
            {
                throw;
            }
        }
    }
}