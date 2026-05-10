using Microsoft.AspNetCore.Mvc;
using Siemens.Internship2026.GradeBook.Interfaces;

namespace Siemens.Internship2026.GradeBook.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;
    private readonly ILogger<ItemController> _logger;

    public ItemController(IItemService itemService, ILogger<ItemController> logger)
    {
        _itemService = itemService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int n)
    {
        _logger.LogInformation("GET api/item called");

        var grades = await _itemService.GetFirstNGrades(n);
        var statistics = _itemService.GetStatistics(grades);

        _logger.LogInformation("Returning {totalCount} items, average value: {averageValue}", statistics.TotalCount, statistics.AverageValue);

        return Ok(new
        {
            Data = grades,
            Statistics = statistics
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        _logger.LogInformation("GET api/item/{id} called", id);

        if (id <= 0)
        {
            _logger.LogWarning("Invalid id: {id}", id);
            return BadRequest("Id must be a positive integer.");
        }

        var item = await _itemService.GetByIdAsync(id);
        if (item == null)
        {
            _logger.LogWarning("Item {id} not found", id);
            return NotFound($"Item with Id {id} was not found.");
        }

        return Ok(item);
    }
}
