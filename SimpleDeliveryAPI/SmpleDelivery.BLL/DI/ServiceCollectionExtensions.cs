using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.DependencyInjection;
using SimpleDelivery.BLL.Interfaces;
using SimpleDelivery.BLL.MapperProfiles;
using SimpleDelivery.BLL.Services;
using SimpleDelivery.DAL;
using SimpleDelivery.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SimpleDelivery.BLL.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();

/*            services.AddAutoMapper(
                cfg => 
                {
                    cfg.AddExpressionMapping();
                    cfg.AddCollectionMappers();
                    
                });*/

            return services;
        }
    }
}
