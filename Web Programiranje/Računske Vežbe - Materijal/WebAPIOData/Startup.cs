using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPIOData.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPIOData
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
            services.AddDbContext<AirportContext>(options =>
            {
                // Lazy loading...
                // dotnet add package Microsoft.EntityFrameworkCore.Proxies
                // options.UseLazyLoadingProxies();
                options.UseSqlServer(Configuration.GetConnectionString("AirCS"));
            });

            services.AddControllers(options => options.EnableEndpointRouting = false);
            
            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            }).AddXmlSerializerFormatters();

            services.AddRazorPages();

            services.AddCors(options => 
            {
                options.AddPolicy("CORSAll", policy => 
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });

                options.AddPolicy("CORSUser", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyOrigin().WithMethods("POST", "PUT", "GET");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CORSUser");

            app.UseAuthorization();

            app.UseMvc();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
