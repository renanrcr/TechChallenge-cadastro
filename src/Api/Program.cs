using API.Configurations;
using Infrastructure.Configuration;
using TechChallenge.src.Adapters.Driven.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.AddSqlServerDbContext();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddInfraModule();
builder.Services.AddApplicationModule();

builder.Services.AddSwaggerGenConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechChallenge v1"));
}

app.UseReDoc(c =>
{
    c.DocumentTitle = "API Documentação";
    c.SpecUrl = "/swagger/v1/swagger.json";
});

DatabaseManagementService.MigrationInitialisation(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();