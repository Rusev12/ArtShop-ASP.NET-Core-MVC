namespace ArtShop.Services.Interfaces
{
    using System.Collections.Generic;
    using Data.DataModels;
    using ServiceModels;
    using System.Threading.Tasks;
    using ServiceModels.ArtProduct;

    public interface IArtProductService
    {
        IEnumerable<AllArtProducts> ListAll(int page);

        void Create(ArtProducts model);

        void Delete(int id);

        AllArtProducts GetById(int id);


        void Update(AllArtProducts artProduct ,int id);

        IEnumerable<UserProduct> AllProductsByThisUser(User user);
    }
}
