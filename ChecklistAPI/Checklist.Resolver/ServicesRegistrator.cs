using Checklist.DataLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.Resolver
{
    public class ServicesRegistrator
    {
        public static void RegisterServices(IServiceCollection services)
        {

        }

        public static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DefaultContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbDefault"));
            });
        }
    }
}
