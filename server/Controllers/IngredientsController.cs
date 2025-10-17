namespace spice.Controllers;

[ApiController]
[Route("api/ingredients")]
public class IngredientsController : ControllerBase
{
    private readonly IngredientsService _ingredientsService;
    private readonly Auth0Provider _auth0Provider;
    public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0Provider)
    {
        _ingredientsService = ingredientsService;
        _auth0Provider = auth0Provider;
    }
    [HttpPost]
    public ActionResult<Ingredient> CreateIngredient([FromBody] Ingredient ingredientData)
    {
        try
        {
            int recipeId = ingredientData.RecipeId;
            Ingredient newIngredient = _ingredientsService.CreateIngredient(ingredientData, recipeId);
            return Ok(newIngredient);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpDelete("{ingredientId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteIngredient(int ingredientId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            _ingredientsService.DeleteIngredient(ingredientId, userInfo.Id);
            return Ok("Ingredient deleted");

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}