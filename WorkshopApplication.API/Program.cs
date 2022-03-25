using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySqlConnector;
using Swashbuckle.AspNetCore.SwaggerGen;
using WorkshopApplication.API;
using WorkshopApplication.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("WorkShopAppConnString");

builder.Services.AddControllers();

var serverVersion = new MySqlServerVersion(new Version(10, 7, 3));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, serverVersion, 
        x => x.MigrationsAssembly("WorkshopApplication.API"));
});

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

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
