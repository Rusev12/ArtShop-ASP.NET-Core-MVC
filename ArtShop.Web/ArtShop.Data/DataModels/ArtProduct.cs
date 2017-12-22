namespace ArtShop.Data.DataModels
{
    using System.Collections.Generic;
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
        [MinLength(3)]
        [MaxLength(50)]
        public string Brand { get; set; }

        public bool IsAvailable { get; set; } = true;

        [Required]
        public string UrlPath { get; set; }

        [Required]
        [Range(0, 587)]
        public decimal Price { get; set; }

        public string CustomerId { get; set; }
        public User Customer { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        
        public IEnumerable<ProducsDistributors> ProducsDistributors { get; set; } = new List<ProducsDistributors>();
    }
}
