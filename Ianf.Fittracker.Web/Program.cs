using Ianf.Fittracker.Interfaces;
using Ianf.Fittracker.Service;
using Ianf.Fittracker.Repositories;
using Ianf.Fittracker.Engine;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<IWorkoutService, WorkoutService>();
        builder.Services.AddScoped<IWorkoutRepository, WorkoutFileRepository>();
        builder.Services.AddScoped<IEngine, FiveByFive>();
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
        else 
        {
            app.UseHttpsRedirection();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}