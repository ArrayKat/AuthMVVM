using System;
using System.Collections.Generic;

namespace AvaloniaApplication1.Models;

public partial class RoleUser
{
    public int Id { get; set; }

    public string NameRole { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
