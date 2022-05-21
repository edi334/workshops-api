using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySqlConnector;
using Swashbuckle.AspNetCore.SwaggerGen;
using WorkshopApplication.API;
using WorkshopApplication.Core;
using WorkshopApplication.Infrastructure;
using WorkshopApplication.Infrastructure.Repo;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("WorkShopAppConnString");

builder.Services.AddControllers();

var serverVersion = new MySqlServerVersion(new Version(10, 7, 3));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, serverVersion, 
        x => x.MigrationsAssembly("WorkshopApplication.API"));
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("WorkshopsApiCors", builder =>
    {
        builder
            .WithOrigins("localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IGenericRepository<Application>, GenericRepository<Application>>();
builder.Services.AddScoped<IGenericRepository<Workshop>, GenericRepository<Workshop>>();
builder.Services.AddScoped<IGenericRepository<Participant>, GenericRepository<Participant>>();

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/api/swagger.json", "My API");
});

app.UseRouting();
app.UseCors("WorkshopsApiCors");

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
