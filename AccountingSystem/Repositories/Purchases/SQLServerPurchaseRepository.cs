using AccountingSystem.Data;
using AccountingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingSystem.Repositories.Purchases
{
    public class SQLServerPurchaseRepository: IPurchaseRepository
    {
        private readonly AcountingDbContext _dbContext;

        public SQLServerPurchaseRepository(AcountingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Purchase>> GetAll()
        {
            return await _dbContext.Purchases.ToListAsync();
        } 

        public async Task<Purchase?> GetById(int id)
        {
            var purchase = await _dbContext.Purchases.FirstOrDefaultAsync(x => x.Id == id);
            if (purchase == null) return null;

            return purchase;
        }
    }
}
