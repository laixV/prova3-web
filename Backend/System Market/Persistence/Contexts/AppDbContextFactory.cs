using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Super_Market.Persistence.Contexts
{
    public class AppDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(
                @"Server=ec2-54-208-96-16.compute-1.amazonaws.com; Port=5432; User Id=ixedkeeqttsdjd; Password=54f7dabc8bf0d3b857e608b8ff17aebb5489ae7245cf519ea1fa3133bc368a96; Database=d7rejkaifghcg; Pooling=true; SSL Mode=Require; TrustServerCertificate=True;");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}