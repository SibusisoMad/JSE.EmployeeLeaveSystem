using JSE.EmployeeLeaveSystem.Domain.Interface;
using JSE.EmployeeLeaveSystem.Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSE.EmployeeLeaveSystem.ServiceExtension
{
    public  static class AddGeneratedServiceServiceExtension
    {
        public static IServiceCollection AddGeneratedServices(this IServiceCollection services)
        {
            services.AddScoped<ILeaveRequestService, LeaveRequestService>();
            return services;
        }
    }
}
