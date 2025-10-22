namespace spice.Controllers;

[ApiController]
[Route("api/favorites")]
public class FavoritesController : ControllerBase
{
    private readonly FavoritesService _favoritesService;
    private readonly Auth0Provider _auth0Provider;
    public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0Provider)
    {
        _favoritesService = favoritesService;
        _auth0Provider = auth0Provider;
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<FavoriteRecipeViewModel>> CreateFavorite([FromBody] FavoriteRecipeViewModel favoriteData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            favoriteData.AccountId = userInfo.Id;
            FavoriteRecipeViewModel newFavorite = _favoritesService.CreateFavorite(favoriteData);
            return Ok(newFavorite);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpDelete("{favoriteId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteFavorite(int favoriteId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            _favoritesService.DeleteFavorite(favoriteId, userInfo.Id);
            return Ok("deleted favorite recipe!!!!");
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}