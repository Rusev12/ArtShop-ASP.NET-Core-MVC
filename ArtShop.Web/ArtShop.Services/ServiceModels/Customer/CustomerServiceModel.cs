namespace ArtShop.Services.ServiceModels.Customer
{
    using System.ComponentModel.DataAnnotations;

    public class CustomerServiceModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]     
        [Display(Name = "Post code")]
        [Range(0 , int.MaxValue)]
        public int PostCode { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string StreetAddress { get; set; }
    }
}
