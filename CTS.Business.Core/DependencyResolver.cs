using CTS.DataAccess.Core;
using CTS.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.Core
{
    public static class DependencyResolver
    {
        public static void ConfigureCoreServices(this IServiceCollection services)
        {
            services.AddScoped<CTSContext>();
            services.AddScoped<CTSRepositoryBase>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static void ConfigureServicesForExternalPortalAccess(this IServiceCollection services, IConfiguration configuration)
        {
            //CORS Settings
            var crossOriginSettings = configuration.GetSection("CrossOrigin");
            bool allowCrossOrigin = true, allowCredentials = true;
            string allowedOrigins = "*", allowedMethods = "*", allowedHeaders = "*";

            if (crossOriginSettings != null)
            {
                //allowCrossOrigin = crossOriginSettings.GetValue<string>("Allow", "true") == "true";
                 allowCrossOrigin = configuration.GetValue<Boolean>("CrossOrigin:Allow");

                allowCredentials = crossOriginSettings.GetValue<string>("AllowCredentials", "true") == "true";
                allowedOrigins = crossOriginSettings.GetValue<string>("AllowedOrigins", "*");
                allowedMethods = crossOriginSettings.GetValue<string>("AllowedMethods", "*");
                allowedHeaders = crossOriginSettings.GetValue<string>("AllowedHeaders", "*");

                if (allowCrossOrigin)
                {
                    services.AddCors(options =>
                    {
                        options.AddPolicy("CorsPolicy",
                            builder =>
                            {
                                builder = allowedOrigins == "*" ? builder.AllowAnyOrigin() : builder.WithOrigins(allowedOrigins);
                                builder = allowedMethods == "*" ? builder.AllowAnyMethod() : builder.WithMethods(allowedMethods);
                                builder = allowedHeaders == "*" ? builder.AllowAnyHeader() : builder.WithHeaders(allowedHeaders);

                                //this sets it to cache for 7 days
                                builder.SetPreflightMaxAge(new TimeSpan(7, 0, 0, 0));

                                if (allowCredentials)
                                {
                                    builder = builder.AllowCredentials();
                                }
                            }
                            );
                    });
                }
                else
                {
                    services.AddCors(options =>
                    {
                        options.AddPolicy("CorsPolicy",
                            builder =>
                            {
                                //builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetPreflightMaxAge(new TimeSpan(7, 0, 0, 0));
                                builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetPreflightMaxAge(new TimeSpan(7, 0, 0, 0));
                            }
                            );
                    });
                }

            }

            ISecurityTokenValidator customTokenValidator = null;
            //Authentication Settings
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                if (customTokenValidator != null)
                    cfg.SecurityTokenValidators.Add(customTokenValidator);

                cfg.RequireHttpsMetadata = false;
                cfg.IncludeErrorDetails = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = GetTokenValidationParameters(configuration);
                cfg.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = (c) =>
                    {
                        return Task.CompletedTask;
                    }
                };
            });

            //Authorization Settings
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiResourceAuthorization", policy =>
                {
                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                });
                options.AddPolicy("InternalRoleAuthorization", policy =>
                {
                    policy.RequireAssertion(context =>
                    {
                        if (context.User == null || context.User.Claims == null || context.User.Claims.ToList().Count == 0) return false;

                        return UserProfile.LoadFromJson(context.User.Claims.First(c => c.Type == "UserProfile").Value).IsInternal;
                    });
                });
            });

            services.AddMemoryCache();

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue; // in case of multipart
            });

            services.AddHealthChecks();

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }

        public static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration)
        {
            return new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                RequireExpirationTime = false,
                RequireSignedTokens = true,
                LifetimeValidator = new LifetimeValidator((DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters) => {
                    return DateTime.Now < expires;
                }),
                IssuerSigningKeyValidator = new IssuerSigningKeyValidator((SecurityKey keySubmitted, SecurityToken securityToken, TokenValidationParameters validationParameters) => {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
                    var symmKeySubmitted = keySubmitted as SymmetricSecurityKey;
                    if (key.Key.Length != symmKeySubmitted.Key.Length) return false;
                    for (var i = 0; i < key.Key.Length; i++)
                    {
                        if (key.Key[i] != symmKeySubmitted.Key[i]) return false;
                    }
                    return true;

                }),

                ValidIssuer = configuration["Tokens:Issuer"],
                ValidAudience = configuration["Tokens:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]))

            };
        }

    }
}
