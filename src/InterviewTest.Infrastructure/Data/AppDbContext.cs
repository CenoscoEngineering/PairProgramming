using InterviewTest.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Pipeline> Pipelines => Set<Pipeline>();
    public DbSet<PipeSegment> PipeSegments => Set<PipeSegment>();
    public DbSet<Inspection> Inspections => Set<Inspection>();
    public DbSet<Anomaly> Anomalies => Set<Anomaly>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pipeline>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(200).IsRequired();
            entity.Property(e => e.OperatorName).HasMaxLength(200);
            entity.Property(e => e.Material).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.HasIndex(e => e.Name).IsUnique();
        });

        modelBuilder.Entity<PipeSegment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.SegmentName).HasMaxLength(200).IsRequired();
            entity.Property(e => e.CoatingType).HasMaxLength(50);
            entity.Property(e => e.SoilType).HasMaxLength(50);
            entity.HasOne(e => e.Pipeline)
                  .WithMany(p => p.Segments)
                  .HasForeignKey(e => e.PipelineId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Inspection>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.InspectionType).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Inspector).HasMaxLength(200);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.HasOne(e => e.PipeSegment)
                  .WithMany(s => s.Inspections)
                  .HasForeignKey(e => e.PipeSegmentId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Anomaly>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.AnomalyType).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Severity).HasMaxLength(50);
            entity.Property(e => e.ClockPosition).HasMaxLength(10);
            entity.HasOne(e => e.Inspection)
                  .WithMany(i => i.Anomalies)
                  .HasForeignKey(e => e.InspectionId)
                  .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.PipeSegment)
                  .WithMany(s => s.Anomalies)
                  .HasForeignKey(e => e.PipeSegmentId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        SeedData.Seed(modelBuilder);
    }
}
