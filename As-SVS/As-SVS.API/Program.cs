using As_SVS.API.Helpers;
using As_SVS.Business.Interfaces;
using As_SVS.Business.Services;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.DTOs;
using As_SVS.EF;
using As_SVS.EF.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace As_SVS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<As_SVSContext>();
            builder.Services.AddDbContext<As_SVSContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                        ValidAudience = builder.Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                    };
                });
            builder.Services.AddScoped<IAuthServices,AuthServices>();
            builder.Services.AddTransient(typeof(IPersonSevices), typeof(PersonServices));
            builder.Services.AddTransient(typeof(IAdminServices), typeof(AdminServices));
            builder.Services.AddTransient(typeof(ITeacherServices), typeof(TeacherServices));
            builder.Services.AddTransient(typeof(IStudentServices), typeof(StudentServices));
            builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddTransient(typeof(IPersonRepository), typeof(PersonRepository));
            builder.Services.AddTransient(typeof(IAdminRepository), typeof(AdminRepository));
            builder.Services.AddTransient(typeof(ITeacherRepository), typeof(TeacherRepository));
            builder.Services.AddTransient(typeof(PasswordHasher<>));
            builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile));



            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
