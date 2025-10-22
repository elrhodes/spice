
namespace spice.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _ingredientsRepository;
    private readonly RecipesService _recipesService;

    public IngredientsService(IngredientsRepository ingredientsRepository, RecipesService recipesService)
    {
        _ingredientsRepository = ingredientsRepository;
        _recipesService = recipesService;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData, int recipeId, string userInfo)
    {
        Recipe recipe = _recipesService.GetById(recipeId);
        if (recipe == null)
        {
            throw new Exception("Invalid Recipe ID");
        }
        if (userInfo != recipe.CreatorId)
        {
            throw new Exception("You are not the creator of this recipe!");
        }

        Ingredient newIngredient = _ingredientsRepository.CreateIngredient(ingredientData);
        return newIngredient;
    }


    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
        Recipe recipe = _recipesService.GetById(recipeId);
        if (recipe == null)
        {
            throw new Exception("Invalid Recipe ID");
        }
        List<Ingredient> ingredients = _ingredientsRepository.GetIngredientsByRecipeId(recipeId);
        return ingredients;
    }
    internal void DeleteIngredient(int ingredientId, string userId) // we had to add getbyid to repository to make this work, because before we were returning an array of ingredients and not just one ingredient, so we couldn't make it past the ingredientId because it always returned multiple ingredients which gave us a null reference error.
    {
        Ingredient ingredient = _ingredientsRepository.GetById(ingredientId);
        if (ingredient == null)
        {
            throw new Exception("Ingredient not found");
        }
        Recipe recipe = _recipesService.GetById(ingredient.RecipeId);
        if (recipe == null)
        {
            throw new Exception("Associated recipe not found");
        }

        if (recipe.CreatorId != userId)
        {
            throw new Exception("You do not have permission to delete this ingredient");
        }

        _ingredientsRepository.DeleteIngredient(ingredientId);
    }

}