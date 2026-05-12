using InterviewTest.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Infrastructure.Data;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var pipelines = new[]
        {
            new Pipeline { Id = 1, Name = "Northern Trunk Line", OperatorName = "NorthSea Energy", Material = "Carbon Steel", DiameterInches = 36, LengthKm = 142.5, MaxOperatingPressurePsi = 1440, InstallationDate = new DateTime(1998, 6, 15), Status = "Active" },
            new Pipeline { Id = 2, Name = "Southern Export Pipeline", OperatorName = "Gulf Pipelines Ltd", Material = "Carbon Steel", DiameterInches = 24, LengthKm = 87.3, MaxOperatingPressurePsi = 1200, InstallationDate = new DateTime(2005, 3, 22), Status = "Active" },
            new Pipeline { Id = 3, Name = "Coastal Feeder Line", OperatorName = "NorthSea Energy", Material = "Duplex Stainless", DiameterInches = 16, LengthKm = 34.8, MaxOperatingPressurePsi = 2100, InstallationDate = new DateTime(2015, 11, 8), Status = "Active" },
        };
        modelBuilder.Entity<Pipeline>().HasData(pipelines);

        var segments = new[]
        {
            // Northern Trunk Line segments
            new PipeSegment { Id = 1, PipelineId = 1, SegmentName = "NTL-SEG-001", StartKP = 0, EndKP = 15.2, WallThicknessNominalMm = 19.1, WallThicknessMeasuredMm = 17.8, CoatingType = "3LPE", SoilType = "Clay" },
            new PipeSegment { Id = 2, PipelineId = 1, SegmentName = "NTL-SEG-002", StartKP = 15.2, EndKP = 32.7, WallThicknessNominalMm = 19.1, WallThicknessMeasuredMm = 16.2, CoatingType = "3LPE", SoilType = "Sand" },
            new PipeSegment { Id = 3, PipelineId = 1, SegmentName = "NTL-SEG-003", StartKP = 32.7, EndKP = 55.0, WallThicknessNominalMm = 19.1, WallThicknessMeasuredMm = 18.5, CoatingType = "FBE", SoilType = "Rock" },
            new PipeSegment { Id = 4, PipelineId = 1, SegmentName = "NTL-SEG-004", StartKP = 55.0, EndKP = 78.3, WallThicknessNominalMm = 19.1, WallThicknessMeasuredMm = 15.1, CoatingType = "3LPE", SoilType = "Loam" },
            // Southern Export Pipeline segments
            new PipeSegment { Id = 5, PipelineId = 2, SegmentName = "SEP-SEG-001", StartKP = 0, EndKP = 22.1, WallThicknessNominalMm = 15.9, WallThicknessMeasuredMm = 14.7, CoatingType = "FBE", SoilType = "Sand" },
            new PipeSegment { Id = 6, PipelineId = 2, SegmentName = "SEP-SEG-002", StartKP = 22.1, EndKP = 48.5, WallThicknessNominalMm = 15.9, WallThicknessMeasuredMm = 13.2, CoatingType = "FBE", SoilType = "Clay" },
            new PipeSegment { Id = 7, PipelineId = 2, SegmentName = "SEP-SEG-003", StartKP = 48.5, EndKP = 87.3, WallThicknessNominalMm = 15.9, WallThicknessMeasuredMm = 15.0, CoatingType = "3LPP", SoilType = "Rock" },
            // Coastal Feeder Line segments
            new PipeSegment { Id = 8, PipelineId = 3, SegmentName = "CFL-SEG-001", StartKP = 0, EndKP = 12.0, WallThicknessNominalMm = 12.7, WallThicknessMeasuredMm = 12.3, CoatingType = "3LPP", SoilType = "Sand" },
            new PipeSegment { Id = 9, PipelineId = 3, SegmentName = "CFL-SEG-002", StartKP = 12.0, EndKP = 24.5, WallThicknessNominalMm = 12.7, WallThicknessMeasuredMm = 11.9, CoatingType = "3LPP", SoilType = "Clay" },
            new PipeSegment { Id = 10, PipelineId = 3, SegmentName = "CFL-SEG-003", StartKP = 24.5, EndKP = 34.8, WallThicknessNominalMm = 12.7, WallThicknessMeasuredMm = 12.5, CoatingType = "FBE", SoilType = "Loam" },
        };
        modelBuilder.Entity<PipeSegment>().HasData(segments);

        var inspections = new[]
        {
            new Inspection { Id = 1, PipeSegmentId = 1, InspectionDate = new DateTime(2024, 1, 15), InspectionType = "ILI", Inspector = "John Smith", Status = "Completed", Notes = "Inline inspection using MFL tool" },
            new Inspection { Id = 2, PipeSegmentId = 1, InspectionDate = new DateTime(2024, 6, 20), InspectionType = "Visual", Inspector = "Jane Doe", Status = "Completed", Notes = "External visual inspection of exposed section" },
            new Inspection { Id = 3, PipeSegmentId = 2, InspectionDate = new DateTime(2024, 2, 10), InspectionType = "UT", Inspector = "Bob Wilson", Status = "Completed", Notes = "Ultrasonic thickness measurement at 12 locations" },
            new Inspection { Id = 4, PipeSegmentId = 2, InspectionDate = new DateTime(2024, 8, 5), InspectionType = "ILI", Inspector = "John Smith", Status = "Completed", Notes = "Follow-up ILI after corrosion detection" },
            new Inspection { Id = 5, PipeSegmentId = 3, InspectionDate = new DateTime(2024, 3, 18), InspectionType = "MFL", Inspector = "Sarah Johnson", Status = "Completed", Notes = "Magnetic flux leakage inspection" },
            new Inspection { Id = 6, PipeSegmentId = 4, InspectionDate = new DateTime(2024, 4, 22), InspectionType = "Visual", Inspector = "Jane Doe", Status = "Completed", Notes = "Annual visual inspection" },
            new Inspection { Id = 7, PipeSegmentId = 4, InspectionDate = new DateTime(2024, 9, 10), InspectionType = "UT", Inspector = "Bob Wilson", Status = "InProgress", Notes = "Targeted UT on suspected thinning area" },
            new Inspection { Id = 8, PipeSegmentId = 5, InspectionDate = new DateTime(2024, 5, 12), InspectionType = "ILI", Inspector = "Sarah Johnson", Status = "Completed", Notes = "Baseline ILI for Southern Export" },
            new Inspection { Id = 9, PipeSegmentId = 6, InspectionDate = new DateTime(2024, 5, 14), InspectionType = "ILI", Inspector = "Sarah Johnson", Status = "Completed", Notes = "Continued ILI run" },
            new Inspection { Id = 10, PipeSegmentId = 6, InspectionDate = new DateTime(2024, 10, 1), InspectionType = "Visual", Inspector = "Mike Brown", Status = "Scheduled", Notes = null },
            new Inspection { Id = 11, PipeSegmentId = 7, InspectionDate = new DateTime(2024, 5, 16), InspectionType = "ILI", Inspector = "Sarah Johnson", Status = "Completed", Notes = "End section of Southern Export" },
            new Inspection { Id = 12, PipeSegmentId = 8, InspectionDate = new DateTime(2024, 7, 8), InspectionType = "UT", Inspector = "Bob Wilson", Status = "Completed", Notes = "Routine UT survey" },
            new Inspection { Id = 13, PipeSegmentId = 9, InspectionDate = new DateTime(2024, 7, 10), InspectionType = "Visual", Inspector = "Jane Doe", Status = "Completed", Notes = "Coating condition assessment" },
            new Inspection { Id = 14, PipeSegmentId = 10, InspectionDate = new DateTime(2024, 7, 12), InspectionType = "MFL", Inspector = "John Smith", Status = "Completed", Notes = "MFL baseline for new coating" },
            new Inspection { Id = 15, PipeSegmentId = 1, InspectionDate = new DateTime(2025, 1, 10), InspectionType = "ILI", Inspector = "John Smith", Status = "Scheduled", Notes = "Annual re-inspection" },
            new Inspection { Id = 16, PipeSegmentId = 3, InspectionDate = new DateTime(2025, 2, 15), InspectionType = "UT", Inspector = "Mike Brown", Status = "Scheduled", Notes = null },
            new Inspection { Id = 17, PipeSegmentId = 5, InspectionDate = new DateTime(2024, 11, 20), InspectionType = "Visual", Inspector = "Jane Doe", Status = "Completed", Notes = "Post-repair verification" },
            new Inspection { Id = 18, PipeSegmentId = 2, InspectionDate = new DateTime(2025, 3, 1), InspectionType = "MFL", Inspector = "Sarah Johnson", Status = "Scheduled", Notes = null },
            new Inspection { Id = 19, PipeSegmentId = 7, InspectionDate = new DateTime(2024, 12, 5), InspectionType = "UT", Inspector = "Bob Wilson", Status = "Completed", Notes = "Weld inspection at river crossing" },
            new Inspection { Id = 20, PipeSegmentId = 4, InspectionDate = new DateTime(2024, 11, 30), InspectionType = "ILI", Inspector = "John Smith", Status = "Completed", Notes = "Re-run after anomaly discovery" },
        };
        modelBuilder.Entity<Inspection>().HasData(inspections);

        var anomalies = new[]
        {
            new Anomaly { Id = 1, InspectionId = 1, PipeSegmentId = 1, AnomalyType = "Corrosion", Severity = "Medium", DepthPercent = 35, LengthMm = 120, WidthMm = 45, ClockPosition = "6:00", DistanceFromUpstreamKP = 3.2, RepairRequired = false, RepairDeadline = new DateTime(2024, 10, 15) },
            new Anomaly { Id = 2, InspectionId = 1, PipeSegmentId = 1, AnomalyType = "Corrosion", Severity = "High", DepthPercent = 55, LengthMm = 200, WidthMm = 80, ClockPosition = "5:00", DistanceFromUpstreamKP = 7.8, RepairRequired = true, RepairDeadline = new DateTime(2024, 2, 14) },
            new Anomaly { Id = 3, InspectionId = 3, PipeSegmentId = 2, AnomalyType = "Crack", Severity = "Critical", DepthPercent = 45, LengthMm = 50, WidthMm = 2, ClockPosition = "12:00", DistanceFromUpstreamKP = 18.5, RepairRequired = true, RepairDeadline = new DateTime(2024, 2, 17) },
            new Anomaly { Id = 4, InspectionId = 4, PipeSegmentId = 2, AnomalyType = "Corrosion", Severity = "Low", DepthPercent = 15, LengthMm = 60, WidthMm = 30, ClockPosition = "3:00", DistanceFromUpstreamKP = 25.1, RepairRequired = false, RepairDeadline = new DateTime(2025, 8, 5) },
            new Anomaly { Id = 5, InspectionId = 5, PipeSegmentId = 3, AnomalyType = "Dent", Severity = "Medium", DepthPercent = 30, LengthMm = 150, WidthMm = 100, ClockPosition = "9:00", DistanceFromUpstreamKP = 40.2, RepairRequired = false, RepairDeadline = new DateTime(2024, 6, 18) },
            new Anomaly { Id = 6, InspectionId = 6, PipeSegmentId = 4, AnomalyType = "Gouge", Severity = "High", DepthPercent = 60, LengthMm = 80, WidthMm = 15, ClockPosition = "2:00", DistanceFromUpstreamKP = 62.0, RepairRequired = true, RepairDeadline = new DateTime(2024, 5, 22) },
            new Anomaly { Id = 7, InspectionId = 6, PipeSegmentId = 4, AnomalyType = "Corrosion", Severity = "Critical", DepthPercent = 85, LengthMm = 300, WidthMm = 120, ClockPosition = "6:00", DistanceFromUpstreamKP = 70.5, RepairRequired = true, RepairDeadline = new DateTime(2024, 4, 29) },
            new Anomaly { Id = 8, InspectionId = 8, PipeSegmentId = 5, AnomalyType = "WeldDefect", Severity = "Medium", DepthPercent = 28, LengthMm = 40, WidthMm = 40, ClockPosition = "12:00", DistanceFromUpstreamKP = 10.3, RepairRequired = false, RepairDeadline = new DateTime(2024, 8, 12) },
            new Anomaly { Id = 9, InspectionId = 9, PipeSegmentId = 6, AnomalyType = "Corrosion", Severity = "High", DepthPercent = 65, LengthMm = 180, WidthMm = 70, ClockPosition = "4:00", DistanceFromUpstreamKP = 30.7, RepairRequired = true, RepairDeadline = new DateTime(2024, 6, 13) },
            new Anomaly { Id = 10, InspectionId = 9, PipeSegmentId = 6, AnomalyType = "Crack", Severity = "Critical", DepthPercent = 40, LengthMm = 35, WidthMm = 1, ClockPosition = "11:00", DistanceFromUpstreamKP = 35.2, RepairRequired = true, RepairDeadline = new DateTime(2024, 5, 21) },
            new Anomaly { Id = 11, InspectionId = 11, PipeSegmentId = 7, AnomalyType = "Corrosion", Severity = "Low", DepthPercent = 12, LengthMm = 45, WidthMm = 25, ClockPosition = "8:00", DistanceFromUpstreamKP = 55.0, RepairRequired = false, RepairDeadline = new DateTime(2025, 5, 16) },
            new Anomaly { Id = 12, InspectionId = 12, PipeSegmentId = 8, AnomalyType = "Dent", Severity = "Low", DepthPercent = 10, LengthMm = 90, WidthMm = 60, ClockPosition = "7:00", DistanceFromUpstreamKP = 5.5, RepairRequired = false, RepairDeadline = new DateTime(2025, 7, 8) },
            new Anomaly { Id = 13, InspectionId = 14, PipeSegmentId = 10, AnomalyType = "Corrosion", Severity = "Medium", DepthPercent = 38, LengthMm = 95, WidthMm = 50, ClockPosition = "6:00", DistanceFromUpstreamKP = 28.1, RepairRequired = false, RepairDeadline = new DateTime(2024, 10, 12) },
            new Anomaly { Id = 14, InspectionId = 19, PipeSegmentId = 7, AnomalyType = "WeldDefect", Severity = "High", DepthPercent = 52, LengthMm = 30, WidthMm = 30, ClockPosition = "12:00", DistanceFromUpstreamKP = 60.8, RepairRequired = true, RepairDeadline = new DateTime(2025, 1, 4) },
            new Anomaly { Id = 15, InspectionId = 20, PipeSegmentId = 4, AnomalyType = "Corrosion", Severity = "Critical", DepthPercent = 90, LengthMm = 250, WidthMm = 150, ClockPosition = "5:00", DistanceFromUpstreamKP = 71.2, RepairRequired = true, RepairDeadline = new DateTime(2024, 12, 7) },
        };
        modelBuilder.Entity<Anomaly>().HasData(anomalies);
    }
}
