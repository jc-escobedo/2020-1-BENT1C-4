using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using UsandoEntityFramework.Database;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Grupo4.InstitutoEducativo
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Habilitar la autenticación por cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                // Especificamos que la ruta para login es "/Usuarios/Ingresar" => esto quiere decir que si alguien que no está autenticado intenta ingresar será enviado a la página de login.
                options.LoginPath = "/Cuentas/Ingresar";
                options.AccessDeniedPath = "/Cuentas/NoAutorizado";
                options.LogoutPath = "/Cuentas/Salir";
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // services.AddDbContext<UsandoEFDbContext>(options => 
            //     options.UseSqlServer("Server=TL-DEV-63\\SQLEXPRESS;Database=alumnos;Integrated Security=SSPI;"));
            services.AddDbContext<UsandoEFDbContext>(options => options.UseInMemoryDatabase("unaBaseDeDatos"));
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
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Cuentas}/{action=Ingresar}/{id?}");
            });

            app.UseCookiePolicy();
        }
    }
}
