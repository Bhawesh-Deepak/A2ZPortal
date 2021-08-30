using System.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using Serilog;

namespace A2ZAdmin.UI
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.MSSqlServer(
                    connectionString: "Server=116.193.134.160,1433;Database=A2Zportal_Development; User Id=SqlAdmin;Password=SqlAdmin@123",
                    tableName: "A2ZLogging",
                    appConfiguration: configuration,
                    autoCreateSqlTable: true,
                    columnOptionsSection: configuration.GetSection("Serilog:ColumnOptions"),
                    schemaName: "Serilog SchemaName")
                        .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
