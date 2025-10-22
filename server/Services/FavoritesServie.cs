namespace spice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _favoritesRepository;
    private readonly RecipesService _recipesService;

    public FavoritesService(FavoritesRepository favoritesRepository, RecipesService recipesService)
    {
        _favoritesRepository = favoritesRepository;
        _recipesService = recipesService;
    }

    internal FavoriteRecipeViewModel CreateFavorite(FavoriteRecipeViewModel favoriteData)
    {
        FavoriteRecipeViewModel favorite = _favoritesRepository.CreateFavorite(favoriteData);
        if (favorite == null)
        {
            throw new Exception("Invalid Recipe ID");
        }
        FavoriteRecipeViewModel newFavorite = _favoritesRepository.CreateFavorite(favoriteData);
        return newFavorite;
    }


    internal List<FavoriteRecipeViewModel> GetAllFavorites(string AccountId)
    {
        List<FavoriteRecipeViewModel> recipes = _favoritesRepository.GetAllFavorites(AccountId);
        return recipes;
    }

    // internal void DeleteFavorite(int favoriteId, string userId)
    // {
    //     Favorite favorite = _favoritesRepository.GetFavoriteById(favoriteId);
    //     if (favorite == null)
    //     {
    //         throw new Exception("Favorite not found");
    //     }

    //     if (favorite.AccountId != userId)
    //     {
    //         throw new Exception("You cannot delete a favorite that isn’t yours!");
    //     }

    //     _favoritesRepository.DeleteFavorite(favoriteId);
    // }

    internal Favorite GetFavoriteById(int favoriteId)
    {
        return _favoritesRepository.GetFavoriteById(favoriteId);
    }

    internal void DeleteFavorite(int favoriteId, string userId)
    {
        Favorite favorite = GetFavoriteById(favoriteId);

        if (favorite == null)
        {
            throw new Exception("Favorite not found");
        }

        if (favorite.AccountId != userId)
        {
            throw new Exception("You cannot delete a favorite that isn’t yours!");
        }

        _favoritesRepository.DeleteFavorite(favoriteId);
    }
}