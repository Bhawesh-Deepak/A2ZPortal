using A2ZPortal.Core.Entities.Property;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZAdmin.UI.Helper
{
    public static class ElasticSearchHelper
    {
        public static void AddElasticSearchExtension(this IServiceCollection service, IConfiguration configuration)
        {
            var url = configuration.GetSection("elasticsearch:url").Value;
            var defaultIndex = configuration.GetSection("elasticsearch:index").Value;

            var setting = new ConnectionSettings(new Uri(url)).DefaultIndex(defaultIndex);

            var client = new ElasticClient(setting);

            service.AddSingleton<IElasticClient>(client);
        }
    }
}
