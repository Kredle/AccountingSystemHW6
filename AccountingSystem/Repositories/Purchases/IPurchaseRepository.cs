using AccountingSystem.Data.Models;

namespace AccountingSystem.Repositories.Purchases
{
    public interface IPurchaseRepository
    {
        Task<List<Purchase>> GetAll();

        Task<Purchase?> GetById(int id);

        // Other CRUD operations can be added in the future
    }
}
