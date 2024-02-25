using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TechChallenge.Api.Configuration;
using TechChallenge.src.Adapters.Driven.Infra;
using TechChallenge.src.Adapters.Driven.Infra.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Configuration.AddAmazonSecretsManager("us-east-1", "dev-techchallenge-terraform-terraform");

var server = builder.Configuration["DbServer"] ?? "localhost";
var port = builder.Configuration["DbPort"] ?? "1433"; // Default SQL Server port
var user = builder.Configuration["DbUser"] ?? "SA"; // Warning do not use the SA account
var password = builder.Configuration["Password"] ?? "TechChallenge#Fase02";
var database = builder.Configuration["Database"] ?? "lanchonete_cadastro";
var connectionString = $"Server={server}, {port};Initial Catalog={database};User ID={user};Password={password};TrustServerCertificate=true";
builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Program)));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddInfraModule();
builder.Services.AddApplicationModule();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechChallenge - Fase 02", Version = "v1" });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechChallenge v1"));
}

DatabaseManagementService.MigrationInitialisation(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();