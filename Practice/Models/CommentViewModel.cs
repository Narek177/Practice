namespace Practice.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string? Text { get; set; }

        public int UserId { get; set; }

        public int BlogId { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
