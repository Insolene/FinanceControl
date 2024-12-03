
using FinanceControl.Data;
using FinanceControl.Data.Repository;
using FinanceControl.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace FinanceControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddEntityFrameworkSqlServer()
               .AddDbContext<Banco>(
               options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
               );
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

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
