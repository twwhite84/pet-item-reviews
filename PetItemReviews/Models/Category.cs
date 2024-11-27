using System.ComponentModel.DataAnnotations;

namespace PetItemReviews.Models
{
    public class Category
    {
        public string CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}