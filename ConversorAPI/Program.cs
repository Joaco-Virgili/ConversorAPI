
using ConversorAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using ConversorAPI.Servicies.Implementation;
using ConversorAPI.Servicies.Interfaces;

namespace ConversorAPI
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
            builder.Services.AddSwaggerGen(setupAction =>
            {
                setupAction.AddSecurityDefinition("ConversorApiBearerAuth", new OpenApiSecurityScheme() 
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    Description = "Ac� pegar el token generado al loguearse."
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ConversorApiBearerAuth" } 
                }, new List<string>() }
    });
            });

            builder.Services.AddDbContext<ConversorDbContext>(DbContextOptions => DbContextOptions.UseSqlServer(
                builder.Configuration.GetConnectionString("ConexionSqlServer")));

            builder.Services.AddAuthentication("Bearer") 
    .AddJwtBearer(options => 
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    }
);
            builder.Services.AddScoped<IUserServices, UserServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(
                    options => options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
                );

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
