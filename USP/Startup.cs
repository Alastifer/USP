using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using USP.Models;

namespace USP
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.Add(new ServiceDescriptor(typeof(UserContext), new UserContext(Configuration.GetConnectionString("DefaultConnection"))));

            AddressContext addressContext = new AddressContext(Configuration.GetConnectionString("DefaultConnection"));
            InsuranceContext insuranceContext = new InsuranceContext(Configuration.GetConnectionString("DefaultConnection"));
            PurposeContext purposeContext = new PurposeContext(Configuration.GetConnectionString("DefaultConnection"));
            EmployeeContext employeeContext = new EmployeeContext(Configuration.GetConnectionString("DefaultConnection"));
            PassportContext passportContext = new PassportContext(Configuration.GetConnectionString("DefaultConnection"));

            services.Add(new ServiceDescriptor(typeof(AddressContext), addressContext));
            services.Add(new ServiceDescriptor(typeof(InsuranceContext), insuranceContext));
            services.Add(new ServiceDescriptor(typeof(PurposeContext), purposeContext));
            services.Add(new ServiceDescriptor(typeof(EmployeeContext), employeeContext));
            services.Add(new ServiceDescriptor(typeof(PassportContext), passportContext));

            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=EmployeeList}/{action=Index}/{id?}");
            });
        }
    }
}
