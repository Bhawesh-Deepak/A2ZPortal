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
        //public static void AddElasticSearchExtension(this IServiceCollection service, IConfiguration configuration)
        //{
        //    var url = configuration.GetSection("").Value;
        //    var defaultIndex = configuration.GetSection("").Value;

        //    var setting = new ConnectionSettings(new Uri(url)).DefaultIndex(defaultIndex);

        //    var client = new ElasticClient(setting);

        //    service.AddSingleton(client);

        //    CreateIndex(client, defaultIndex);

        //}

        //private static void CreateIndex(ElasticClient client, string defaultIndex)
        //{
        //    var createIndexResponse = client.Indices.Create(defaultIndex,
        //         index => index.Map<PropertyDetail>(x => x.AutoMap())
        //     );
        //}

        //private static void AddDefaultMapping(ConnectionSettings setting)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
