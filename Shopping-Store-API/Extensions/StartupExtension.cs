using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_Store_API.Config;
using Shopping_Store_API.DBContext;
using Shopping_Store_API.Infrastucture;
using Shopping_Store_API.Interface;
using Shopping_Store_API.Repositories;
using Microsoft.AspNetCore.Identity;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Infrastucture.Repositories;
using Shopping_Store_API.Interface.RepositoryInterface;
using Shopping_Store_API.Service;
using Shopping_Store_API.Interface.ServiceInterface;
using System.Text.Json.Serialization;
using Shopping_Store_API.Filters;
using Shopping_Store_API.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace Shopping_Store_API.Extensions
{
    public static class StartupExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure Controller
            #region Controller
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });
            services.AddMvc(option =>
            {
                option.EnableEndpointRouting = false;
                option.Filters.Add(new ApiExceptionFilter());
            });
            #endregion

            // Configure Swagger
            #region Swagger
            services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter your token with this format: Bearer YOUR_TOKEN",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Id="Bearer",
                                Type=ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>{}
                    }
                });
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                new HeaderApiVersionReader("x-api-version"),
                                                                new MediaTypeApiVersionReader("x-api-version"));
            });

            // Add ApiExplorer to discover versions
            services.AddVersionedApiExplorer(opt =>
            {
                opt.GroupNameFormat = "'v'VVV";
                opt.SubstituteApiVersionInUrl = true;
            });
            services.ConfigureOptions<ConfigureSwaggerOptions>();
            #endregion

            // Configure AutoMapper
            #region AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion

            // Configure DbContext with Scoped lifetime   
            #region DbContext with Scoped lifetime
            services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("ShopDB"));
                }
            );
                
            services.AddScoped<Func<AppDbContext>>((provider) => () => provider.GetService<AppDbContext>());
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            #endregion

            // Configure Identity
            #region Identity
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 1;

                // User settings.
                options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

                // SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            });
            #endregion

            #region Configure Authentication and Authorization
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    ValidAudience = configuration["JWT:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });
            #endregion

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IShoppingCartRepository, ShoppingCartRepository>()
                .AddScoped<IShoppingCartItemRepository, ShoppingCartItemRepository>()
                .AddScoped<ITokenRepository, TokenRepository>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<IAddressRepository, AddressRepository>()
                .AddScoped<IBrandRepository, BrandRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IProductService, ProductService>()
                .AddScoped<IShoppingCartService, ShoppingCartService>()
                .AddScoped<ITokenService, TokenService>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IPaymentService, PaymentService>();
        }

        public static IApplicationBuilder ConfigureAPIApp(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //app.UseCors("AllowAll");
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(string.Format("Welcome to ShopStore API!"));
                });
            });

            return app;
        }
    }
}
