using System;
using System.Collections.Generic;

namespace DemoMusic.Models;

public partial class Point
{
    public int Id { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
