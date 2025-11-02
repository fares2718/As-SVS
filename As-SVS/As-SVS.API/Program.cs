using As_SVS.Business.Helpers;
using As_SVS.Business.Interfaces;
using As_SVS.Business.Services;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.EF;
using AsSVS.EF.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace As_SVS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region JWTandEF
            builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<As_SVSContext>();
            builder.Services.AddDbContext<As_SVSContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            _ = builder.Services.AddAuthentication(options =>
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
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
                        ClockSkew = TimeSpan.Zero,
                    };
                });
            #endregion

            #region Repositories
            builder.Services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            builder.Services.AddTransient(typeof(IAdminRepository), typeof(AdminRepository));
            builder.Services.AddTransient(typeof(ITeacherRepository), typeof(TeacherRepository));
            builder.Services.AddTransient(typeof(IStudentRepository), typeof(StudentRepository));
            builder.Services.AddTransient(typeof(ICourseRepository), typeof(CourseRepository));
            builder.Services.AddTransient(typeof(IModulesRepository), typeof(ModulesRepository));
            builder.Services.AddTransient(typeof(ILessonsRepository), typeof(LessonsRepository));
            builder.Services.AddTransient(typeof(IQuizeRepository), typeof(QuizeRepository));
            #endregion

            #region Services
            builder.Services.AddScoped(typeof(IAuthServices), typeof(AuthServices));
            builder.Services.AddScoped(typeof(IAdminServices), typeof(AdminServices));
            builder.Services.AddScoped(typeof(ITeacherServices), typeof(TeacherServices));
            builder.Services.AddTransient(typeof(IImageServices), typeof(ImageServices));
            builder.Services.AddTransient(typeof(ICourseServices), typeof(CourseServices));
            builder.Services.AddTransient(typeof(IModulesServices), typeof(ModulesServices));
            builder.Services.AddTransient(typeof(ILessonsServices), typeof(LessonServices));
            builder.Services.AddTransient(typeof(IQuizeServices), typeof(QuizeServices));
            builder.Services.AddTransient(typeof(IVideoServices), typeof(VideoServices));
            builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile));
            #endregion


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
