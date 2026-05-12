using InterviewTest.Core.Interfaces;

namespace InterviewTest.Infrastructure.Services;

/// <summary>
/// Service for classifying anomaly severity and calculating repair deadlines.
/// 
/// TODO: This class needs to be implemented as part of the TDD exercise.
/// See the IAnomalySeverityService interface for business rules documentation.
/// See AnomalySeverityServiceTests.cs for the test stubs to implement first.
/// </summary>
public class AnomalySeverityService : IAnomalySeverityService
{
    public string ClassifySeverity(double depthPercent, string anomalyType)
    {
        // TODO: Implement severity classification
        // Rules are documented in IAnomalySeverityService
        throw new NotImplementedException();
    }

    public DateTime CalculateRepairDeadline(string severity, DateTime referenceDate)
    {
        // TODO: Implement repair deadline calculation
        // Rules are documented in IAnomalySeverityService
        throw new NotImplementedException();
    }

    public bool IsRepairRequired(string severity, double depthPercent)
    {
        // TODO: Implement repair requirement check
        // Rules are documented in IAnomalySeverityService
        throw new NotImplementedException();
    }
}
