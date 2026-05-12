using InterviewTest.Core.DTOs;
using InterviewTest.Core.Entities;
using InterviewTest.Core.Interfaces;
using InterviewTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Infrastructure.Repositories;

public class PipelineRepository : IPipelineRepository
{
    private readonly AppDbContext _context;

    public PipelineRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PipelineDto>> GetAllAsync()
    {
        return await _context.Pipelines
            .AsNoTracking()
            .Select(p => new PipelineDto(
                p.Id,
                p.Name,
                p.OperatorName,
                p.Material,
                p.DiameterInches,
                p.LengthKm,
                p.MaxOperatingPressurePsi,
                p.InstallationDate,
                p.Status,
                p.Segments.Count
            ))
            .ToListAsync();
    }

    public async Task<PipelineDetailDto?> GetByIdAsync(int id)
    {
        return await _context.Pipelines
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Select(p => new PipelineDetailDto(
                p.Id,
                p.Name,
                p.OperatorName,
                p.Material,
                p.DiameterInches,
                p.LengthKm,
                p.MaxOperatingPressurePsi,
                p.InstallationDate,
                p.Status,
                p.Segments.Select(s => new PipeSegmentDto(
                    s.Id,
                    s.PipelineId,
                    s.SegmentName,
                    s.StartKP,
                    s.EndKP,
                    s.WallThicknessNominalMm,
                    s.WallThicknessMeasuredMm,
                    s.CoatingType,
                    s.SoilType,
                    s.Inspections.Count,
                    s.Anomalies.Count
                )).ToList()
            ))
            .FirstOrDefaultAsync();
    }

    public async Task<PipelineDto> CreateAsync(CreatePipelineDto dto)
    {
        var pipeline = new Pipeline
        {
            Name = dto.Name,
            OperatorName = dto.OperatorName,
            Material = dto.Material,
            DiameterInches = dto.DiameterInches,
            LengthKm = dto.LengthKm,
            MaxOperatingPressurePsi = dto.MaxOperatingPressurePsi,
            InstallationDate = dto.InstallationDate
        };

        _context.Pipelines.Add(pipeline);
        await _context.SaveChangesAsync();

        return new PipelineDto(
            pipeline.Id,
            pipeline.Name,
            pipeline.OperatorName,
            pipeline.Material,
            pipeline.DiameterInches,
            pipeline.LengthKm,
            pipeline.MaxOperatingPressurePsi,
            pipeline.InstallationDate,
            pipeline.Status,
            0
        );
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Pipelines
            .AsNoTracking()
            .AnyAsync(p => p.Name == name);
    }

    public async Task<bool> HasSegmentsAsync(int id)
    {
        return await _context.PipeSegments
            .AsNoTracking()
            .AnyAsync(s => s.PipelineId == id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pipeline = await _context.Pipelines.FindAsync(id);
        if (pipeline is null)
            return false;

        _context.Pipelines.Remove(pipeline);
        await _context.SaveChangesAsync();
        return true;
    }
}
