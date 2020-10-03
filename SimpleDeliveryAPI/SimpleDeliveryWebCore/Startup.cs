using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleDelivery.DAL;
using SimpleDelivery.DAL.EF;
using SimpleDelivery.DAL.Interfaces;
using SimpleDelivery.BLL.DI;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper.EquivalencyExpression;
using SimpleDeliveryWebCore.MapperProfiles;
using SimpleDelivery.BLL.MapperProfiles;

namespace SimpleDeliveryWebCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(
                cfg =>
                {
                    cfg.AddExpressionMapping();
                    cfg.AddCollectionMappers();
                    cfg.AddProfile(new ViewMapperProfile());
                    cfg.AddProfile(new BusinessMapperProfile());
                });

            services.AddControllers();

            services.AddDbContext<DeliveryContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DeliveryConnectionString"), m => m.MigrationsAssembly("SimpleDelivery.DAL")));

            services.AddSwaggerGen();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddBllServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
