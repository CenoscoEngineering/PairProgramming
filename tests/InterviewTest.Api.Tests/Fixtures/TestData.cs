using InterviewTest.Core.DTOs;

namespace InterviewTest.Api.Tests.Fixtures;

/// <summary>
/// Pre-built test data for PipelinesControllerTests.
/// Use these in your Arrange steps instead of constructing DTOs from scratch.
/// </summary>
public static class TestData
{
    #region GET /api/pipelines — test data

    /// <summary>
    /// A list of PipelineDto matching seed data, for use with GetAll tests.
    /// </summary>
    public static List<PipelineDto> PipelineList => new()
    {
        new(1, "Northern Trunk Line", "NorthSea Energy", "Carbon Steel",
            36, 142.5, 1440, new DateTime(1998, 6, 15), "Active", 4),
        new(2, "Southern Export Pipeline", "Gulf Pipelines Ltd", "Carbon Steel",
            24, 87.3, 1200, new DateTime(2005, 3, 22), "Active", 3),
    };

    #endregion

    #region GET /api/pipelines/{id} — test data

    /// <summary>
    /// A PipelineDetailDto for pipeline 1 with two segments, for use with GetById tests.
    /// </summary>
    public static PipelineDetailDto PipelineDetail => new(
        1, "Northern Trunk Line", "NorthSea Energy", "Carbon Steel",
        36, 142.5, 1440, new DateTime(1998, 6, 15), "Active",
        new List<PipeSegmentDto>
        {
            new(1, 1, "NTL-SEG-001", 0.0, 15.2, 19.1, 17.8, "3LPE", "Clay", 3, 2),
            new(2, 1, "NTL-SEG-002", 15.2, 32.7, 19.1, 16.2, "3LPE", "Sand", 2, 2),
        });

    #endregion

    #region POST /api/pipelines — test data

    /// <summary>
    /// A valid CreatePipelineDto for a new pipeline.
    /// </summary>
    public static CreatePipelineDto ValidCreateDto => new(
        "New Offshore Pipeline", "NorthSea Energy", "Carbon Steel",
        20, 65.0, 1500, new DateTime(2024, 1, 15));

    /// <summary>
    /// The expected PipelineDto returned after successful creation.
    /// </summary>
    public static PipelineDto CreatedPipelineResult => new(
        4, "New Offshore Pipeline", "NorthSea Energy", "Carbon Steel",
        20, 65.0, 1500, new DateTime(2024, 1, 15), "Active", 0);

    /// <summary>
    /// A CreatePipelineDto with a duplicate name (already exists in seed data).
    /// </summary>
    public static CreatePipelineDto DuplicateNameCreateDto => new(
        "Northern Trunk Line", "NorthSea Energy", "Carbon Steel",
        36, 142.5, 1440, new DateTime(1998, 6, 15));

    /// <summary>
    /// A CreatePipelineDto with an empty name (invalid).
    /// </summary>
    public static CreatePipelineDto EmptyNameCreateDto => new(
        "", "NorthSea Energy", "Carbon Steel",
        20, 65.0, 1500, new DateTime(2024, 1, 15));

    /// <summary>
    /// A CreatePipelineDto with zero diameter (invalid).
    /// </summary>
    public static CreatePipelineDto ZeroDiameterCreateDto => new(
        "Test Pipeline", "NorthSea Energy", "Carbon Steel",
        0, 65.0, 1500, new DateTime(2024, 1, 15));

    #endregion
}
