using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Ewadul.Api.Data;
using Ewadul.Api.Helpers;
using Ewadul.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(
    options =>
    {
        options.UseMySql(builder.Configuration.GetConnectionString("DBConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
    });

// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure DI for application services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPengaduanService, PengaduanService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
// app.UseHttpsRedirection();

app.UseStaticFiles();
// app.UseStaticFiles(new StaticFileOptions()
// {
//     FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"assets\files")),
//     RequestPath = new PathString("/assets/files")
// });

app.UseAuthorization();

// Middleware
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
