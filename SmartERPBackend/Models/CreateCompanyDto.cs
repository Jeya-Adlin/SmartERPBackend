namespace SmartERPBackend.Models
{
        public class CreateCompanyDto
        {
            public string CompanyName { get; set; }
            public string Address { get; set; }
            public string GstNumber { get; set; }
            public string FinancialYear { get; set; }
            public string State { get; set; }
            public string ContactNo { get; set; }
            
            public int UserId { get; set; }
        }
}
