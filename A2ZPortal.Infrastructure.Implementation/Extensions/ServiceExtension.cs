using A2ZPortal.Infrastructure.Implementation.GenericImplementation;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using Microsoft.Extensions.DependencyInjection;

namespace A2ZPortal.Infrastructure.Implementation.Extensions
{
    /// <summary>
    ///     Helper method for service Extension,
    ///     So that we have to configure all the extension in this method
    /// </summary>
    public static class ServiceExtension
    {
        public static void ServiceExtensionHelper(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericImplementationDetail<,>));
        }
    }
}