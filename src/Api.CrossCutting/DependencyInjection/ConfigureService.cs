using Api.Service.Services;
using Api.Domain.Interfaces.User;
using Microsoft.Extensions.DependencyInjection;
using Api.Domain.Interfaces.Doctor;
using Api.Domain.Interfaces.Patient;
using Api.Domain.Interfaces.Query;
using Api.Domain.Interfaces.QueryPartient;
using Api.Domain.Interfaces.Services.User;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDepedenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ILoginService, LoginService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IDoctorService, DoctorService>();
            serviceCollection.AddTransient<IPatientService, PatientService>();
            serviceCollection.AddTransient<IQueryService, QueryService>();
            serviceCollection.AddTransient<IQueryPartientService, QueryPartientService>();

        }
    }
}
