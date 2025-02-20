using Microsoft.AspNetCore.Mvc;
using ShirtStock_Web_API.Filters;
using ShirtStock_Web_API.Filters.ExceptionFilters;
using ShirtStock_Web_API.Models;
using ShirtStock_Web_API.Models.Repositories;

namespace ShirtStock_Web_API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ShirtsController: ControllerBase
	{
		[HttpGet]
		public IActionResult GetShirts()
		{
			return Ok(ShirtRepository.GetShirts());
		}

		[HttpGet("{id}")]
		[Shirt_ValidateShirtIdFilter]
		public IActionResult GetShirtById(int id)
		{
			return Ok(ShirtRepository.GetShirtById(id));
		}

		[HttpPost]
		[Shirt_ValidateCreateShirtFilter]
		public IActionResult CreateShirt([FromBody] Shirt shirt)
		{
			ShirtRepository.AddShirt(shirt);

			return CreatedAtAction(nameof(GetShirtById),
				new { id = shirt.ShirtId },
				shirt);
		}

		[HttpPut("{id}")]
		[Shirt_ValidateShirtIdFilter]
		[Shirt_ValidateUpdateShirtFilter]
		[Shirt_HandleUpdateExceptionsFilter]
		public IActionResult UpdateShirt(int id, [FromBody] Shirt shirt)
		{
			ShirtRepository.UpdateShirt(shirt);	

			return NoContent();
		}

		[HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult DeleteShirt(int id)
		{
			var shirt = ShirtRepository.GetShirtById(id);

			ShirtRepository.DeleteShirt(id);

			return Ok(shirt);
		}
	}
}

