using System.Collections.Generic;
using System.Linq;
using RecipeApplication.Data;
using RecipeApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Logging;

namespace RecipeApplication
{
    public class RecipeService
    {
        readonly AppDbContext _context;
        readonly ILogger _logger;
        public RecipeService(AppDbContext context, ILoggerFactory factory)
        {
            _context = context;
            _logger = factory.CreateLogger<RecipeService>();
        }

        public ICollection<RecipeSummaryViewModel> GetRecipes()
        {
            return _context.Recipes
                .Where(r => !r.IsDeleted)
                .Select(x => new RecipeSummaryViewModel
                {
                    Id = x.RecipeId,
                    Name = x.Name,
                    TimeToCook = $"{x.TimeToCook.Hours}hrs {x.TimeToCook.Minutes}mins",
                })
                .ToList();
        }

        public bool DoesRecipeExist(int id)
        {
            return _context.Recipes
                .Where(r => !r.IsDeleted)
                .Where(r => r.RecipeId == id)
                .Any();
        }

        public RecipeDetailViewModel GetRecipeDetail(int id)
        {
            return _context.Recipes
                .Where(x => x.RecipeId == id)
                .Where(x => !x.IsDeleted)
                .Select(x => new RecipeDetailViewModel
                {
                    Id = x.RecipeId,
                    Name = x.Name,
                    Method = x.Method,
                    LastModified = x.LastModified,
                    Ingredients = x.Ingredients
                    .Select(item => new RecipeDetailViewModel.Item
                    {
                        Name = item.Name,
                        Quantity = $"{item.Quantity} {item.Unit}"
                    })
                })
                .SingleOrDefault();
        }


        public Recipe GetRecipe(int recipeId)
        {
            return _context.Recipes
                .Where(x => x.RecipeId == recipeId)
                .SingleOrDefault();
        }

        public UpdateRecipeCommand GetRecipeForUpdate(int recipeId)
        {
            return _context.Recipes
                .Where(x => x.RecipeId == recipeId)
                .Where(x => !x.IsDeleted)
                .Select(x => new UpdateRecipeCommand
                {
                    Name = x.Name,
                    Method = x.Method,
                    TimeToCookHrs = x.TimeToCook.Hours,
                    TimeToCookMins = x.TimeToCook.Minutes,
                    IsVegan = x.IsVegan,
                    IsVegetarian = x.IsVegetarian,
                })
                .SingleOrDefault();
        }

        /// <summary>
        /// Create a new recipe
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>The id of the new recipe</returns>
        public int CreateRecipe(CreateRecipeCommand cmd, ApplicationUser createdBy)
        {
            var recipe = cmd.ToRecipe(createdBy);
            _context.Add(recipe);
            _context.SaveChanges();
            return recipe.RecipeId;
        }

        /// <summary>
        /// Updateds an existing recipe
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>The id of the new recipe</returns>
        public void UpdateRecipe(UpdateRecipeCommand cmd)
        {
            var recipe = _context.Recipes.Find(cmd.Id);
            if(recipe == null) { throw new Exception("Unable to find the recipe"); }
            if(recipe.IsDeleted) { throw new Exception("Unable to update a deleted recipe"); }

            cmd.UpdateRecipe(recipe);
            _context.SaveChanges();
        }

        /// <summary>
        /// Marks an existing recipe as deleted
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>The id of the new recipe</returns>
        public void DeleteRecipe(int recipeId)
        {
            var recipe = _context.Recipes.Find(recipeId);
            if(recipe.IsDeleted) { throw new Exception("Unable to delete a deleted recipe"); }

            recipe.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
