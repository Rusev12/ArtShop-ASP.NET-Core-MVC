namespace ArtShop.Data.DataModels
{
    public class ProducsDistributors
    {
        public int ArtProductId { get; set; }
        public ArtProduct ArtProduct { get; set; }

        public int DistributorId { get; set; }
        public Distributor Distributor { get; set; }
    }
}
