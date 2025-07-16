using AccountingSystem.Data;
using AccountingSystem.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AccountingSystemHW6.Pages.Purchases
{
    public class IndexModel : PageModel
    {
        private readonly AcountingDbContext _context;

        public IndexModel(AcountingDbContext context)
        {
            _context = context;
        }

        public List<Purchase> Purchases { get; set; } = new();

        public async Task OnGetAsync()
        {
            Purchases = await _context.Purchases.Include(p => p.Category).ToListAsync();
        }
    }
}
