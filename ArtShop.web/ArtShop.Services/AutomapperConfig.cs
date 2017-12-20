namespace ArtShop.Services
{
    using AutoMapper;
    using Data.DataModels;
    using ServiceModels;
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ArtProduct ,AllArtProducts >();
        }
    }
}
