using AccountingSystem.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AccountingSystem.Data;

namespace AccountingSystemHW6.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AcountingDbContext _context;

        public IndexModel(AcountingDbContext context)
        {
            _context = context;
        }

        public List<PurchaseCategory> Categories { get; set; } = new();

        public async Task OnGetAsync()
        {
            Categories = await _context.PurchasesCategories.ToListAsync();
        }
    }
}