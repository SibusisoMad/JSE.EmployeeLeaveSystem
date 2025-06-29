using JSE.EmployeeLeaveSystem.Dal.Interface;
using JSE.EmployeeLeaveSystem.Dal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSE.EmployeeLeaveSystem.ServiceExtension
{
    public static class AddGeneratedRepositoriesServiceExtension
    {
        public static IServiceCollection AddGeneratedRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            return services;
        }
    }
}
