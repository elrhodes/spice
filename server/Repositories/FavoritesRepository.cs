
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

        FavoriteRecipeViewModel newFavorite = _db.Query<FavoriteRecipeViewModel>(sql, favoriteData).SingleOrDefault();

        return newFavorite;
    }

    internal List<FavoriteRecipeViewModel> GetAllFavorites(string accountId)
    {
        string sql = @"
        SELECT 
        recipes.*,
        recipes.id AS recipeId,
        recipe.createdAt AS favorited_at,
        account.*
        FROM favorites
        JOIN recipes ON recipe.id = favorites.recipe_id
        JOIN accounts ON accounts.id = creator_id
        WHERE account_id = @accountId;
        ";
        List<FavoriteRecipeViewModel> favorites = _db.Query(
sql,
(Favorite favorite, Profile account) =>
{
    favorite.AccountId = account;
    return favorite;
},
new { accountId });
        return favorites;


    }
}