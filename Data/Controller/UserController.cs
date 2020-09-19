using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftPicker.Data.Models;

namespace ShiftPicker.Data.Controller
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: User/Details/5
        [HttpGet]
        public UserModel Get(int id)
        {

            return _userService.GetUser(id);
        }


        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post([FromBody]UserModel user)
        {
            try
            {
                _userService.AddUser(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return new ViewResult();
            }
        }

        // GET: User/Edit/5
        public void Edit([FromBody]UserModel user)
        {
            _userService.UpdateUser(user);
        }


        // POST: User/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public void Delete(int id)
        {
            try
            {
                _userService.DeleteUser(id);

            }
            catch
            {
                throw;
            }
        }
    }
}