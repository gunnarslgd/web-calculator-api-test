using CalculatorService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CalculatorController : ControllerBase
{
	private readonly Services.CalculatorService _calculatorService;

	public CalculatorController(Services.CalculatorService calculatorService)
	{
		_calculatorService = calculatorService;
	}

	[HttpPost("calculate")]
	public IActionResult Calculate([FromBody] CalculationRequest? request)
	{
		if (request == null)
		{
			return BadRequest(new { error = "Invalid input data." });
		}

		try
		{
			var result = _calculatorService.Execute(request);

			return Ok(result);
		}
		catch (ArgumentException ex)
		{
			return BadRequest(new { error = ex.Message });
		}
		catch (Exception)
		{
			return StatusCode(500, new { error = "An error occurred while processing the request." });
		}
	}
}