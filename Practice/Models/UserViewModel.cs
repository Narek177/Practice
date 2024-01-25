namespace Practice.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTime? JoinDate { get; set; } // ?? 

        public UserDetailsViewModel Details { get; set; }
    }
}
