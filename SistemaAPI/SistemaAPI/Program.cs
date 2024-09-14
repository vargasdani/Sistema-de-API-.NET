
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SistemaAPI.Data;
using SistemaAPI.Repositorios;
using SistemaAPI.Repositorios.Interfaces;
using System.Reflection;

namespace SistemaAPI
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
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SistemaAPI",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Nathalia",
                        Email = "rm552221@fiap.com.br"
                    }
                });

                var xmlFile = "SistemaAPI.xml"; 
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            }
            );

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaPlantacoesDBContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IClimaRepositorio, ClimaRepositorio>();
            builder.Services.AddScoped<IPlantacaoRepositorio, PlantacaoRepositorio>();



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
