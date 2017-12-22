namespace ArtShop.Services.ServiceModels.Category
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryServiceModel
    {

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        [Display(Name = "Category name")]
        public string CategoryName { get; set; }
    }
}
