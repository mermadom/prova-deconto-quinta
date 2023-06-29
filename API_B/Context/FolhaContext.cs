using API_B.Model;
using Microsoft.EntityFrameworkCore;

namespace API_B.Context;

public class FolhaContext : DbContext
{
    public FolhaContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Folha>? Folhas { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    }

    //dotnet ef migrations add primeira
    //dotnet ef database update
}