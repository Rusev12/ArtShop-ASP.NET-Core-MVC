namespace ArtShop.Services.Interfaces
{
    using System.Collections.Generic;
    using Data.DataModels;
    using ServiceModels;
    using System.Threading.Tasks;
    using ReflectionIT.Mvc.Paging;

    public interface IArtProductService
    {
        IEnumerable<AllArtProducts> ListAll();

        void Create(ArtProducts model);
    }
}
