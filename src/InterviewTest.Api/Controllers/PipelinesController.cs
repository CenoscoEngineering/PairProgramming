using InterviewTest.Core.DTOs;
using InterviewTest.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Api.Controllers;

/// <summary>
/// Controller for managing pipelines.
/// 
/// TODO: Implement the following endpoints using the injected IPipelineRepository
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PipelinesController : ControllerBase
{
    private readonly IPipelineRepository _pipelineRepository;

    public PipelinesController(IPipelineRepository pipelineRepository)
    {
        _pipelineRepository = pipelineRepository;
    }

    /// <summary>
    /// GET /api/pipelines
    /// Returns all pipelines with their segment count.
    /// Should return 200 OK with a list of PipelineDto.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // TODO: Implement - use _pipelineRepository.GetAllAsync()
        throw new NotImplementedException();
    }

    /// <summary>
    /// GET /api/pipelines/{id}
    /// Returns a single pipeline with its segments.
    /// Should return 200 OK with PipelineDetailDto, or 404 if not found.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// POST /api/pipelines
    /// Creates a new pipeline.
    /// Should validate input, check for duplicate names, and return 201 Created.
    /// Return 409 Conflict if a pipeline with the same name already exists.
    /// Return 400 Bad Request if input is invalid.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePipelineDto dto)
    {
        throw new NotImplementedException();
    }
}
