namespace InterviewTest.Core.DTOs;

public record PipelineDto(
    int Id,
    string Name,
    string OperatorName,
    string Material,
    double DiameterInches,
    double LengthKm,
    double MaxOperatingPressurePsi,
    DateTime InstallationDate,
    string Status,
    int SegmentCount
);

public record PipelineDetailDto(
    int Id,
    string Name,
    string OperatorName,
    string Material,
    double DiameterInches,
    double LengthKm,
    double MaxOperatingPressurePsi,
    DateTime InstallationDate,
    string Status,
    List<PipeSegmentDto> Segments
);

public record PipeSegmentDto(
    int Id,
    int PipelineId,
    string SegmentName,
    double StartKP,
    double EndKP,
    double WallThicknessNominalMm,
    double WallThicknessMeasuredMm,
    string CoatingType,
    string SoilType,
    int InspectionCount,
    int AnomalyCount
);

public record InspectionDto(
    int Id,
    int PipeSegmentId,
    string PipeSegmentName,
    string PipelineName,
    DateTime InspectionDate,
    string InspectionType,
    string Inspector,
    string Status,
    string? Notes,
    int AnomalyCount
);

public record AnomalyDto(
    int Id,
    int InspectionId,
    int PipeSegmentId,
    string PipeSegmentName,
    string AnomalyType,
    string Severity,
    double DepthPercent,
    double LengthMm,
    double WidthMm,
    string? ClockPosition,
    double DistanceFromUpstreamKP,
    bool RepairRequired,
    DateTime? RepairDeadline
);

public record CreatePipelineDto(
    string Name,
    string OperatorName,
    string Material,
    double DiameterInches,
    double LengthKm,
    double MaxOperatingPressurePsi,
    DateTime InstallationDate
);

public record CreateAnomalyDto(
    int InspectionId,
    int PipeSegmentId,
    string AnomalyType,
    double DepthPercent,
    double LengthMm,
    double WidthMm,
    string? ClockPosition,
    double DistanceFromUpstreamKP
);

public record SeverityResult(
    string Severity,
    bool RepairRequired,
    DateTime RepairDeadline
);
