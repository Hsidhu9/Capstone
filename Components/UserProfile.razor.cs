using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using ShiftPicker.Data.Models;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shift_Picker.Components
{
    /// <summary>
    ///  Code behind of User Profile Component
    /// </summary>
    public class UserProfileViewModel : OwningComponentBase
    {
        /// <summary>
        /// Getting the UserService from dependency Injection Container, which was injected as scoped
        /// </summary>
        protected IUserService UserService => ScopedServices.GetService<IUserService>();

        [CascadingParameter]
        protected Task<AuthenticationState> AuthenticationStateTask { get; set; }

        protected UserModel LoggedInUser { get; set; }

        protected override void OnInitialized()
        {
            var authState = AuthenticationStateTask.GetAwaiter().GetResult();
            LoggedInUser = new UserModel();
            foreach(var claim in authState.User.Claims)
            {
                if (claim.Type == ClaimTypes.GivenName)
                    LoggedInUser.FirstName = claim.Value;
                if (claim.Type == ClaimTypes.Surname)
                    LoggedInUser.LastName = claim.Value;
                if (claim.Type == ClaimTypes.StreetAddress)
                    LoggedInUser.Address = claim.Value;
                if (claim.Type == "City")
                    LoggedInUser.City = claim.Value;
                if (claim.Type == ClaimTypes.StateOrProvince)
                    LoggedInUser.State = claim.Value;
                if(claim.Type == ClaimTypes.PostalCode)
                    LoggedInUser.Zip = claim.Value;
                if (claim.Type == ClaimTypes.Country)
                    LoggedInUser.Country = claim.Value;
                if (claim.Type == ClaimTypes.Name)
                    LoggedInUser.UserName = claim.Value;
                if(claim.Type == ClaimTypes.Email)
                    LoggedInUser.Email = claim.Value;
                if (claim.Type == "RoleName")
                {
                    if (LoggedInUser.Role != null)
                        LoggedInUser.Role.RoleName = claim.Value;
                    else
                        LoggedInUser.Role = new UserRole
                        {
                            RoleName = claim.Value
                        };
                }
                if (claim.Type == "RoleId")
                {
                    if (LoggedInUser.Role != null)
                    {
                        LoggedInUser.RoleId = int.Parse(claim.Value);
                        LoggedInUser.Role.Id = int.Parse(claim.Value);
                    }

                    else
                    {
                        LoggedInUser.RoleId = int.Parse(claim.Value);
                        LoggedInUser.Role = new UserRole
                        {
                            Id = int.Parse(claim.Value)
                        };
                    }   
                }
                if (claim.Type == "UserId")
                    LoggedInUser.Id = int.Parse(claim.Value);
                if(claim.Type == "Password")
                    LoggedInUser.Password = claim.Value;
            }
        }

        /// <summary>
        /// Method to update the Logged in User's profile
        /// </summary>
        protected void UpdateEmployee()
        {
            UserService.UpdateUser(LoggedInUser);
        }
    }
}
