﻿using Microsoft.AspNetCore.Components;
using ShiftPicker.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shift_Picker.Components
{
    /// <summary>
    /// Code behind of Login Component
    /// </summary>
    public class LoginVM : OwningComponentBase
    {
        /// <summary>
        /// Getting the LoginService from dependency Injection Container, which was injected as scoped
        /// </summary>
        private ILoginService LoginService => ScopedServices.GetService<ILoginService>();

        /// <summary>
        /// The User To be constructed to Log In
        /// </summary>
        protected UserModel User { get; set; }

        /// <summary>
        /// The LoginModel, this is null, when the user isn't logged in
        /// </summary>
        [Inject]
        protected LoginModel LoggingInUser { get; set; }
        /// <summary>
        /// The Navigation Manager that is given by the Framework to navigat from one page to another
        /// </summary>
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        /// <summary>
        /// This method is called when the page is loaded
        /// </summary>
        protected async override Task OnInitializedAsync()
        {
            User = new UserModel();
        }

        /// <summary>
        /// Validating the User and then Logging them based upon the validation
        /// </summary>
        protected  void ValidateUser()
        {
            LoggingInUser.User = User;
            LoginService.Authenticate();
            NavigationManager.NavigateTo(NavigationManager.BaseUri, true);
            return;
        }
    }

}





