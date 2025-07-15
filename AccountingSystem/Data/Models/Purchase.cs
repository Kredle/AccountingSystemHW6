namespace AccountingSystem.Data.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public string? Comment { get; set; }

        public PurchaseCategory Category { get; set; }
    }
}
