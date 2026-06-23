namespace SmartERPBackend.Models
{
    public class Ledgers:BaseEntitiy
    {
        public int Id {  get; set; }
        public string LedgerName { get; set; }

        public LedgerType LedgerType { get; set; }

        public int CompanyId { get; set; }
        public Companies Companies { get; set; }

        public string PhoneNo { get; set; }
        public string Email { get; set; }

        public bool IsActive { get; set; }

        public decimal OpeningBalance { get; set; }

    }

    public enum LedgerType
    {
        CUSTOMER,
        SUPPLIER,
        CASH,
        BANK,
        EXPENSE,
        INCOME
    }
}
