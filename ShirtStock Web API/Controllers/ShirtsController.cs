using System;
using Microsoft.AspNetCore.Mvc;
using ShirtStock_Web_API.Filters;
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
		public IActionResult CreateShirt([FromBody] Shirt shirt)
		{
			return Ok("Creating a shirt");
		}

		[HttpPut("{id}")]
		public IActionResult UpdateShirt(int id)
		{
			return Ok($"Updating shirt: {id}");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteShirt(int id)
		{
			return Ok($"Deleting shirt: {id}");
		}
	}
}