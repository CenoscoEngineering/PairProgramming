namespace InterviewTest.Core.Entities;

public class Pipeline
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string OperatorName { get; set; } = string.Empty;
    public string Material { get; set; } = string.Empty;
    public double DiameterInches { get; set; }
    public double LengthKm { get; set; }
    public double MaxOperatingPressurePsi { get; set; }
    public DateTime InstallationDate { get; set; }
    public string Status { get; set; } = "Active"; // Active, Inactive, Decommissioned

    public ICollection<PipeSegment> Segments { get; set; } = new List<PipeSegment>();
}
