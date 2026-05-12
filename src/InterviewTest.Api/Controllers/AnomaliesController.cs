using InterviewTest.Core.Entities;
using InterviewTest.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnomaliesController : ControllerBase
{
    private readonly AppDbContext _context;

    public AnomaliesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll(string? anomalyType, string? severity)
    {
        var anomalies = _context.Anomalies.ToList();

        if (!string.IsNullOrEmpty(anomalyType))
        {
            anomalies = anomalies.Where(a => a.AnomalyType == anomalyType).ToList();
        }

        if (!string.IsNullOrEmpty(severity))
        {
            anomalies = anomalies.Where(a => a.Severity == severity).ToList();
        }

        return Ok(anomalies);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var anomaly = _context.Anomalies
            .Include(a => a.Inspection)
            .Include(a => a.PipeSegment)
            .FirstOrDefaultAsync(a => a.Id == id).Result;

        return Ok(anomaly);
    }

    [HttpPost]
    public IActionResult CreateAnomaly(Anomaly anomaly)
    {
        string severity;
        if (anomaly.DepthPercent > 80)
        {
            severity = "Critical";
        }
        else if (anomaly.DepthPercent > 50)
        {
            severity = "High";
        }
        else if (anomaly.DepthPercent > 25)
        {
            severity = "Medium";
        }
        else
        {
            severity = "Low";
        }

        if (anomaly.AnomalyType == "Crack")
        {
            if (severity == "Low")
            {
                severity = "Medium";
            }
            else if (severity == "Medium")
            {
                severity = "High";
            }
            else if (severity == "High")
            {
                severity = "Critical";
            }
        }

        anomaly.Severity = severity;

        if (severity == "Critical")
        {
            anomaly.RepairDeadline = DateTime.Now.AddDays(7);
        }
        else if (severity == "High")
        {
            anomaly.RepairDeadline = DateTime.Now.AddDays(30);
        }
        else if (severity == "Medium")
        {
            anomaly.RepairDeadline = DateTime.Now.AddDays(90);
        }
        else
        {
            anomaly.RepairDeadline = DateTime.Now.AddDays(365);
        }

        if (severity == "Critical" || severity == "High")
        {
            anomaly.RepairRequired = true;
        }
        else if (severity == "Medium" && anomaly.DepthPercent > 40)
        {
            anomaly.RepairRequired = true;
        }
        else
        {
            anomaly.RepairRequired = false;
        }

        _context.Anomalies.Add(anomaly);
        var rowsAffected = _context.SaveChangesAsync().Result;

        var created = _context.Anomalies
            .Include(a => a.Inspection)
            .Include(a => a.PipeSegment)
            .FirstOrDefaultAsync(a => a.Id == anomaly.Id).Result;

        return Ok(created);
    }
}
