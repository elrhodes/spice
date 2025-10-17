
namespace spice.Controllers;

[ApiController]
[Route("api/recipes")]
public class RecipesController : ControllerBase
{
    private readonly RecipesService _rs;
    private readonly IngredientsService _is;
    private readonly Auth0Provider _auth0Provider;

    public RecipesController(RecipesService rs, IngredientsService Is, Auth0Provider auth0Provider)
    {
        _rs = rs;
        _auth0Provider = auth0Provider;
        _is = Is;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> Create([FromBody] Recipe newRecipe)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            newRecipe.CreatorId = userInfo.Id;
            Recipe recipe = _rs.Create(newRecipe);
            return Ok(recipe);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet]
    public ActionResult<List<Recipe>> GetAll()
    {
        try
        {
            List<Recipe> recipes = _rs.GetAll();
            return Ok(recipes);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("{recipeId}")]
    public ActionResult<Recipe> GetById(int recipeId)
    {
        try
        {
            Recipe recipe = _rs.GetById(recipeId);
            return Ok(recipe);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPut("{recipeId}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> Edit(int recipeId, [FromBody] Recipe recipeData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            recipeData.Id = recipeId;
            Recipe recipe = _rs.Edit(recipeId, recipeData, userInfo);
            return Ok(recipe);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpDelete("{recipeId}")]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int recipeId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string message = _rs.Delete(recipeId, userInfo);
            return Ok(message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("{recipeId}/ingredients")]
    public ActionResult<List<Ingredient>> GetIngredientsByRecipeId(int recipeId)
    {
        try
        {
            List<Ingredient> ingredients = _is.GetIngredientsByRecipeId(recipeId);
            return Ok(ingredients);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}