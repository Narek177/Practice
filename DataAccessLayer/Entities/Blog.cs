using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Blog
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public int? TagId { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual ICollection<BlogTag> BlogTags { get; set; } = new List<BlogTag>();
}
