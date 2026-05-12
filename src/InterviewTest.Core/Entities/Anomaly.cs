namespace InterviewTest.Core.Entities;

public class Anomaly
{
    public int Id { get; set; }
    public int InspectionId { get; set; }
    public int PipeSegmentId { get; set; }
    public string AnomalyType { get; set; } = string.Empty; // Corrosion, Crack, Dent, Gouge, WeldDefect
    public string Severity { get; set; } = "Low"; // Low, Medium, High, Critical
    public double DepthPercent { get; set; }
    public double LengthMm { get; set; }
    public double WidthMm { get; set; }
    public string? ClockPosition { get; set; } // e.g., "6:00", "12:00"
    public double DistanceFromUpstreamKP { get; set; }
    public bool RepairRequired { get; set; }
    public DateTime? RepairDeadline { get; set; }

    public Inspection Inspection { get; set; } = null!;
    public PipeSegment PipeSegment { get; set; } = null!;
}
