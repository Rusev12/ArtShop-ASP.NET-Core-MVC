namespace ArtShop.Data.DataModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        [Display(Name = "Category name")]
        public string CategoryName { get; set; }

       
    }
}
