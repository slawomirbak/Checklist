using AutoMapper;
using Checklist.Abstract.IServices;
using Checklist.DataLogic;
using Checklist.DataLogic.Repository.UnitOfWork;
using Checklist.DataLogic.Repository.UserRepository;
using Checklist.Services.Mapper;
using Checklist.Services.Services.UserService;
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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
        }

        public static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DefaultContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbDefault"));
            });
        }

        public static void AddMapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new ApplicationProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
