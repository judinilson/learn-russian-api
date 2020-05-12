using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using learn_Russian_API.Helpers;
using learn_Russian_API.Presistence;
using learn_Russian_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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
                
               
                // configure strongly typed settings objects
                var appSettingsSection = Configuration.GetSection("AppSettings");
                services.Configure<AppSettings>(appSettingsSection);

                // configure jwt authentication
                var appSettings = appSettingsSection.Get<AppSettings>();
                var key = Encoding.ASCII.GetBytes(appSettings.Secret);
                services.AddAuthentication(x =>
                    {
                        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(x =>
                    {
                        x.Events = new JwtBearerEvents
                        {
                            OnTokenValidated = context =>
                            {
                                var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                                var userId = long.Parse(context.Principal.Identity.Name);
                                var user = userService.GetById(userId);
                                if (user == null)
                                {
                                    // return unauthorized if user no longer exists
                                    context.Fail("Unauthorized");
                                }
                                return Task.CompletedTask;
                            }
                        };
                        
                        x.RequireHttpsMetadata = false;
                        x.SaveToken = true;
                        x.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });
                
                services.AddScoped<IUserService, UserService>();

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
                
                
               // define swagger docs and other options
               var securityScheme = new OpenApiSecurityScheme
               {
                   Name = "Authorization",
                   Description = "Enter JWT Bearer authorisation token",
                   In = ParameterLocation.Header,
                   Type = SecuritySchemeType.Http,
                   Scheme = "bearer", // must be lowercase!!!
                   BearerFormat = "Bearer {token}",
                   Reference = new OpenApiReference
                   {
                       Id = JwtBearerDefaults.AuthenticationScheme,
                       Type = ReferenceType.SecurityScheme
                   }
               };
               c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);
               c.AddSecurityRequirement(new OpenApiSecurityRequirement
               {
                   // defines scope - without a protocol use an empty array for global scope
                   { securityScheme, Array.Empty<string>() }
               });
                
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

            app.UseAuthentication();
            app.UseAuthorization();
            

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
