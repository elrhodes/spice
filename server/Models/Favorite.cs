namespace spice.Models;

public class Favorite
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public string AccountId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    // Navigation properties for multi-mapping results - DO NOT FORGET TO TELL the code where to GO
    public Recipe Recipe { get; set; }
    public Profile Account { get; set; }
}

public class FavoriteRecipe : Recipe
{
    public string favoriteId { get; set; }
}

public class FavoriteProfile : Profile
{
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}

// View model used to return a recipe shaped response with the favorite id included
public class FavoriteRecipeViewModel
{
    // ID of the favorites join row
    public int FavoriteId { get; set; }

    // Recipe fields (kept at top-level to match requested shape)
    public string Title { get; set; }
    public string Instructions { get; set; }
    public string Img { get; set; }
    public string Category { get; set; }
    public string AccountId { get; set; }

    // Creator/profile nested object
    public Profile Creator { get; set; }

    // Recipe id
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}