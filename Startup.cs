using BuhUchetApi.Common;
using BuhUchetApi.DataBase;
using BuhUchetApi.Services.RegisterUser;
using BuhUchetApi.Services.UserServices.AuthentificateUser;
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
