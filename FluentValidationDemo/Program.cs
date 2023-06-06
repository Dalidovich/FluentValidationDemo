using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidationDemo.DAL;
using FluentValidationDemo.Domain;
using FluentValidationDemo.Validation;

namespace FluentValidationDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IMotherBoardRepository, MotherBoardRepository>();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddScoped<IValidator<MotherBoard>, MotherBoardValidator>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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