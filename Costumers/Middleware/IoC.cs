using Costumers.Services;
using Costumers.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Costumers.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddResgitration (this IServiceCollection services)
        {
            services.AddSingleton<ICostumerService, CostumerService>();
            return services;
        }
    }
}
