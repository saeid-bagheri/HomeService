using System;
using System.Collections.Generic;

namespace HomeService.Models.Entities;

public partial class Offer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int OrderId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public double Price { get; set; }

    public virtual Order Order { get; set; } = null!;
}
