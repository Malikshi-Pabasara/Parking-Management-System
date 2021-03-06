using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkingManagementSystemApi.Data;
using ParkingManagementSystemApi.Repository;

namespace ParkingManagementSystemApi
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
            services.AddDbContext<ParkingContext>(
               options => options.UseSqlServer(Configuration.GetConnectionString("ParkingDetailsStoreDB")));

            services.AddControllers();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICarParkRepository, CarParkRepository>();
            services.AddTransient<ISlotRepository, SlotRepository>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<IParkingRepository, ParkingRepository>();
            services.AddAutoMapper(typeof(Startup));

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ParkingManagementSystemApi", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ParkingManagementSystemApi v1"));
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
