using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RecipeApplication
{
    public class EnsureRecipeExistsAttribute : TypeFilterAttribute
    {
        public EnsureRecipeExistsAttribute() : base(typeof(EnsureRecipeExistsFilter)) {}

        public class EnsureRecipeExistsFilter : IActionFilter
        {
            private readonly RecipeService _service;
            public EnsureRecipeExistsFilter(RecipeService service)
            {
                _service = service;
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                var recipeId = (int) context.ActionArguments["id"];
                if (!_service.DoesRecipeExist(recipeId))
                {
                    context.Result = new NotFoundResult();
                }
            }

            public void OnActionExecuted(ActionExecutedContext context) { }
        }
    }
}
