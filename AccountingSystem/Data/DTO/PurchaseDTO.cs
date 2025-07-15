using AccountingSystem.Data.Models;

namespace AccountingSystem.Data.DTO
{
    public class PurchaseDTO
    {
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public string? Comment { get; set; }
    }
}
