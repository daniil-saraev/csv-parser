using CsvParser.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CsvParser.Persistence.Data;

internal class ValueModelConfiguration : IEntityTypeConfiguration<Value>
{
    public void Configure(EntityTypeBuilder<Value> builder)
    {
        builder.HasKey(value => value.Id);
        builder.Property(value => value.Id).HasDefaultValueSql("NEWID()");
        builder.HasIndex(value => value.FileName);
        builder.Property(value => value.DateTime)
            .IsRequired()
            .HasColumnType("DATETIME2(0)");
        builder.Property(value => value.ExecutionTimeSeconds).IsRequired();
        builder.Property(value => value.Indicator)
            .IsRequired()
            .HasColumnType("DECIMAL(10,4)");
    }
}





