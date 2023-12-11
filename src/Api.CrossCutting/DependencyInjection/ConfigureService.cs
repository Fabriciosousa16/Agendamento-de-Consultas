using Api.Service.Services;
using Api.Domain.Interfaces.User;
using Microsoft.Extensions.DependencyInjection;
using Api.Domain.Interfaces.Doctor;
using Api.Domain.Interfaces.Patient;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDepedenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IDoctorService, DoctorService>();
            serviceCollection.AddTransient<IPatientService, PatientService>();
        }
    }
}
