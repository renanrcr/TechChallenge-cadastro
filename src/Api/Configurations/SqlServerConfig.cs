using Microsoft.EntityFrameworkCore;
using TechChallenge.src.Adapters.Driven.Infra.DataContext;

namespace API.Configurations
{
    public static class SqlServerConfig
    {
        public static void AddSqlServerDbContext(this WebApplicationBuilder? builder)
        {
            if (builder == null) return;

            var server = builder.Configuration["DbServer"] ?? "localhost";
            var port = builder.Configuration["DbPort"] ?? "1433"; // Default SQL Server port
            var user = builder.Configuration["DbUser"] ?? "SA"; // Warning do not use the SA account
            var password = builder.Configuration["Password"] ?? "TechChallenge#Lanchonete";
            var database = builder.Configuration["Database"] ?? "lanchonete";
            var connectionStringSQLServer = $"Server={server}, {port};Initial Catalog={database};User ID={user};Password={password};TrustServerCertificate=true";

            builder.Services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlServer(connectionStringSQLServer));
        }
    }
}