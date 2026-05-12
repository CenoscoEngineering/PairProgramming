using InterviewTest.Core.DTOs;
using InterviewTest.Core.Entities;

namespace InterviewTest.Core.Interfaces;

public interface IPipeSegmentRepository
{
    Task<IEnumerable<PipeSegmentDto>> GetAllAsync(int? pipelineId = null, string? searchTerm = null, int page = 1, int pageSize = 20);
    Task<PipeSegmentDto?> GetByIdAsync(int id);
    Task<PipeSegment> CreateAsync(PipeSegment segment);
    Task<PipeSegment?> UpdateAsync(PipeSegment segment);
}
