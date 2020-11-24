using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using ShiftPicker.Data.Models;
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
        private readonly IUserService _userService;
        private readonly ISessionStorageService _sessionStorageService;

        public ShiftPickerCustomAuthenticationStateProvider(ILoginService loginService,
            IUserService userService,
            ISessionStorageService sessionStorageService)
        {
            _loginService = loginService;
            _userService = userService;
            _sessionStorageService = sessionStorageService;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var loggedinUserName = await _sessionStorageService.GetItemAsync<string>("userName");
            UserModel loggedinUser = null;
            if (!string.IsNullOrEmpty(loggedinUserName))
            {
                loggedinUser= await _userService.GetUserByUsername(loggedinUserName);
            }
            ClaimsIdentity identity;
            if(loggedinUser != null)
            {
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, loggedinUser.UserName),
                    new Claim(ClaimTypes.GivenName, loggedinUser.FirstName),
                    new Claim(ClaimTypes.Surname, loggedinUser.LastName),
                    new Claim("RoleId", loggedinUser.RoleId.ToString())
                }, "apiauth_type");
            }
            else
            {
                 identity = new ClaimsIdentity();
            }
            var user = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(user));
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
