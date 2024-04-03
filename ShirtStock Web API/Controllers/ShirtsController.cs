using System;
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
		[Shirts_ValidateShirtIdFilter]
        public IActionResult GetShirtById(int id)
		{
			return Ok(ShirtRepository.GetShirtById(id));
		}

		[HttpPost]
		[Shirts_ValidateCreateShirtFilter]
		public IActionResult CreateShirt([FromBody] Shirt shirt)
		{
			ShirtRepository.CreateShirt(shirt);
			return CreatedAtAction(nameof(GetShirtById),
				new { id = shirt.ShirtId},
				shirt);
		}

		[HttpPut("{id}")]
		//[Shirts_ValidateShirtIdFilter]
		[Shirts_ValidateUpdateShirtFilter]
		[Shirts_HandleUpdateShirtExceptionsFilter]
		public IActionResult UpdateShirt(int id, Shirt shirt)
		{
            ShirtRepository.UpdateShirt(shirt);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteShirt(int id)
		{
			return Ok($"Deleting shirt: {id}");
		}
	}
}