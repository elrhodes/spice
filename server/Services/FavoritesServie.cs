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
        Recipe recipe = _recipesService.GetById(favoriteData.Id);
        if (recipe == null)
        {
            throw new Exception("Invalid Recipe ID");
        }
        FavoriteRecipeViewModel newFavorite = _favoritesRepository.CreateFavorite(favoriteData);
        return newFavorite;
    }
}