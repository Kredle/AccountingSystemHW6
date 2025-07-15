using AccountingSystem.Data;
using AccountingSystem.Data.DTO;
using AccountingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace AccountingSystem.Repositories.Categories
{
    public class SQLServerCategoryRepository: IPurchaseCategoryRepository
    {
        private readonly AcountingDbContext _dbContext;

        public SQLServerCategoryRepository(AcountingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PurchaseCategory>> GetAll()
        {
            return await _dbContext.PurchasesCategories.ToListAsync();
        }

        public async Task<PurchaseCategory?> GetById(int id)
        {
            return await _dbContext.PurchasesCategories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PurchaseCategory> Create(AddCategoryRequestDTO addCategoryRequestDTO)
        {
            var category = new PurchaseCategory { Name =  addCategoryRequestDTO.Name };
            await _dbContext.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<PurchaseCategory?> Update(int id, UpdateCategoryRequestDTO updateCategoryRequestDTO)
        {
            var category = await _dbContext.PurchasesCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null) return null;

            category.Name = updateCategoryRequestDTO.Name;
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<PurchaseCategory?> Delete(int id)
        {
            var category = await _dbContext.PurchasesCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null) return null;

            _dbContext.PurchasesCategories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }
    }
}
