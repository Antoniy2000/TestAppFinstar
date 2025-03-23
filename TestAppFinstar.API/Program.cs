using Microsoft.EntityFrameworkCore;
using TestAppFinstar.Core.Interfaces;
using TestAppFinstar.Core.Services;
using TestAppFinstar.Data.Contexts;
using TestAppFinstar.Data.Interfaces;
using TestAppFinstar.Data.Repositories;
using TestAppFinstar.Models.Entities;

namespace TestAppFinstar.API;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddLogging();

        builder.Services.AddDbContext<MainDbContext>(x =>
            x.UseSqlite(builder.Configuration.GetConnectionString("MainDbContext"))
             .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        builder.Services.AddScoped<IRepository<SomeData>, SomeDataRepository>();
        builder.Services.AddScoped<ITestAppFinstarService, TestAppFinstarService>();

        var app = builder.Build();

        app.MapControllers();
        app.UseCors(x => x.AllowAnyOrigin());

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.Run();
    }
}
