using ShiftPicker.Data;
using ShiftPicker.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ModelServiceCollectionExtensions
    {
        /// <summary>
        /// Adding the Services with Business Logic and Data access as Scoped
        /// </summary>
        /// <param name="services"></param>
        public static void AddServices(this IServiceCollection services) 
        {
            services.AddScoped<IUserService, UserService>()
                    .AddScoped<IUserRoleService, UserRoleService>()
                    .AddScoped<ILoginService, LoginService>()
                    .AddScoped<IShiftService, ShiftService>()
                    .AddScoped<IShiftDetailService, ShiftDetailService>();
        }
    }
}
