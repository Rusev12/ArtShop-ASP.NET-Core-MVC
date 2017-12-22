namespace ArtShop.Services
{
    using AutoMapper;
    using Data.DataModels;
    using ServiceModels.ArtProduct;
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ArtProduct, AllArtProducts>();
            CreateMap<ArtProduct, ArtProducts>();
            CreateMap<ArtProduct, UserProduct>();
        }
    }
}

