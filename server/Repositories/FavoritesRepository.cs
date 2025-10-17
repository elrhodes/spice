namespace spice.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal FavoriteRecipeViewModel CreateFavorite(FavoriteRecipeViewModel favoriteData)
    {
        string sql = @"
        INSERT INTO favorites
        (recipe_id, account_id)
        VALUES
        (@RecipeId, @AccountId);
        SELECT
        favorites.*,
        recipes.*,
        accounts.*
        FROM favorites
        JOIN recipes ON favorites.recipe_id = recipes.id
        JOIN accounts ON favorites.account_id = accounts.id
        WHERE favorites.id = LAST_INSERT_ID();";

        FavoriteRecipeViewModel newFavorite = _db.Query(sql,
        (Favorite favorite, FavoriteRecipe recipe, FavoriteProfile profile) =>
        {
            recipe. = recipe;
            favorite.Account = account;
            return favorite;
        }

        return newFavorite;
    }
}