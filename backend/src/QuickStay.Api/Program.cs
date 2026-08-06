using Microsoft.EntityFrameworkCore;
using QuickStay.Api.Infrastructure.Persistence;
using QuickStay.Api.Modules.Availability;
using QuickStay.Api.Modules.Catalog;
using QuickStay.Api.Modules.Search;
using QuickStay.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services
    .AddCatalogModule()
    .AddAvailabilityModule()
    .AddSearchModule();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<QuickStayDbContext>();
    await dbContext.Database.MigrateAsync();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuickStay API V1");
    c.RoutePrefix = "swagger"; // Set Swagger UI at the app's root
});


app.UseHttpsRedirection();
app.MapControllers();

app.Run();