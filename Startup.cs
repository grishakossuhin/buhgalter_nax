using BuhUchetApi.Common;
using BuhUchetApi.DataBase;
using BuhUchetApi.Services.Amortization;
using BuhUchetApi.Services.Directories;
using BuhUchetApi.Services.MainThingServices;
using BuhUchetApi.Services.RegisterUser;
using BuhUchetApi.Services.UserServices.AuthentificateUser;
using BuhUchetApi.Services.UserServices.RemoveUser;
using BuhUchetApi.Services.UserServices.UpdateUser;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuhUchetApi
{
    public class Startup
    {
        public IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            _configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.Configure<ConnectionStrings>(_configuration.GetSection("ConnectionStrings"));
            services.AddDbContext<ApplicationContext>();
            
            
            services.AddTransient<RegisterUserService>();
            services.AddTransient<AuthentificateService>();
            services.AddTransient<UpdateUserService>();
            services.AddTransient<RemoveUserService>();
            services.AddTransient<AmortizationService>();

            services.AddTransient<AddDirectory>();
            services.AddTransient<GetDirectory>();
            services.AddTransient<RemoveDirectory>();
            services.AddTransient<UpdateDirectory>();



            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.ToString());
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
