﻿namespace ArtShop.Services.ServiceModels.ArtProduct
{
    using System.ComponentModel.DataAnnotations;

    public class ArtProducts
    {

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string Description { get; set; }

        public string UrlPath { get; set; }

        [Required]
        [Range(0, 587)]
        public decimal Price { get; set; }

        public string Brand { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
