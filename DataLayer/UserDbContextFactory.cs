using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


public class UserDBContextFactory : IDesignTimeDbContextFactory<UserDBContext>
{
    public UserDBContext CreateDbContext(string[] args)
    {
        // Load configuration from appsettings.json
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "PresentationLayer"))
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<UserDBContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new UserDBContext(optionsBuilder.Options);
    }
}
