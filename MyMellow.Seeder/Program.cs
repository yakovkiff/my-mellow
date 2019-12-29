using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;
using MyMellow.DbContext;

namespace MyMellow.Seeder
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = GetConfiguration("MyMellow.Api", "appsettings.json");

            // var appSettingsSection = configuration.GetSection(nameof(AppSettings));
            // services.Configure<AppSettings>(option => appSettingsSection.Bind(option));
            // var settings = appSettingsSection.Get<AppSettings>();

            var connectionStr = configuration.GetConnectionString("MyMellowDb");
            Console.WriteLine($"Connection string: {connectionStr}");
            var optionsBuilder = new DbContextOptionsBuilder<MyMellowContext>();
            optionsBuilder.UseNpgsql(connectionStr);

            using (var context = new MyMellowContext(optionsBuilder.Options))
            {
                Console.WriteLine("Deleting database...");
                context.Database.EnsureDeleted();
                Console.WriteLine("Executing migrations...");
                context.Database.Migrate();
                Console.WriteLine("Seeding database...");
                context.SeedSampleData();
                Console.WriteLine("Done.");
            }
        }

        private static IConfigurationRoot GetConfiguration(string path, string jsonFileName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var directory = currentDirectory + "/" + path;

            var configuration = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile(jsonFileName, true)
                .Build();

            return configuration;
        }

    }
}
