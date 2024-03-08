using Assignment.Data;
using Assignment.Repository;
using Assignment.Service;
using Microsoft.EntityFrameworkCore;
using System;

var MyAllowSpecificOrigins = "AllowOrigin";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod());
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDocumentCenterRL, DocumentCenterRL>();
builder.Services.AddScoped<IDocumentCenterSL, DocumentCenterSL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder.AllowAnyOrigin()); // Allow requests from any origin
app.UseCors(builder => builder.AllowAnyHeader()); // Allow any header in the request
app.UseCors(builder => builder.AllowAnyMethod()); // Allow any HTTP method in the request

app.UseAuthorization();

app.MapControllers();


app.Run();
