using InterviewTest.Core.DTOs;
using InterviewTest.Core.Entities;

namespace InterviewTest.Core.Interfaces;

public interface IAnomalyRepository
{
    Task<IEnumerable<AnomalyDto>> GetAllAsync(string? anomalyType = null, string? severity = null);
    Task<AnomalyDto?> GetByIdAsync(int id);
    Task<Anomaly> CreateAsync(Anomaly anomaly);
    Task<IEnumerable<AnomalyDto>> GetByInspectionIdAsync(int inspectionId);
}
