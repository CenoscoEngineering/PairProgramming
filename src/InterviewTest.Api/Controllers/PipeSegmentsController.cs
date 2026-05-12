using InterviewTest.Core.Entities;
using InterviewTest.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PipeSegmentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PipeSegmentsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll(int? pipelineId, string? searchTerm, int page = 1, int pageSize = 20)
    {
        List<PipeSegment> segments;

        if (!string.IsNullOrEmpty(searchTerm))
        {
            segments = _context.PipeSegments
                .Where(s => s.SegmentName.Contains(searchTerm))
                .ToList();
        }
        else
        {
            segments = _context.PipeSegments.ToList();
        }

        if (pipelineId.HasValue)
        {
            segments = segments.Where(s => s.PipelineId == pipelineId.Value).ToList();
        }

        var totalCount = segments.Count;
        segments = segments.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return Ok(segments);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var segment = _context.PipeSegments
            .Include(s => s.Pipeline)
            .FirstOrDefault(s => s.Id == id);

        return Ok(segment);
    }

    [HttpPost]
    public IActionResult Create(PipeSegment segment)
    {
        _context.PipeSegments.Add(segment);
        _context.SaveChanges();

        return Ok(segment);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, PipeSegment segment)
    {
        segment.Id = id;
        _context.PipeSegments.Update(segment);
        _context.SaveChanges();

        return Ok();
    }
}
