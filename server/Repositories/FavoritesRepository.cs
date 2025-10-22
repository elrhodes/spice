

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
        INSERT INTO favorites (recipe_id, account_id)
        VALUES (@RecipeId, @AccountId);
    
        SELECT 
        f.id AS FavoriteId,
        r.*,
        a.* 
        FROM favorites f
        JOIN recipes r ON f.recipe_id = r.id
        JOIN accounts a ON r.creator_id = a.id
        WHERE f.id = LAST_INSERT_ID();";

        FavoriteRecipeViewModel favorite = _db.Query<FavoriteRecipeViewModel, Profile, FavoriteRecipeViewModel>(
            sql,
            (recipe, creator) =>
            {
                recipe.Creator = creator;
                return recipe;
            },
            favoriteData
        ).FirstOrDefault();

        return favorite;
    }

    internal List<FavoriteRecipeViewModel> GetAllFavorites(string accountId)
    {
        string sql = @"
    SELECT 
    f.id AS FavoriteId,
    r.*,
    a.*
    FROM favorites f
    JOIN recipes r ON f.recipe_id = r.id
    JOIN accounts a ON r.creator_id = a.id
    WHERE f.account_id = @accountId;";

        List<FavoriteRecipeViewModel> favorites = _db.Query<FavoriteRecipeViewModel, Profile, FavoriteRecipeViewModel>(
            sql,
            (recipe, creator) =>
            {
                recipe.Creator = creator;
                return recipe;
            },
            new { accountId }
        ).ToList();

        return favorites;
    }

    internal Favorite GetFavoriteById(int favoriteId)
    {
        string sql = @"
        SELECT f.*, a.*
        FROM favorites f
        JOIN accounts a ON f.account_id = a.id
        WHERE f.id = @favoriteId;
    ";

        Favorite favorite = _db.Query<Favorite, Profile, Favorite>(
            sql,
            (favorite, account) =>
            {
                favorite.Account = account;
                return favorite;
            },
            new { favoriteId }
        ).FirstOrDefault();

        return favorite;
    }
    internal void DeleteFavorite(int favoriteId)
    {
        string sql = "DELETE FROM favorites WHERE id = @favoriteId LIMIT 1;";
        _db.Execute(sql, new { favoriteId });
    }

}
