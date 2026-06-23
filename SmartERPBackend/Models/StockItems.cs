namespace SmartERPBackend.Models
{
    public class StockItems: BaseEntitiy
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int CompanyId { get; set; }
        public Companies Companies { get; set; }

        public String SKU { get; set; }

        public int UnitId { get; set; }
        public Units Units { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Quantity { get; set; }


    }
}
