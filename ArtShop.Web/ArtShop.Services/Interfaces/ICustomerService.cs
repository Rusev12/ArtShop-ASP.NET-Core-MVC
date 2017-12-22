namespace ArtShop.Services.Interfaces
{
    using ArtShop.Data.DataModels;
    using ArtShop.Services.ServiceModels.ArtProduct;
    using ArtShop.Services.ServiceModels.Customer;

    public interface ICustomerService
    {
        CustomerServiceModel AddProductToUser(User user, AllArtProducts product);

        CustomerServiceModel ById(string id);


    }
}
