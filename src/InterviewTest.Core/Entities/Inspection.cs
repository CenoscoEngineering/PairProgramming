namespace InterviewTest.Core.Entities;

public class Inspection
{
    public int Id { get; set; }
    public int PipeSegmentId { get; set; }
    public DateTime InspectionDate { get; set; }
    public string InspectionType { get; set; } = string.Empty; // ILI, Visual, UT, MFL
    public string Inspector { get; set; } = string.Empty;
    public string Status { get; set; } = "Scheduled"; // Scheduled, InProgress, Completed, Cancelled
    public string? Notes { get; set; }

    public PipeSegment PipeSegment { get; set; } = null!;
    public ICollection<Anomaly> Anomalies { get; set; } = new List<Anomaly>();
}
