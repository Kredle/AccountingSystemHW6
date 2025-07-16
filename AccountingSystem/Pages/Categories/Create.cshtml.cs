using AccountingSystem.Data;
using AccountingSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystemHW6.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly AcountingDbContext _context;

        public CreateModel(AcountingDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PurchaseCategory Category { get; set; } = new();

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.PurchasesCategories.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}