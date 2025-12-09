using System;
using System.Collections.Generic;

namespace DemoMusic.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Role { get; set; }

    public string? Fio { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
