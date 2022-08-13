using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Repository;

namespace WebApplication2
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
            services.AddScoped<IAboutHospitalRepository,AboutHospitalRepsository>();
            services.AddScoped<IAppointmentFormRepository,AppointmentFormRepsository>();
            services.AddScoped<IBlogsRepository,BlogsRepsository>();
            services.AddScoped<IContactRepository,ContactRepsository>();
            services.AddScoped<IDepartmentsRepository, DepartmentsRepsository>();
            services.AddScoped<IDoctorRepository,DoctorRepsository>();
            services.AddScoped<IFAQsRepository, FAQsRepsository>();
            services.AddScoped<IHomeSliderRepository, HomeSliderRepsository>();
            services.AddScoped<IOurExpertiseRepository, OurExpertiseRepsository>();
            services.AddScoped<IOurServicesRepository, OurServicesRepsository>();
            services.AddScoped<IPrivacyPolicyRepository, PrivacyPolicyRepsository>();
            services.AddScoped<ITestmonialsRepository, TestimonialsRepsository>();
            services.AddScoped<IVideoRepository,VideoRepsository>();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EmployerDb")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication2", Version = "v1" });
            });
            services.AddCors(config =>
            {
                config.AddDefaultPolicy(c => {
                    c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication2 v1"));
            }
            app.UseCors();
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
