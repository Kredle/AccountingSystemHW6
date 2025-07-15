namespace AccountingSystem.Data.Models
{
    public class PurchaseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Purchase> Purchases { get; set; }
    }
}
