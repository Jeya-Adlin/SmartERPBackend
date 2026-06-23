namespace SmartERPBackend.Models
{
    public class Companies:BaseEntitiy
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string GSTNumber { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }

        public string FinancialYear { get; set; }

        public string State { get; set; }

        public string ContactNo { get; set; }

        public ICollection<Ledgers> Ledgers { get; set; } = new List<Ledgers>();
        public ICollection<Units> Units { get; set; } = new List<Units>();
        public ICollection <StockItems> StockItems { get; set; } = new List <StockItems>();

    }
}
