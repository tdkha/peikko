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
			string validationResult = _computeService.CheckGeometry(data);
			if (validationResult == null)
				return Ok("Validation passed.");
			else
				return BadRequest(validationResult);
		}

		[HttpPost("loads")]
		public async Task<IActionResult> GetLoads([FromBody] InputData data)
		{
			if (data == null)
				return BadRequest("Input data is required.");
			string validationResult = _computeService.CheckGeometry(data);
			data.PrintLayers();
			if (validationResult != null)
				return (BadRequest(validationResult));
			List<ComputeDto.LayerLoadsDto> res = _computeService.ComputeLoads(data);
			if (res == null || res.Count == 0)
				return StatusCode(500, "Failed to compute loads.");
			return (Ok(res));				
		}
	}
}