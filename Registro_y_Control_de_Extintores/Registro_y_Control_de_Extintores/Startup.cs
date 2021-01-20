using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Registro_y_control_de_extintores
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
            services.AddControllersWithViews();
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(15);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePages();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseCookiePolicy();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Inicio_de_sesion}/{action=Inicio_de_sesion}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=AboutUs}/{action=AboutUs}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Soporte}/{action=Soporte}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Centro}/{action=Administrar}");

		        endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=MenuUsuario}/{action=MenuPrincipalUsuarios}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Extintor}/{action=MenuAdministrarExtintores}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Extintor}/{action=Eliminar}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Extintor}/{action=Crear}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Inicio_de_sesion}/{action=OlvidarContrasena}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=MenuPrincipal}/{action=MostrarMenuPrincipal}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=MenuPrincipal}/{action=MostrarMenuPrincipalUsuario}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=MenuPrincipal}/{action=MostrarInformacion}");

            });
        }
    }
}
