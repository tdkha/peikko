using Microsoft.AspNetCore.Mvc;
using PeikkoDesigner.Interfaces;

namespace PeikkoDesigner.Controllers
{
	[Route("api/compute")]
	[ApiController]
	public class ComputeController : ControllerBase
	{
		private readonly IComputeService _computeService;

		public ComputeController(IComputeService computeService)
		{
			_computeService = computeService;
		}

		[HttpPost("validate")]
		public async Task<IActionResult> ValidateInput([FromBody] InputData data)
		{
			if (data == null)
				return BadRequest("Input data is required.");
			data.PrintLayers();
			int validationResult = await _computeService.InputCheck(data);
			if (validationResult == 0)
				return Ok("Validation passed.");
			else
				return BadRequest("Validation failed.");
		}
	}
}