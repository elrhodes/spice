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
}