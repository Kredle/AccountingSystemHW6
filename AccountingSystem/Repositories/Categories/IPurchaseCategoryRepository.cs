using AccountingSystem.Data.DTO;
using AccountingSystem.Data.Models;

namespace AccountingSystem.Repositories.Categories
{
    public interface IPurchaseCategoryRepository
    {
        Task<List<PurchaseCategory>> GetAll();

        Task<PurchaseCategory?> GetById(int id);

        Task<PurchaseCategory> Create(AddCategoryRequestDTO addCategoryRequestDTO);

        Task<PurchaseCategory?> Update(int id, UpdateCategoryRequestDTO updateCategoryRequestDTO);

        Task<PurchaseCategory?> Delete(int id);
    }
}
