namespace InterviewTest.Core.Entities;

public class PipeSegment
{
    public int Id { get; set; }
    public int PipelineId { get; set; }
    public string SegmentName { get; set; } = string.Empty;
    public double StartKP { get; set; }
    public double EndKP { get; set; }
    public double WallThicknessNominalMm { get; set; }
    public double WallThicknessMeasuredMm { get; set; }
    public string CoatingType { get; set; } = string.Empty; // FBE, 3LPE, 3LPP, Bare
    public string SoilType { get; set; } = string.Empty; // Clay, Sand, Rock, Loam

    public Pipeline Pipeline { get; set; } = null!;
    public ICollection<Inspection> Inspections { get; set; } = new List<Inspection>();
    public ICollection<Anomaly> Anomalies { get; set; } = new List<Anomaly>();
}
