namespace Practice.Models
{
    public class CreateUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? JoinDate { get; set; } // ?? 
        public string Address { get; set; }
        public string Username { get; set; }

    }
}
