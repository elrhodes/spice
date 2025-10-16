namespace spice.Repositories;

public class RecipesRepository
{
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Recipe Create(Recipe newRecipe)
    {
        string sql = @"
        INSERT INTO recipes
        (title, instructions, img, category, creator_id)
        VALUES
        (@Title, @Instructions, @Img, @Category, @CreatorId);

        SELECT
        recipes.*,
        accounts.*
        FROM recipes
        JOIN accounts ON recipes.creator_id = accounts.id
        WHERE recipes.id = LAST_INSERT_ID();
        ";
        Recipe recipe = _db.Query(sql,
        (Recipe recipe, Profile profile) =>
        {
            recipe.Creator = profile;
            return recipe;
        },
        newRecipe).SingleOrDefault();
        return recipe;
    }
    internal List<Recipe> GetAll()
    {
        string sql = @"
        SELECT
        recipes.*,
        accounts.*
        FROM recipes
        JOIN accounts ON recipes.creator_id = accounts.id;
        ";
        List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql,
        (recipe, profile) =>
        {
            recipe.Creator = profile;
            return recipe;
        }).ToList();
        return recipes;
    }
    internal Recipe GetById(int recipeId)
    {
        string sql = @"
        SELECT
        recipes.*,
        accounts.*
        FROM recipes
        JOIN accounts ON recipes.creator_id = accounts.id
        WHERE
        recipes.id = @recipeId;
        ";
        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql,
        (recipe, profile) =>
        {
            recipe.Creator = profile;
            return recipe;
        },
        new { recipeId }).FirstOrDefault();
        return recipe;
    }
    internal Recipe Edit(Recipe updatedRecipe)
    {
        string sql = @"
        UPDATE recipes
        SET
            title = @Title,
            instructions = @Instructions,
            img = @img,
            category = @Category
        WHERE id = @Id;
        ";
        int rowsAffected = _db.Execute(sql, updatedRecipe);
        if (rowsAffected == 0)
        {
            throw new Exception("Unable to update recipe");
        }
        return GetById(updatedRecipe.Id);
    }
    internal void Delete(int recipeId)
    {
        string sql = @"
        DELETE FROM recipes
        WHERE id = @recipeId
        LIMIT 1;
        ";
        int rowsAffected = _db.Execute(sql, new { recipeId });
        if (rowsAffected != 1)
        {
            throw new Exception("too many rows affected");
        }
    }
}