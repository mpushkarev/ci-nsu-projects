using System;
using System.Collections.Generic;

namespace DemoMusic.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? OrderNum { get; set; }

    public int? EquipmentId { get; set; }

    public int? Count { get; set; }

    public DateTime? StartDay { get; set; }

    public int? PointId { get; set; }

    public int? ClientId { get; set; }

    public int? Code { get; set; }

    public string? Status { get; set; }

    public virtual User? Client { get; set; }

    public virtual Equipment? Equipment { get; set; }

    public virtual Point? Point { get; set; }
}
