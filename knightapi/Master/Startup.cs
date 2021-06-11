using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using Master.Infrastructure;
using Master.Repository;
using Master.CustomMiddlewares;
using Microsoft.Extensions.FileProviders;
using Swashbuckle.AspNetCore.Swagger;
using Master.Model;
using Microsoft.EntityFrameworkCore;
using Master.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Master.Models;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Master.Helpers;
using System.Net;
using Master.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;

namespace Master
{
    public class Startup
    {

        private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"; // todo: get this from somewhere secure
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }





        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            services.AddDirectoryBrowser();
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddDbContext<MasterContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
              b => b.MigrationsAssembly("Master")));

            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<ICharacterDetailsRepository, CharacterDetailsRepository>();
            services.AddScoped<ICharacterLevelRepository, CharacterLevelRepository>();
            services.AddScoped<IMobRepository, MobRepository>();
            services.AddScoped<IMoneyRepository, MoneyRepository>();
            services.AddScoped<IAcilisBildirimRepository, AcilisBildirimRepository>();
            services.AddScoped<IGaleriRepository, GaleriRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<ISosyalMedyaRepository, SosyalMedyaRepository>();
            services.AddScoped<INetPolRepository, NetPolRepository>();
            services.AddScoped<IItemLevelRepository, ItemLevelRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IMarketRepository, MarketRepository>();
            services.AddScoped<IAreaMobRepository, AreaMobRepository>();
            services.AddScoped<ICharacterMoveRepository, CharacterMoveRepository>();
            services.AddScoped<IRutbeRepository, RutbeRepository>();
            services.AddScoped<IHaberRepository, HaberRepository>();
            services.AddScoped<IGiftRepository, GiftRepository>();








            services.AddSingleton<IJwtFactory, JwtFactory>();

            //services.Configure<FacebookAuthSettings>(Configuration.GetSection(nameof(FacebookAuthSettings)));

            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();

            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));


            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
            });

            var builder = services.AddIdentityCore<AppUser>(o =>
            {
                // configure identity options
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<MasterContext>().AddDefaultTokenProviders();

            services.AddAutoMapper();
            services.AddMvc()
                .AddJsonOptions(
            options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        )
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "My API", Description = "Core API" }); });

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }






        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAll");
            app.UseMiddleware<AuthenticationMiddleware>();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads")),
                RequestPath = "/Uploads"
            });



            app.UseExceptionHandler(
          builder =>
          {
              builder.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                            var error = context.Features.Get<IExceptionHandlerFeature>();
                            if (error != null)
                            {
                                context.Response.AddApplicationError(error.Error.Message);
                                await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                            }
                        });
          });





            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles(); // For the wwwroot folder
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API"); });


        }





    }
}
