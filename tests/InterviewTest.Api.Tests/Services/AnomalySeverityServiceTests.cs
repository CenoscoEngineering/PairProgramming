using InterviewTest.Core.Interfaces;
using Xunit;

namespace InterviewTest.Api.Tests.Services;

/// <summary>
/// TDD Exercise: Anomaly Severity Service Tests
/// 
/// Instructions:
/// 1. Read the IAnomalySeverityService interface to understand the business rules
/// 2. Implement each test method below (write the test FIRST)
/// 3. Run the tests — they should all FAIL (Red)
/// 4. Implement AnomalySeverityService to make the tests pass (Green)
/// 5. Refactor if needed
/// 
/// Business Rules (also documented in IAnomalySeverityService):
/// 
/// Severity Classification:
///   - Depth > 80% → Critical
///   - Depth > 50% → High  
///   - Depth > 25% → Medium
///   - Depth ≤ 25% → Low
///   - Cracks increase severity by one level (Low→Medium, Medium→High, High→Critical)
///   - Critical cannot go higher (stays Critical)
///
/// Repair Deadlines (from reference date):
///   - Critical: +7 days
///   - High: +30 days
///   - Medium: +90 days
///   - Low: +365 days
///
/// Repair Required:
///   - Critical and High: always required
///   - Medium: required if depth > 40%
///   - Low: not required
///
/// Validation:
///   - depthPercent must be 0-100 (throw ArgumentException otherwise)
/// </summary>
public class AnomalySeverityServiceTests
{
    // TODO: Create an instance of AnomalySeverityService to test
    // Hint: private readonly IAnomalySeverityService _service = new AnomalySeverityService();

    [Fact]
    public void ClassifySeverity_DepthOver80_ReturnsCritical()
    {
        // TODO: Arrange — create service, set depthPercent = 85, anomalyType = "Corrosion"
        // TODO: Act — call ClassifySeverity
        // TODO: Assert — result should be "Critical"
        throw new NotImplementedException("Implement this test first, then implement the service");
    }

    [Fact]
    public void ClassifySeverity_DepthOver50_ReturnsHigh()
    {
        // TODO: Test that depth 55% with "Corrosion" returns "High"
        throw new NotImplementedException("Implement this test");
    }

    [Fact]
    public void ClassifySeverity_DepthOver25_ReturnsMedium()
    {
        // TODO: Test that depth 35% with "Corrosion" returns "Medium"
        throw new NotImplementedException("Implement this test");
    }

    [Fact]
    public void ClassifySeverity_DepthUnder25_ReturnsLow()
    {
        // TODO: Test that depth 15% with "Corrosion" returns "Low"
        throw new NotImplementedException("Implement this test");
    }

    [Fact]
    public void ClassifySeverity_CrackType_IncreasesSeverityByOneLevel()
    {
        // TODO: Test that depth 35% (normally Medium) with "Crack" returns "High"
        throw new NotImplementedException("Implement this test");
    }

    [Fact]
    public void ClassifySeverity_CrackAt80Percent_StaysAtCritical()
    {
        // TODO: Test that depth 85% with "Crack" still returns "Critical" (can't go higher)
        throw new NotImplementedException("Implement this test");
    }

    [Fact]
    public void ClassifySeverity_NegativeDepth_ThrowsArgumentException()
    {
        // TODO: Test that depth -5 throws ArgumentException
        throw new NotImplementedException("Implement this test");
    }

    [Fact]
    public void ClassifySeverity_DepthOver100_ThrowsArgumentException()
    {
        // TODO: Test that depth 105 throws ArgumentException
        throw new NotImplementedException("Implement this test");
    }

    [Fact]
    public void CalculateRepairDeadline_CriticalSeverity_Returns7Days()
    {
        // TODO: Test that "Critical" severity with reference date 2024-01-01 returns 2024-01-08
        throw new NotImplementedException("Implement this test");
    }

    [Fact]
    public void CalculateRepairDeadline_HighSeverity_Returns30Days()
    {
        // TODO: Test that "High" severity returns reference date + 30 days
        throw new NotImplementedException("Implement this test");
    }

    [Fact]
    public void CalculateRepairDeadline_MediumSeverity_Returns90Days()
    {
        // TODO: Test that "Medium" severity returns reference date + 90 days
        throw new NotImplementedException("Implement this test");
    }

    [Fact]
    public void CalculateRepairDeadline_LowSeverity_Returns365Days()
    {
        // TODO: Test that "Low" severity returns reference date + 365 days
        throw new NotImplementedException("Implement this test");
    }

    [Fact]
    public void IsRepairRequired_CriticalSeverity_ReturnsTrue()
    {
        // TODO: Test that "Critical" always requires repair
        throw new NotImplementedException("Implement this test");
    }

    [Fact]
    public void IsRepairRequired_HighSeverity_ReturnsTrue()
    {
        // TODO: Test that "High" always requires repair
        throw new NotImplementedException("Implement this test");
    }

    [Fact]
    public void IsRepairRequired_MediumSeverity_DepthOver40_ReturnsTrue()
    {
        // TODO: Test that "Medium" with depth 45% requires repair
        throw new NotImplementedException("Implement this test");
    }

    [Fact]
    public void IsRepairRequired_MediumSeverity_DepthUnder40_ReturnsFalse()
    {
        // TODO: Test that "Medium" with depth 30% does NOT require repair
        throw new NotImplementedException("Implement this test");
    }

    [Fact]
    public void IsRepairRequired_LowSeverity_ReturnsFalse()
    {
        // TODO: Test that "Low" does not require repair
        throw new NotImplementedException("Implement this test");
    }
}
