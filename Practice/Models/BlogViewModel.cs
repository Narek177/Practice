namespace Practice.Models
{
    public class BlogViewModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        public int? TagId { get; set; }

        public DateTime? CreateDate { get; set; }
        public List<BlogViewModel> BlogTags { get; set; } = new List<BlogViewModel>();
    }
}
