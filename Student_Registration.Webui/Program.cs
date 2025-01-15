using Microsoft.EntityFrameworkCore;
using Serilog;
using Student_Registration.Application.Interfaces;
using Student_Registration.Infrastructure.Context;
using Student_Registration.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/StudentRegistration.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<StudentRegistrationDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("StudentResgistrationConnection"));
});

builder.Host.UseSerilog();

builder.Services.AddScoped<IStudentRegistrationRepository, StudentRegistrationRepository>();

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
