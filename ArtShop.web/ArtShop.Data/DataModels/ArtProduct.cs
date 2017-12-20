namespace ArtShop.Data.DataModels
{
    using System.ComponentModel.DataAnnotations;
    
    public class ArtProduct
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string Description { get; set; }

        [Required]
        public string UrlPath { get; set; }

        [Required]
        [Range(0 , 587)]
        public decimal Price { get; set; }
    }
}
