using API.Authentication;
using AutoMapper;
using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Configuration;
using DataAccessLayer.DataContext;
using DataAccessLayer.EntitiesDAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Text;

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

            // for identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

            // for authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // jwt bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            // TODO: ne go razbiram maperov, sto treba da mapira i kade se koristi?
            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            services.AddScoped<BusesDAL>();
            services.AddScoped<SeatsDAL>();
            services.AddScoped<CitiesDAL>();
            services.AddScoped<IBusTimeTablesDAL, BusTimeTablesDAL>();
            services.AddScoped<BusStationsDAL>();
            services.AddScoped<IBusLanesDAL, BusLanesDAL>();
            services.AddScoped<BusCompaniesDAL>();
            services.AddScoped<BookingsDAL>();
            services.AddScoped<BusesBLL>();
            services.AddScoped<SeatsBLL>();
            services.AddScoped<CitiesBLL>();
            services.AddScoped<BusTimeTablesBLL>();
            services.AddScoped<BusStationsBLL>();
            services.AddScoped<BusLanesBLL>();
            services.AddScoped<BusCompaniesBLL>();
            services.AddScoped<BookingsBLL>();

            // TODO: dodadeno da se zastitime od cyclic reference koga se pravi serijalizicija vo json
            // primer bus lanes sodrzi city a toj sodrzi buslanes, pa json znae da vleze vo endless loop
            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // TODO: dodadeno za da update na DB avtomatski na start
            // ensure migration of context
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
