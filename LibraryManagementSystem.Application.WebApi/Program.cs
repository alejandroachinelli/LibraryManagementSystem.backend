using LibraryManagementSystem.Application;
using LibraryManagementSystem.Application.WebApi.Modules.Swagger;
using LibraryManagementSystem.Infrastructure;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:5174")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
builder.Services.AddSwaggerGen(c =>
{
    var info = new OpenApiInfo
    {
        Version = "v1",
        Title = "Library Management",
        Description = "Library management system.",
        TermsOfService = new Uri("https://google.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Alejandro Achinelli",
            Email = "alejandromartin.achinelli@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/alejandroachinelli/")
        }
    };

    c.SwaggerDoc("v1", info);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() ||
    app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library Management");
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.MapControllers();
app.UseAuthorization();

app.MapControllers();

app.Run();
