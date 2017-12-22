namespace ArtShop.Data.DataModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Distributor
    {
        public int Id { get; set; }

        [Required]
        public string NameOfCompany { get; set; }

        public string City { get; set; }

        public IEnumerable<ProducsDistributors> ProducsDistributors { get; set; } = new List<ProducsDistributors>();
     
    }
}
