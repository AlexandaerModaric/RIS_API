using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RIS_API.Configurations;
using RIS_API.Data;
using Serilog;
#region Serilog Configuration
Log.Logger = new LoggerConfiguration()
    .WriteTo.File(
    path: Environment.CurrentDirectory.ToString() + "\\Logs\\log-.txt",
    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3} {Message:lj} {NewLine} {Exception}]",
    rollingInterval: RollingInterval.Day,
    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information
    ).CreateLogger();
#endregion

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Host.UseSerilog();
builder.Services.AddDbContext<RISDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("sqlConnection")
));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RIS", Version = "v1" });
});
builder.Services.AddCors(cors =>
{
    cors.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
builder.Services.AddAutoMapper(typeof(MapperInitializer));
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(options =>
//    {
//        options.SwaggerEndpoint("/swagger/v1/swagger.json", "RIS v1");
//    });
//}
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "RIS v1");
});
app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("Application Is Starting");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application Failed to Start");
}
finally
{
    Log.CloseAndFlush();
}
