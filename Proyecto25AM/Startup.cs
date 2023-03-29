using Proyecto25AM.Services.Services;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM
{
    public class Startup
    {
        private readonly string _Mis_politicas = "MyCors";
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();


            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            //agregar politicas

            services.AddCors(options =>
            {
                options.AddPolicy(name: _Mis_politicas, builder =>
                {
                    //builder.WithOrigins("www.panchito.com");
                    builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                    .AllowAnyHeader().AllowAnyMethod();
                });
            });

            //add connection bd
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Inyeccion de dependencias
            services.AddTransient<IUsuarioServices, UsuarioServices>();
            services.AddTransient<IRolServices, RolServices>();
            services.AddTransient<IPuestoServices, PuestoServices>();
            services.AddTransient<IFacturaServices, FacturaServices>();
            services.AddTransient<IEmpleadoServices, EmpleadoServices>();
            services.AddTransient<IDepartamentoServices, DepartamentoServices>();
            services.AddTransient<IClienteServices, ClienteServices>();

        }
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) 
        {

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(_Mis_politicas);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
