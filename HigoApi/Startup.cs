﻿using HigoApi.Mappers;
using HigoApi.Models;
using HigoApi.Services;
using HigoApi.Services.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using Microsoft.AspNetCore.Identity;

namespace HigoApi
{
    public class Startup
    {
        /*
         * MODIFICAR EN `appsettings.json` la propiedad `DefaultConnection` con el string de conexión que corresponda.
         * 
         * Demian = "Data Source = EMR-PC\SQLEXPRESS; Initial Catalog = Higo; Integrated Security = True";
         * Nahu = "data source=DESKTOP-0AJSE47\SQLEXPRESS; integrated security=True; multipleactiveresultsets=True; application name=EntityFramework";
         * Pablo = "Data Source = DELL; Initial Catalog = Higo; Integrated Security = True";
         * Santi = "Server = 127.0.0.1,1433; Database = Higo; User=sa; Password=Password01";
         * 
         */
        private const string ConfigConnectionKey = "DefaultConnection";

        private const string HigoAllowSpecificOrigins = "_higoAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(HigoAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("*");
                    });
            });
            
            services.AddDbContext<HigoContext>(options => options.UseSqlServer(Configuration.GetConnectionString(ConfigConnectionKey)));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddIdentity<Usuario, IdentityRole>().AddEntityFrameworkStores<HigoContext>().AddDefaultTokenProviders();
            services.AddScoped<IVehiculoService, VehiculoService>();
            services.AddSingleton<VehiculoMapper>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "higo.com.ar",
                ValidAudience = "higo.com.ar",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Secret_Key"])),
                ClockSkew = TimeSpan.Zero
            });

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(HigoAllowSpecificOrigins);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}