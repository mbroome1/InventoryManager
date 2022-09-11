using AutoMapper;

namespace InventoryManager.Api.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<Entites.Stock, Models.StockDto>();
            CreateMap<Models.StockDto, Entites.Stock>();
            CreateMap<Models.StockForCreationDto, Entites.Stock>();
            CreateMap<Models.StockForUpdateDto, Entites.Stock>();

            CreateMap<Entites.Category, Models.CategoryDto>();
            CreateMap<Models.CategoryDto, Entites.Category>();
        }
    }
}
