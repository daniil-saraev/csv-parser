using CsvParser.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CsvParser.Persistence.Data;

internal class ResultModelConfiguration : IEntityTypeConfiguration<Result>
{
    public void Configure(EntityTypeBuilder<Result> builder)
    {
        builder.HasKey(result => result.Id);
        builder.HasAlternateKey(result => result.FileName);
        builder.Property(result => result.AllTimeSeconds)
            .IsRequired();
        builder.Property(result => result.MinimalDateTime)
            .IsRequired()
            .HasColumnType("DATETIME2(0)");
        builder.Property(result => result.AverageExecutionTimeSeconds)
            .IsRequired()
            .HasColumnType("DECIMAL(10,4)");
        builder.Property(result => result.IndicatorAverage)
            .IsRequired()
            .HasColumnType("DECIMAL(10,4)");
        builder.Property(result => result.IndicatorMedian)
            .IsRequired()
            .HasColumnType("DECIMAL(10,4)");
        builder.Property(result => result.IndicatorMinimum)
            .IsRequired()
            .HasColumnType("DECIMAL(10,4)");
        builder.Property(result => result.IndicatorMaximum)
            .IsRequired()
            .HasColumnType("DECIMAL(10,4)");
        builder.Property(result => result.RowCount)
            .IsRequired();
    }
}





