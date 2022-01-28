using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pharmacy.BL.Interfaces;
using Pharmacy.DL.Interfaces;
using Pharmacy.BL.Services;
using Pharmacy.DL.Repositories;
using Microsoft.OpenApi.Models;
using Serilog;
using Pharmacy.Extensions;
using FluentValidation.AspNetCore;


namespace Pharmacy
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
            //services.AddRazorPages();

            services.AddSingleton(Log.Logger);

            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<IProductsRepository, ProductsInMemoryRepository>();
            services.AddSingleton<IClientRepository, ClientInMemoryRepository>();
            services.AddSingleton<IShiftRepository, ShiftInMemoryRepository>();
            services.AddSingleton<IEmployeeRepository, EmployeeInMemoryRepository>();

            services.AddSingleton<IProductsService, ProductsService>();
            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<IShiftService, ShiftService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();

            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pharmacy", Version = "v1" });
            });

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pharmacy v1"));
            }

            app.ConfigureExceptionHadler(logger);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
