using Microsoft.AspNetCore.Components.Authorization;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shift_Picker
{
    public class ShiftPickerCustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILoginService _loginService;

        public ShiftPickerCustomAuthenticationStateProvider(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }

        public void MarkUserAsAuthenticated(string userName, string password)
        {
            var loginModel = _loginService.Authenticate(userName, password);

            if(loginModel != null)
            {
                var identity = new ClaimsIdentity(new[] { 
                    new Claim(ClaimTypes.Name, loginModel.User.UserName),
                    new Claim(ClaimTypes.GivenName, loginModel.User.FirstName),
                    new Claim(ClaimTypes.Surname, loginModel.User.LastName),
                    new Claim("RoleId", loginModel.User.RoleId.ToString())
                }, "apiauth_type");
                var user = new ClaimsPrincipal(identity);
                NotifyAuthenticationStateChanged( Task.FromResult(new AuthenticationState(user)));
            }
        }
    }
}
