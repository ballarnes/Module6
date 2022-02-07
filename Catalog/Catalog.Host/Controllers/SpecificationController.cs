using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Scope("catalog.specification")]
[Route(ComponentDefaults.DefaultRoute)]
public class SpecificationController : ControllerBase
{
    private readonly ILogger<SpecificationController> _logger;
    private readonly ICatalogService _catalogService;

    public SpecificationController(
        ILogger<SpecificationController> logger,
        ICatalogService catalogService)
    {
        _logger = logger;
        _catalogService = catalogService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateResponse<int?>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateSpecification(CreateSpecificationRequest request)
    {
        var result = await _catalogService.AddSpecificationAsync(request.Socket, request.NumberOfCores, request.NumberOfThreads, request.ClockFrequency, request.MaximumClockFrequency, request.MemoryType, request.VideoLink);

        if (result == null)
        {
            return BadRequest();
        }

        return Ok(new CreateResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> RemoveSpecification(GetByIdRequest request)
    {
        var result = await _catalogService.RemoveSpecificationAsync(request.Id);

        if (result == null)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateSpecification(UpdateSpecificationRequest request)
    {
        var result = await _catalogService.UpdateSpecificationAsync(request.Id, request.Socket, request.NumberOfCores, request.NumberOfThreads, request.ClockFrequency, request.MaximumClockFrequency, request.MemoryType, request.VideoLink);

        if (result == null)
        {
            return BadRequest();
        }

        return Ok();
    }
}