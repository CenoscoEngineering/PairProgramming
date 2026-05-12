using InterviewTest.Core.DTOs;
using InterviewTest.Core.Entities;
using InterviewTest.Core.Interfaces;
using InterviewTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Infrastructure.Repositories;

public class InspectionRepository : IInspectionRepository
{
    private readonly AppDbContext _context;

    public InspectionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InspectionDto>> GetAllAsync(
        string? inspectionType = null,
        string? status = null,
        DateTime? fromDate = null,
        DateTime? toDate = null)
    {
        var query = _context.Inspections.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(inspectionType))
            query = query.Where(i => i.InspectionType == inspectionType);

        if (!string.IsNullOrWhiteSpace(status))
            query = query.Where(i => i.Status == status);

        if (fromDate.HasValue)
            query = query.Where(i => i.InspectionDate >= fromDate.Value);

        if (toDate.HasValue)
            query = query.Where(i => i.InspectionDate <= toDate.Value);

        return await query
            .Select(i => new InspectionDto(
                i.Id,
                i.PipeSegmentId,
                i.PipeSegment.SegmentName,
                i.PipeSegment.Pipeline.Name,
                i.InspectionDate,
                i.InspectionType,
                i.Inspector,
                i.Status,
                i.Notes,
                i.Anomalies.Count
            ))
            .ToListAsync();
    }

    public async Task<InspectionDto?> GetByIdAsync(int id)
    {
        return await _context.Inspections
            .AsNoTracking()
            .Where(i => i.Id == id)
            .Select(i => new InspectionDto(
                i.Id,
                i.PipeSegmentId,
                i.PipeSegment.SegmentName,
                i.PipeSegment.Pipeline.Name,
                i.InspectionDate,
                i.InspectionType,
                i.Inspector,
                i.Status,
                i.Notes,
                i.Anomalies.Count
            ))
            .FirstOrDefaultAsync();
    }

    public async Task<Inspection> CreateAsync(Inspection inspection)
    {
        _context.Inspections.Add(inspection);
        await _context.SaveChangesAsync();
        return inspection;
    }
}
