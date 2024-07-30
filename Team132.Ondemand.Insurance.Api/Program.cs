using Microsoft.EntityFrameworkCore;
using Team132.Ondemand.Insurance.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<InsuranceContext>(options =>
    options.UseInMemoryDatabase("InsuranceDb"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS.1: Add services to the container for managing CORS.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",

        builder => builder.WithOrigins("http://localhost:3000")
                          .AllowAnyMethod()
                          .AllowAnyHeader());

});

var app = builder.Build();

// CORS.2: Allow App to use the CORS policy set earlier
app.UseCors("CorsPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
