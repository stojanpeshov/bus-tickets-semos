using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Configuration;
using DataAccessLayer.DataContext;
using DataAccessLayer.EntitiesDAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace API
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
            var settings = new AppConfiguration();
            services.AddDbContextPool<DatabaseContext>(options => options.UseSqlServer(settings.sqlConnectionString));
            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            services.AddScoped<BusesDAL>();
            services.AddScoped<UsersDAL>();
            services.AddScoped<SeatsDAL>();
            services.AddScoped<CitiesDAL>();
            services.AddScoped<BusTimeTablesDAL>();
            services.AddScoped<BusStationsDAL>();
            services.AddScoped<BusLanesDAL>();
            services.AddScoped<BusCompaniesDAL>();
            services.AddScoped<BookingsDAL>();
            services.AddScoped<BusesBLL>();
            services.AddScoped<UsersBLL>();
            services.AddScoped<SeatsBLL>();
            services.AddScoped<CitiesBLL>();
            services.AddScoped<BusTimeTablesBLL>();
            services.AddScoped<BusStationsBLL>();
            services.AddScoped<BusLanesBLL>();
            services.AddScoped<BusCompaniesBLL>();
            services.AddScoped<BookingsBLL>();
            services.AddControllers();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
