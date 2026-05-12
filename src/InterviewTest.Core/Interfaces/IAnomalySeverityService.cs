using InterviewTest.Core.DTOs;
using InterviewTest.Core.Entities;

namespace InterviewTest.Core.Interfaces;

/// <summary>
/// Service for classifying anomaly severity and calculating repair deadlines
/// based on anomaly characteristics and business rules.
/// </summary>
public interface IAnomalySeverityService
{
    /// <summary>
    /// Classifies the severity of an anomaly based on depth percentage and type.
    /// Rules:
    /// - Depth > 80% → Critical
    /// - Depth > 50% → High
    /// - Depth > 25% → Medium
    /// - Depth ≤ 25% → Low
    /// - Cracks increase severity by one level (Low→Medium, Medium→High, High→Critical, Critical stays Critical)
    /// </summary>
    /// <param name="depthPercent">Wall thickness loss percentage (0-100)</param>
    /// <param name="anomalyType">Type of anomaly (Corrosion, Crack, Dent, Gouge, WeldDefect)</param>
    /// <returns>Severity string: Low, Medium, High, or Critical</returns>
    /// <exception cref="ArgumentException">Thrown when depthPercent is negative or greater than 100</exception>
    string ClassifySeverity(double depthPercent, string anomalyType);

    /// <summary>
    /// Calculates the repair deadline based on severity.
    /// - Critical: 7 days from now
    /// - High: 30 days from now
    /// - Medium: 90 days from now
    /// - Low: 365 days from now
    /// </summary>
    /// <param name="severity">The anomaly severity level</param>
    /// <param name="referenceDate">The date to calculate from (typically inspection date)</param>
    /// <returns>The deadline date</returns>
    DateTime CalculateRepairDeadline(string severity, DateTime referenceDate);

    /// <summary>
    /// Determines whether a repair is required based on severity.
    /// Critical and High severity anomalies always require repair.
    /// Medium severity requires repair if depth > 40%.
    /// Low severity does not require repair.
    /// </summary>
    bool IsRepairRequired(string severity, double depthPercent);
}
