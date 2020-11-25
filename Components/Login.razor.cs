using Microsoft.AspNetCore.Components;
using ShiftPicker.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Shift_Picker.Components
{
    /// <summary>
    /// Code behind of Login Component
    /// </summary>
    public class LoginVM : OwningComponentBase
    {
        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        /// <summary>
        /// Getting the LoginService from dependency Injection Container, which was injected as scoped
        /// </summary>
        private ILoginService LoginService => ScopedServices.GetService<ILoginService>();

        /// <summary>
        /// The User To be constructed to Log In
        /// </summary>
        protected UserModel User { get; set; }

        
        /// <summary>
        /// The Navigation Manager that is given by the Framework to navigat from one page to another
        /// </summary>
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected ISessionStorageService SessionStorageService { get; set; }
        /// <summary>
        /// This method is called when the page is loaded
        /// </summary>
        protected async override Task OnInitializedAsync()
        {
            User = new UserModel();
        }

        [CascadingParameter]
        protected Task<AuthenticationState> AuthenticationStateTask { get; set; }

        /// <summary>
        /// Validating the User and then Logging them based upon the validation
        /// </summary>
        protected async Task ValidateUser()
        {
            ((ShiftPickerCustomAuthenticationStateProvider)AuthenticationStateProvider).MarkUserAsAuthenticated(User.UserName, User.Password);
            NavigationManager.NavigateTo("/");

            var authState = await AuthenticationStateTask;

            if(authState.User.HasClaim(s => s.Type.Equals(ClaimTypes.Name)))
                await SessionStorageService.SetItemAsync("username", User.UserName);
        }
    }

}





