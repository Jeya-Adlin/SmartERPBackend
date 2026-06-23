namespace SmartERPBackend.Models
{
    public class Units :BaseEntitiy
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Companies Companies { get; set; }
        public string UnitName { get; set; }
        public string Symbol { get; set; }
        public ICollection<StockItems> StockItems { get; set; } = new List<StockItems>();


    }
}
