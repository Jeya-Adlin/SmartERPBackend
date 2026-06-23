namespace SmartERPBackend.Models
{
    public class Users:BaseEntitiy
    {
        public int Id {  get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }


        //Navigation property

        public ICollection<Companies> Companies   { get; set; }
        =new List<Companies>();

    }
}
