using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AC.Components.Util;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhiteUnitySpa.Common;

namespace WhiteUnitySpa
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEnvironmentConfiguration<Startup>(() => new EnvironmentChooser("Development").Add("localhost", "Development"));
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}