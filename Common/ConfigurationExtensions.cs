using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WhiteUnitySpa.Common
{
    public static class ConfigurationExtensions
    {
        public static void AddEnvironmentConfiguration<TResource>(
            this IServiceCollection serviceCollection,
            Func<EnvironmentChooser> environmentChooserFactory)
        {
            serviceCollection.AddSingleton<IConfiguration>((s) =>
            {
                var environementChooser = environmentChooserFactory();
                var uri = new Uri(s.GetRequiredService<IUriHelper>().GetAbsoluteUri());
                System.Reflection.Assembly assembly = typeof(TResource).Assembly;
                string environment = environementChooser.GetCurrent(uri);
                var ressourceNames = new[]
                {
                    assembly.GetName().Name + ".Configuration.appsettings.json",
                    assembly.GetName().Name + ".Configuration.appsettings." + environment + ".json"
                };
                
                ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddInMemoryCollection(new Dictionary<string, string>()
                {
                    { "Environment", environment } 
                });

                Console.WriteLine(string.Join(",", assembly.GetManifestResourceNames()));
                Console.WriteLine(string.Join(",", ressourceNames));
                foreach (var resource in ressourceNames)
                {
                    if (assembly.GetManifestResourceNames().Contains(resource))
                    {
                        configurationBuilder.AddJsonFile(
                            new InMemoryFileProvider(assembly.GetManifestResourceStream(resource)), resource, false, false);
                    }
                    else
                    {
                        Console.WriteLine($"Warning, not found file: {resource}");
                    }
                }
                return configurationBuilder.Build();
            });
        }
    }
}