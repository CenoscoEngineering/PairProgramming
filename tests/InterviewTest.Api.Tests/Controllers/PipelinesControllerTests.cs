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
        // TODO: Arrange — set up _mockRepo to return a list of PipelineDto
        // TODO: Act — call _controller.GetAll()
        // TODO: Assert — verify 200 OK with the expected pipelines

        throw new NotImplementedException("Write this test first, then implement the controller");
    }

    [Fact]
    public async Task GetAll_ReturnsOkResult_WithEmptyList_WhenNoPipelines()
    {
        // TODO: Arrange — set up _mockRepo to return an empty list
        // TODO: Act — call _controller.GetAll()
        // TODO: Assert — verify 200 OK with an empty list

        throw new NotImplementedException("Write this test first, then implement the controller");
    }

    #endregion

    #region GET /api/pipelines/{id}

    [Fact]
    public async Task GetById_ReturnsOkResult_WithPipelineDetail_WhenFound()
    {
        // TODO: Arrange — set up _mockRepo to return a PipelineDetailDto for a given id
        // TODO: Act — call _controller.GetById(id)
        // TODO: Assert — verify 200 OK with the expected pipeline detail

        throw new NotImplementedException("Write this test first, then implement the controller");
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenPipelineDoesNotExist()
    {
        // TODO: Arrange — set up _mockRepo to return null for a non-existent id
        // TODO: Act — call _controller.GetById(999)
        // TODO: Assert — verify 404 Not Found

        throw new NotImplementedException("Write this test first, then implement the controller");
    }

    #endregion

    #region POST /api/pipelines (Bonus)

    [Fact]
    public async Task Create_ReturnsCreatedAtAction_WithNewPipeline()
    {
        // TODO: Arrange — set up _mockRepo.ExistsByNameAsync to return false, CreateAsync to return a PipelineDto
        // TODO: Act — call _controller.Create(dto)
        // TODO: Assert — verify 201 Created with Location header

        throw new NotImplementedException("Write this test first, then implement the controller");
    }

    [Fact]
    public async Task Create_ReturnsConflict_WhenPipelineNameAlreadyExists()
    {
        // TODO: Arrange — set up _mockRepo.ExistsByNameAsync to return true
        // TODO: Act — call _controller.Create(dto) with a duplicate name
        // TODO: Assert — verify 409 Conflict

        throw new NotImplementedException("Write this test first, then implement the controller");
    }

    [Fact]
    public async Task Create_ReturnsBadRequest_WhenNameIsEmpty()
    {
        // TODO: Arrange — create a dto with an empty name
        // TODO: Act — call _controller.Create(dto)
        // TODO: Assert — verify 400 Bad Request

        throw new NotImplementedException("Write this test first, then implement the controller");
    }

    [Fact]
    public async Task Create_ReturnsBadRequest_WhenDiameterIsZeroOrNegative()
    {
        // TODO: Arrange — create a dto with diameterInches <= 0
        // TODO: Act — call _controller.Create(dto)
        // TODO: Assert — verify 400 Bad Request

        throw new NotImplementedException("Write this test first, then implement the controller");
    }

    #endregion
}
