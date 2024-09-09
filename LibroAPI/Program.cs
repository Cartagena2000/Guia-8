
using Microsoft.EntityFrameworkCore;
using LibroAPI.Models;
using StackExchange.Redis;

namespace LibroAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Configurar Entity Framework Core
            builder.Services.AddDbContext<LibroContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
            );

            builder.Services.AddStackExchangeRedisOutputCache(options =>
            {
                options.Configuration = builder.Configuration.GetConnectionString("redis");
            });

            // Registrar IConnectionMultiplexer
            builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            builder.Services.AddOutputCache();

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
            app.UseOutputCache();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}