using InterviewTest.Core.Entities;
using InterviewTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InterviewTest.Api.Tests.Controllers;

/// <summary>
/// Tests for InspectionsController.
/// 
/// CODE REVIEW: These tests contain several test smells. Can you identify them?
/// </summary>
public class InspectionsControllerTests
{    
    private static List<Inspection> _testInspections = new()
    {
        new Inspection { Id = 101, PipeSegmentId = 1, InspectionDate = DateTime.Now.AddDays(-30), InspectionType = "ILI", Inspector = "John", Status = "Completed" },
        new Inspection { Id = 102, PipeSegmentId = 1, InspectionDate = DateTime.Now.AddDays(-15), InspectionType = "UT", Inspector = "Jane", Status = "Completed" },
        new Inspection { Id = 103, PipeSegmentId = 2, InspectionDate = DateTime.Now.AddDays(-5), InspectionType = "Visual", Inspector = "Bob", Status = "Scheduled" },
    };

    private static AppDbContext _sharedContext = null!;

    private AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var context = new AppDbContext(options);
        context.Database.EnsureCreated();
        return context;
    }

    [Fact]
    public void Test_GetAllInspections_And_FilterByType_And_CheckCount()
    {
        var context = CreateContext();

        context.Inspections.Add(_testInspections[0]);
        context.Inspections.Add(_testInspections[1]);
        context.SaveChanges();
        var countAfterAdd = context.Inspections.Count();
        Assert.True(countAfterAdd >= 2);

        _testInspections.Add(new Inspection { Id = 104, PipeSegmentId = 2, InspectionDate = DateTime.Now, InspectionType = "ILI", Inspector = "Sarah", Status = "InProgress" });

        context.Inspections.Add(_testInspections[3]);
        context.SaveChanges();
        Assert.True(context.Inspections.Count() > countAfterAdd);

        var iliInspections = context.Inspections.Where(i => i.InspectionType == "ILI").ToList();
        Assert.NotNull(iliInspections);
        Assert.True(iliInspections.Count > 0);
    }

    [Fact]
    public void Test_GetInspectionById()
    {
        var context = CreateContext();

        var result = context.Inspections.FirstOrDefault();
        Assert.NotNull(result);
    }

    [Fact]
    public void Test_InspectionDates()
    {
        var inspection = new Inspection
        {
            Id = 99,
            PipeSegmentId = 1,
            InspectionDate = DateTime.Now,
            InspectionType = "MFL",
            Inspector = "Test",
            Status = "Scheduled"
        };

        Assert.True(inspection.InspectionDate <= DateTime.Now);
        Assert.Equal("MFL", inspection.InspectionType);
    }

    [Fact]
    public void Test_CreateInspection_DoesNotThrow()
    {
        var context = CreateContext();

        var exception = Record.Exception(() =>
        {
            context.Inspections.Add(new Inspection
            {
                PipeSegmentId = 1,
                InspectionDate = DateTime.Now,
                InspectionType = "UT",
                Inspector = "Test",
                Status = "Scheduled"
            });
            context.SaveChanges();
        });

        Assert.Null(exception);
    }
}
