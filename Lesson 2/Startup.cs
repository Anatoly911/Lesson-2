using AutoMapper;
using Lesson_2.Repositories;
using Lesson_2.Repository;
using Lesson_2.Services;
using Lesson_2.Validation.Request.Contract;
using Lesson_2.Validation.Request.Customer;
using Lesson_2.Validation.Request.Employee;
using Lesson_2.Validation.Request.Invoice;
using Lesson_2.Validation.Request.Task;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace Lesson_2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TimesheetsDbContext>(options =>
                options.UseNpgsql(connection));

            services.AddSingleton<IUserService, UserService>();
            services.AddCors();
            services.AddControllers();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(UserService.SecretCode)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            services.AddScoped<IGetContractByIdValidator, GetContractByIdValidator>();
            services.AddScoped<IGetAllContractsValidator, GetAllContractsValidator>();
            services.AddScoped<ICreateContractValidator, CreateContractValidator>();
            services.AddScoped<IDeleteContractValidator, DeleteContractValidator>();

            services.AddScoped<IGetCustomerByIdValidator, GetCustomerByIdValidator>();
            services.AddScoped<ICreateCustomerValidator, CreateCustomerValidator>();
            services.AddScoped<IDeleteCustomerValidator, DeleteCustomerValidator>();

            services.AddScoped<IGetEmployeeByIdValidator, GetEmployeeByIdValidator>();
            services.AddScoped<ICreateEmployeeValidator, CreateEmployeeValidator>();
            services.AddScoped<IDeleteEmployeeValidator, DeleteEmployeeValidator>();

            services.AddScoped<IGetInvoiceByIdValidator, GetInvoiceByIdValidator>();
            services.AddScoped<ICreateInvoiceValidator, CreateInvoiceValidator>();
            services.AddScoped<IDeleteInvoiceValidator, DeleteInvoiceValidator>();

            services.AddScoped<IGetTaskByIdValidator, GetTaskByIdValidator>();
            services.AddScoped<ICreateTaskValidator, CreateTaskValidator>();
            services.AddScoped<IDeleteTaskValidator, DeleteTaskValidator>();
            services.AddScoped<IAddEmployeeToTaskValidator, AddEmployeeToTaskValidator>();
            services.AddScoped<IRemoveEmployeeFromTaskValidator, RemoveEmployeeFromTaskValidator>();
            services.AddScoped<ICloseTaskValidator, CloseTaskValidator>();

            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Timesheets",
                    Description = "Описание API",
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Timesheets");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
