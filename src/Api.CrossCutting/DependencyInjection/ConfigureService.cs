using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Service.Services;
using Api.Domain.Interfaces.User;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDepedenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
        }
    }
}
