using System.ComponentModel.DataAnnotations;

namespace spice.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [MaxLength(500)] public string Title { get; set; }
        [MaxLength(500)] public string Instructions { get; set; }
        [MaxLength(1000)] public string img { get; set; }
        [MaxLength(500)] public string Category { get; set; }
        public string CreatorId { get; set; }
        public Profile Creator { get; set; }
    }
}