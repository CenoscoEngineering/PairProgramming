using InterviewTest.Core.DTOs;
using InterviewTest.Core.Entities;
using InterviewTest.Core.Interfaces;
using InterviewTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Infrastructure.Repositories;

public class PipeSegmentRepository : IPipeSegmentRepository
{
    private readonly AppDbContext _context;

    public PipeSegmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PipeSegmentDto>> GetAllAsync(
        int? pipelineId = null,
        string? searchTerm = null,
        int page = 1,
        int pageSize = 20)
    {
        var query = _context.PipeSegments.AsNoTracking().AsQueryable();

        if (pipelineId.HasValue)
            query = query.Where(s => s.PipelineId == pipelineId.Value);

        if (!string.IsNullOrWhiteSpace(searchTerm))
            query = query.Where(s => s.SegmentName.Contains(searchTerm));

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(s => new PipeSegmentDto(
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
            ))
            .ToListAsync();
    }

    public async Task<PipeSegmentDto?> GetByIdAsync(int id)
    {
        return await _context.PipeSegments
            .AsNoTracking()
            .Where(s => s.Id == id)
            .Select(s => new PipeSegmentDto(
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
            ))
            .FirstOrDefaultAsync();
    }

    public async Task<PipeSegment> CreateAsync(PipeSegment segment)
    {
        _context.PipeSegments.Add(segment);
        await _context.SaveChangesAsync();
        return segment;
    }

    public async Task<PipeSegment?> UpdateAsync(PipeSegment segment)
    {
        var existing = await _context.PipeSegments.FindAsync(segment.Id);
        if (existing is null)
            return null;

        existing.SegmentName = segment.SegmentName;
        existing.StartKP = segment.StartKP;
        existing.EndKP = segment.EndKP;
        existing.WallThicknessNominalMm = segment.WallThicknessNominalMm;
        existing.WallThicknessMeasuredMm = segment.WallThicknessMeasuredMm;
        existing.CoatingType = segment.CoatingType;
        existing.SoilType = segment.SoilType;

        await _context.SaveChangesAsync();
        return existing;
    }
}
