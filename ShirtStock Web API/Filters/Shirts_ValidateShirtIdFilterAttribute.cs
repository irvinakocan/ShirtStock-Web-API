using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShirtStock_Web_API.Models.Repositories;

namespace ShirtStock_Web_API.Filters
{
	public class Shirts_ValidateShirtIdFilterAttribute: ActionFilterAttribute
	{
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

			var id = context.ActionArguments["id"] as int?;

			if (id.HasValue)
			{
				if (id.Value <= 0)
				{
					context.ModelState.AddModelError("ShirtId", "ShirtId is invalid.");
					var problemDetails = new ValidationProblemDetails(context.ModelState)
					{
						Status = StatusCodes.Status400BadRequest
					};
					context.Result = new BadRequestObjectResult(problemDetails);
				}
				else if (!ShirtRepository.ShirtExists(id.Value))
				{
                    context.ModelState.AddModelError("ShirtId", "Shirt does not exist.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
			}
        }
    }
}



/*
 * if (id <= 0)
				return BadRequest();

			var shirt = ShirtRepository.GetShirtById(id);
			if (shirt == null)
				return NotFound();
 */