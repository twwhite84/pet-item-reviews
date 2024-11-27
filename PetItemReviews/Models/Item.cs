using System.ComponentModel.DataAnnotations;

namespace PetItemReviews.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public int? Rating { get; set; }
    }
}
