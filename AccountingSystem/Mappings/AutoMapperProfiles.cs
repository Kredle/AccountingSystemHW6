using AccountingSystem.Data.DTO;
using AccountingSystem.Data.Models;
using AutoMapper;

namespace AccountingSystem.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() { 
        
            CreateMap<Purchase, PurchaseDTO>().ReverseMap();
            CreateMap<PurchaseCategory, PurchaseCategoryDTO>().ReverseMap();
            CreateMap<AddCategoryRequestDTO, PurchaseCategory>().ReverseMap();
            CreateMap<UpdateCategoryRequestDTO, PurchaseCategory>().ReverseMap();
        }
    }
}
