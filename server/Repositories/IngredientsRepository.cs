namespace spice.Repositories;

public class IngredientsRepository
{
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        string sql = @"
        INSERT INTO ingredients
        (name, quantity, recipe_id)
        VALUES
        (@Name, @Quantity, @RecipeId);
        SELECT LAST_INSERT_ID();";
        int id = _db.ExecuteScalar<int>(sql, ingredientData);
        ingredientData.Id = id;
        return ingredientData;
    }
    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
        string sql = @"
        SELECT
        *
        FROM ingredients
        WHERE recipe_id = @recipeId;";
        List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId }).ToList();
        return ingredients;
    }
    internal Ingredient GetById(int ingredientId)
    {
        string sql = @"
        SELECT
        *
        FROM ingredients
        WHERE id = @ingredientId;";
        Ingredient ingredient = _db.QueryFirstOrDefault<Ingredient>(sql, new { ingredientId });
        return ingredient;
    }
    internal void DeleteIngredient(int ingredientId)
    {
        string sql = @"
        DELETE 
        FROM ingredients
        WHERE id = @ingredientId LIMIT 1;";
        int rowsAffected = _db.Execute(sql, new { ingredientId });
        if (rowsAffected != 1)
        {
            throw new Exception("Ingredient not found or could not be deleted");
        }
    }

}