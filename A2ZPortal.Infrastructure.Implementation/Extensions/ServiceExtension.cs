using A2ZPortal.Infrastructure.Implementation.CustomersImplementation;
using A2ZPortal.Infrastructure.Implementation.GenericImplementation;
using A2ZPortal.Infrastructure.Implementation.HomeDetail;
using A2ZPortal.Infrastructure.Implementation.PropertyImplementation;
using A2ZPortal.Infrastructure.Implementation.UserManagement;
using A2ZPortal.Infrastructure.Repository.CustomerRepository;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using A2ZPortal.Infrastructure.Repository.HomeDetailRepository;
using A2ZPortal.Infrastructure.Repository.PropertyDetailRepository;
using A2ZPortal.Infrastructure.Repository.UserManagement;
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
            services.AddTransient<IPropertyDetailRepository, PropertyDetailImplementation>();
            services.AddTransient<IUserManagementRepository, UserManagementImplementation>();
            services.AddTransient<IPropertyDashBoradRepository, PropertyDashBoradImplementation>();
            services.AddTransient<IPropertyDetailCompleteRepository, PropertyDetailCompleteImplementation>();
            services.AddTransient<ITestimonialRepository, TestimonialImplimentation>();
            services.AddTransient<IOrderTransactionRepository, OrderTransactionImplementation>();
            services.AddTransient<IHomeDetailRepository, HomeDetailImplementation>();
            services.AddTransient<IVirtualImageRepository, VirtualImageImplementation>();
        }
    }
}