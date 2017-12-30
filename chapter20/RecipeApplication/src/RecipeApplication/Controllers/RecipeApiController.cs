using System;
using Microsoft.AspNetCore.Mvc;
using RecipeApplication.Models;

namespace RecipeApplication.Controllers
{
    [Route("api/recipe")]
    [ValidateModel, HandleException, FeatureEnabled(IsEnabled = true)]
    public class RecipeApiController : Controller
    {
        public RecipeService _service;
        public RecipeApiController(RecipeService service)
        {
            _service = service;
        }

        [HttpGet("{id}"), EnsureRecipeExists, AddLastModifedHeader]
        public IActionResult Get(int id)
        {
            var detail = _service.GetRecipeDetail(id);
            return Ok(detail);

        }

        [HttpPost("{id}"), EnsureRecipeExists, RequireIpAddress]
        public IActionResult Edit(int id, [FromBody] UpdateRecipeCommand command)
        {
            _service.UpdateRecipe(command);
            return Ok();
        }
    }
}
