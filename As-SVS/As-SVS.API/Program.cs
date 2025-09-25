using As_SVS.Business.Interfaces;
using As_SVS.Business.Services;
using As_SVS.Core.Interfaces;
using As_SVS.DTOs;
using As_SVS.EF;
using As_SVS.EF.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace As_SVS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<As_SVSContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient(typeof(IPersonSevices), typeof(PersonServices));
            builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddTransient(typeof(PasswordHasher<>));

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
