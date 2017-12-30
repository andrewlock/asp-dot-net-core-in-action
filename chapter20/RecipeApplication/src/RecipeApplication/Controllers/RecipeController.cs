using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeApplication.Data;
using RecipeApplication.Models;

namespace RecipeApplication.Controllers
{
    public class RecipeController : Controller
    {
        private readonly RecipeService _service;
        private readonly UserManager<ApplicationUser> _userService;
        private readonly IAuthorizationService _authService;
        private readonly ILogger _log;
        
        public RecipeController(
            RecipeService service, 
            UserManager<ApplicationUser> userService, 
            IAuthorizationService authService,
            ILogger<RecipeController> log)
        {
            _service = service;
            _userService = userService;
            _authService = authService;
            _log = log;
        }

        public IActionResult Index()
        {
            var models = _service.GetRecipes();
            _log.LogInformation("Loaded {RecipeCount} recipes", models.Count);

            return View(models);
        }

        public async Task<IActionResult> View(int id)
        {
            var model = _service.GetRecipeDetail(id);
            if (model == null)
            {
                // If id is not for a valid Recipe, generate a 404 error page
                // TODO: Add status code pages middleware to show friendly 404 page
                _log.LogWarning(12, "Could not find recipe with id {RecipeId}", id);
                return NotFound();
            }
            
            var recipe = _service.GetRecipe(id);
            var isAthorised = await _authService.AuthorizeAsync(User, recipe, "CanManageRecipe");
            model.CanEditRecipe = isAthorised.Succeeded;

            return View(model);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View(new CreateRecipeCommand());
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Create(CreateRecipeCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var appUser = await _userService.GetUserAsync(User);
                    var id = _service.CreateRecipe(command, appUser);
                    return RedirectToAction(nameof(View), new { id = id });
                }
            }
            catch (Exception)
            {
                // TODO: Log error
                // Add a model-level error by using an empty string key
                ModelState.AddModelError(
                    string.Empty,
                    "An error occured saving the recipe"
                    );
            }

            //If we got to here, something went wrong
            return View(command);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var recipe = _service.GetRecipe(id);
            var authResult = await _authService.AuthorizeAsync(User, recipe, "CanManageRecipe");
            if (!authResult.Succeeded)
            {
                return new ForbidResult();
            }

            var model = _service.GetRecipeForUpdate(id);
            if (model == null)
            {
                // If id is not for a valid Recipe, generate a 404 error page
                // TODO: Add status code pages middleware to show friendly 404 page
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateRecipeCommand command)
        {
            try
            {
                var recipe = _service.GetRecipe(command.Id);
                var authResult = await _authService.AuthorizeAsync(User, recipe, "CanManageRecipe");
                if (!authResult.Succeeded)
                {
                    return new ForbidResult();
                }

                if (ModelState.IsValid)
                {
                    _service.UpdateRecipe(command);
                    return RedirectToAction(nameof(View), new { id = command.Id });
                }
            }
            catch (Exception)
            {
                // TODO: Log error
                // Add a model-level error by using an empty string key
                ModelState.AddModelError(
                    string.Empty,
                    "An error occured saving the recipe"
                    );
            }

            //If we got to here, something went wrong
            return View(command);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            _service.DeleteRecipe(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
