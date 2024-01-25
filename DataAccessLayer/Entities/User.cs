using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class User
{
    public int Id { get; set; } // to be GUID

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    // Let's assume it is the only field that can be edited
    public string Username { get; set; }
    public DateTime? JoinDate { get; set; }

    public virtual UserDetails UserDetails { get; set; }
}
