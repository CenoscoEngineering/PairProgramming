using InterviewTest.Core.Entities;
using InterviewTest.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InspectionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public InspectionsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll(string? inspectionType, string? status, DateTime? fromDate, DateTime? toDate)
    {
        var inspections = _context.Inspections.ToList();

        foreach (var inspection in inspections)
        {
            inspection.PipeSegment = _context.PipeSegments.FirstOrDefault(s => s.Id == inspection.PipeSegmentId)!;
            if (inspection.PipeSegment != null)
            {
                inspection.PipeSegment.Pipeline = _context.Pipelines
                    .FirstOrDefault(p => p.Id == inspection.PipeSegment.PipelineId)!;
            }
        }

        if (!string.IsNullOrEmpty(inspectionType))
        {
            inspections = inspections.Where(i => i.InspectionType == inspectionType).ToList();
        }

        if (!string.IsNullOrEmpty(status))
        {
            inspections = inspections.Where(i => i.Status == status).ToList();
        }

        if (fromDate.HasValue)
        {
            inspections = inspections.Where(i => i.InspectionDate >= fromDate.Value).ToList();
        }

        if (toDate.HasValue)
        {
            inspections = inspections.Where(i => i.InspectionDate <= toDate.Value).ToList();
        }

        return Ok(inspections);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var inspection = _context.Inspections.FirstOrDefault(i => i.Id == id);

        if (inspection != null)
        {
            inspection.PipeSegment = _context.PipeSegments.FirstOrDefault(s => s.Id == inspection.PipeSegmentId)!;
            if (inspection.PipeSegment != null)
            {
                inspection.PipeSegment.Pipeline = _context.Pipelines
                    .FirstOrDefault(p => p.Id == inspection.PipeSegment.PipelineId)!;
            }
        }

        return Ok(inspection);
    }
}
