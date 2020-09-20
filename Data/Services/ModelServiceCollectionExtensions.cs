using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        public static void AddServices(this IServiceCollection services) git push --set-upstream origin fix_project
        {
            services.AddScoped<IUserService, UserService>()
                    .AddScoped<IUserRoleService, UserRoleService>();
        }
    }
}
