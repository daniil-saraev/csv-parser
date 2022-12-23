using CsvParser.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CsvParser.Persistence.Data;

internal class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ValueModelConfiguration());
        modelBuilder.ApplyConfiguration(new ResultModelConfiguration());
    }

    public DbSet<Value> Values => Set<Value>();
    public DbSet<Result> Results => Set<Result>();
}



