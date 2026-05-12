using InterviewTest.Core.DTOs;

namespace InterviewTest.Core.Interfaces;

public interface IPipelineRepository
{
    Task<IEnumerable<PipelineDto>> GetAllAsync();
    Task<PipelineDetailDto?> GetByIdAsync(int id);
    Task<PipelineDto> CreateAsync(CreatePipelineDto pipeline);
    Task<bool> ExistsByNameAsync(string name);
    Task<bool> HasSegmentsAsync(int id);
    Task<bool> DeleteAsync(int id);
}
