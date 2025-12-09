using System;
using System.Collections.Generic;

namespace DemoMusic.Models;

public partial class Equipment
{
    public int Id { get; set; }

    public string? Art { get; set; }

    public string? Name { get; set; }

    public string? Unit { get; set; }

    public double? Cost { get; set; }

    public string? Supp { get; set; }

    public string? Manuf { get; set; }

    public string? Type { get; set; }

    public double? Discount { get; set; }

    public int? Avail { get; set; }

    public string? Desc { get; set; }

    public string? Pic { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
