using InterviewTest.Core.DTOs;
using InterviewTest.Core.Entities;
using InterviewTest.Core.Interfaces;
using InterviewTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Infrastructure.Repositories;

public class AnomalyRepository : IAnomalyRepository
{
    private readonly AppDbContext _context;

    public AnomalyRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AnomalyDto>> GetAllAsync(
        string? anomalyType = null,
        string? severity = null)
    {
        var query = _context.Anomalies.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(anomalyType))
            query = query.Where(a => a.AnomalyType == anomalyType);

        if (!string.IsNullOrWhiteSpace(severity))
            query = query.Where(a => a.Severity == severity);

        return await query
            .Select(a => new AnomalyDto(
                a.Id,
                a.InspectionId,
                a.PipeSegmentId,
                a.PipeSegment.SegmentName,
                a.AnomalyType,
                a.Severity,
                a.DepthPercent,
                a.LengthMm,
                a.WidthMm,
                a.ClockPosition,
                a.DistanceFromUpstreamKP,
                a.RepairRequired,
                a.RepairDeadline
            ))
            .ToListAsync();
    }

    public async Task<AnomalyDto?> GetByIdAsync(int id)
    {
        return await _context.Anomalies
            .AsNoTracking()
            .Where(a => a.Id == id)
            .Select(a => new AnomalyDto(
                a.Id,
                a.InspectionId,
                a.PipeSegmentId,
                a.PipeSegment.SegmentName,
                a.AnomalyType,
                a.Severity,
                a.DepthPercent,
                a.LengthMm,
                a.WidthMm,
                a.ClockPosition,
                a.DistanceFromUpstreamKP,
                a.RepairRequired,
                a.RepairDeadline
            ))
            .FirstOrDefaultAsync();
    }

    public async Task<Anomaly> CreateAsync(Anomaly anomaly)
    {
        _context.Anomalies.Add(anomaly);
        await _context.SaveChangesAsync();
        return anomaly;
    }

    public async Task<IEnumerable<AnomalyDto>> GetByInspectionIdAsync(int inspectionId)
    {
        return await _context.Anomalies
            .AsNoTracking()
            .Where(a => a.InspectionId == inspectionId)
            .Select(a => new AnomalyDto(
                a.Id,
                a.InspectionId,
                a.PipeSegmentId,
                a.PipeSegment.SegmentName,
                a.AnomalyType,
                a.Severity,
                a.DepthPercent,
                a.LengthMm,
                a.WidthMm,
                a.ClockPosition,
                a.DistanceFromUpstreamKP,
                a.RepairRequired,
                a.RepairDeadline
            ))
            .ToListAsync();
    }
}
