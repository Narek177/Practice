using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public int UserId { get; set; }

    public int BlogId { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual Blog Blog { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
