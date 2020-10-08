using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShiftPicker.Data.Models;
using ShiftPicker.Data.Services;

namespace ShiftPicker.Data.Controller
{
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _authenticationService;

        public LoginController(ILoginService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost]
        public bool Authenticate([FromBody]LoginModel loginModel)
        {
            return _authenticationService.Authenticate();
        }
    }
}