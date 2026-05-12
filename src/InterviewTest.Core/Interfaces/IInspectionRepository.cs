using InterviewTest.Core.DTOs;
using InterviewTest.Core.Entities;

namespace InterviewTest.Core.Interfaces;

public interface IInspectionRepository
{
    Task<IEnumerable<InspectionDto>> GetAllAsync(string? inspectionType = null, string? status = null, DateTime? fromDate = null, DateTime? toDate = null);
    Task<InspectionDto?> GetByIdAsync(int id);
    Task<Inspection> CreateAsync(Inspection inspection);
}
