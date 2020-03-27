using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using learn_Russian_API.Presistence;
using Microsoft.EntityFrameworkCore;
using  Microsoft.OpenApi.Models;

namespace learn_Russian_API
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
            services
                .AddControllers()
                .AddNewtonsoftJson();
                /*.AddProtectedWebApi(Configuration)
                .AddProctectedApiCallsWebApis(Configuration, new[] {"user.read", "offline_access"})
                .AddInMemoryTokenCaches();*/

            services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(opts =>
            {
                opts.UseNpgsql(Configuration.GetConnectionString("MainConnection"));
            });
            services.AddCors(ops =>
            {
                ops.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Learn Russian API", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseCors(ops =>
            {
                ops.AllowAnyMethod();
                ops.AllowAnyOrigin();
                ops.AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            
            // Enable middleware to serve swagger-ui (html , js, css, etc.)
            // specifying the swagger endpoint
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Learn Russian API v1"); });

            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.Migrate();
            //contextSeeder.SeedDatabase(context);*/
        }
    }
}
