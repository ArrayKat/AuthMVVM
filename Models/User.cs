using System;
using System.Collections.Generic;

namespace AvaloniaApplication1.Models;

public partial class User
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Login { get; set; } = null!;

    public byte[] Passvord { get; set; } = null!;

    public byte[]? Image { get; set; }

    public int? IdRole { get; set; }

    public virtual RoleUser? IdRoleNavigation { get; set; }
}
