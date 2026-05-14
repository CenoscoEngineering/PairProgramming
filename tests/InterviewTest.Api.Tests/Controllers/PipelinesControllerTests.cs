using InterviewTest.Api.Controllers;
using InterviewTest.Core.DTOs;
using InterviewTest.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace InterviewTest.Api.Tests.Controllers;

/// <summary>
/// Tests for PipelinesController — CANDIDATE FILLS IN TEST BODIES
///
/// </summary>
public class PipelinesControllerTests
{
    private readonly Mock<IPipelineRepository> _mockRepo;
    private readonly PipelinesController _controller;

    public PipelinesControllerTests()
    {
        _mockRepo = new Mock<IPipelineRepository>();
        _controller = new PipelinesController(_mockRepo.Object);
    }

    #region GET /api/pipelines

    [Fact]
    public async Task GetAll_ReturnsOkResult_WithListOfPipelines()
    {
        throw new NotImplementedException("Write this test first, then implement the controller");
    }

    [Fact]
    public async Task GetAll_ReturnsOkResult_WithEmptyList_WhenNoPipelines()
    {
        throw new NotImplementedException("Write this test first, then implement the controller");
    }

    #endregion

    #region GET /api/pipelines/{id}

    [Fact]
    public async Task GetById_ReturnsOkResult_WithPipelineDetail_WhenFound()
    {
        throw new NotImplementedException("Write this test first, then implement the controller");
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenPipelineDoesNotExist()
    {
        throw new NotImplementedException("Write this test first, then implement the controller");
    }

    #endregion

    #region POST /api/pipelines (Bonus)

    [Fact]
    public async Task Create_ReturnsCreatedAtAction_WithNewPipeline()
    {
        throw new NotImplementedException("Write this test first, then implement the controller");
    }

    [Fact]
    public async Task Create_ReturnsConflict_WhenPipelineNameAlreadyExists()
    {
        throw new NotImplementedException("Write this test first, then implement the controller");
    }

    [Fact]
    public async Task Create_ReturnsBadRequest_WhenNameIsEmpty()
    {
        throw new NotImplementedException("Write this test first, then implement the controller");
    }

    [Fact]
    public async Task Create_ReturnsBadRequest_WhenDiameterIsZeroOrNegative()
    {
        throw new NotImplementedException("Write this test first, then implement the controller");
    }

    #endregion
}
