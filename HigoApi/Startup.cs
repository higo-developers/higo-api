using System;
using System.Collections.Generic;
using System.Text;
using HigoApi.Builders;
using HigoApi.Factories;
using HigoApi.Mappers;
using HigoApi.Models;
using HigoApi.Services;
using HigoApi.Services.Impl;
using HigoApi.Strategies;
using HigoApi.Utils;
using HigoApi.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace HigoApi
{
    public class Startup
    {
        /*
         * MODIFICAR EN `appsettings.json` la propiedad `DefaultConnection` con el string de conexión que corresponda.
         * 
         * Demian = "Data Source = EMR-PC\SQLEXPRESS; Initial Catalog = Higo; Integrated Security = True";
         * Nahu = "Data Source = DESKTOP-0AJSE47\\SQLEXPRESS; Initial Catalog = Higo; Integrated Security = True";
         * Pablo = "Data Source = DELL; Initial Catalog = Higo; Integrated Security = True";
         * Santi = "Server = 127.0.0.1,1433; Database = Higo; User=sa; Password=Password01";
         * 
         */
        private const string ConfigConnectionKey = "DefaultConnection";
        private const string AllowedHostsKey = "AllowedHosts";
        private const string AllowHostsFrontEndKey = "FrontEnd";
        private const string AllowHostsFrontEndHTTPSKey = "FrontEndHTTPS";
        private const string ConfigurationSecretKey = "Secret_Key";

        private const string HigoCorsPolicy = "_higoCorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var allowedHosts = new List<string>
            {
                Configuration.GetSection(AllowedHostsKey).GetSection(AllowHostsFrontEndKey).Value,
                Configuration.GetSection(AllowedHostsKey).GetSection(AllowHostsFrontEndHTTPSKey).Value
            };
            
            services.AddCors(options =>
            {
                options.AddPolicy(HigoCorsPolicy, builder =>
                {
                    builder.WithOrigins(allowedHosts.ToArray())
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddDbContext<HigoContext>(options => options.UseSqlServer(Configuration.GetConnectionString(ConfigConnectionKey)));
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "higo.com.ar",
                    ValidAudience = "higo.com.ar",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[ConfigurationSecretKey])),
                    ClockSkew = TimeSpan.Zero
                });

            services.AddScoped<IVehiculoService, VehiculoService>();
            services.AddScoped<IOperacionService, OperacionService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<INotificacionService, NotificacionService>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IOpcionesService, OpcionesService>();
            services.AddScoped<ITipoService, TipoService>();
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<IWorkflowService, WorkflowService>();
            services.AddScoped<IControlService, ControlService>();

            services.AddScoped<VehiculoMapper>();
            services.AddScoped<UsuarioMapper>();
            services.AddScoped<MarcaMapper>();
            services.AddScoped<OpcionesMapper>();
            services.AddScoped<OperacionWorkflowMapper>();
            services.AddScoped<ControlMapper>();

            services.AddScoped<TokenBuilder>();
            services.AddScoped<LoginResponseBuilder>();
            services.AddScoped<OperacionesClasificadasDTOBuilder>();
            services.AddScoped<OperacionDTOBuilder>();
            services.AddScoped<ControlResponseBuilder>();
            
            services.AddScoped<ParametrosBusquedaVehiculoValidator>();
            services.AddScoped<UsuarioVehiculoValidator>();
            services.AddScoped<UsuarioRequestValidator>();
            services.AddScoped<CambioEstadoOperacionValidator>();
            services.AddScoped<OperacionUtils>();
            services.AddScoped<VehiculoUtils>();

            services.AddScoped<ErrorResponseFactory>();

            services.AddScoped<AgregarOperacionPendiente>();
            services.AddScoped<AgregarOperacionEnCurso>();
            services.AddScoped<AgregarOperacionFinalizada>();

            services.AddSignalR();
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

            app.UseCors(HigoCorsPolicy);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}