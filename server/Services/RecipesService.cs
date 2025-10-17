namespace spice.Services;

public class RecipesService
{
    private readonly RecipesRepository _repo;

    public RecipesService(RecipesRepository repo)
    {
        _repo = repo;
    }

    internal Recipe Create(Recipe newRecipe)
    {
        Recipe recipe = _repo.Create(newRecipe);
        return recipe;
    }
    internal List<Recipe> GetAll()
    {
        List<Recipe> recipes = _repo.GetAll();
        return recipes;
    }
    internal Recipe GetById(int recipeId)
    {
        Recipe recipe = _repo.GetById(recipeId);
        if (recipe == null)
        {
            throw new Exception("Invalid Recipe Id");
        }
        return recipe;
    }
    internal Recipe Edit(int recipeId, Recipe recipeData, Account userInfo)
    {
        Recipe original = GetById(recipeId);
        if (original.CreatorId != userInfo.Id)
        {
            throw new Exception("You are not the creator of this recipe");
        }
        original.Title = recipeData.Title ?? original.Title;
        original.Instructions = recipeData.Instructions ?? original.Instructions;
        original.img = recipeData.img ?? original.img;
        original.Category = recipeData.Category ?? original.Category;
        _repo.Edit(original);
        return original;
    }
    internal string Delete(int recipeId, Account userInfo)
    {
        Recipe original = GetById(recipeId);
        if (original.CreatorId != userInfo.Id)
        {
            throw new Exception("You are not the creator of this recipe");
        }
        _repo.Delete(recipeId);
        return
        "Successfully Deleted";
    }

}