using System;
using System.Collections.Generic;

namespace HomeService.Models.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int ServiceId { get; set; }

    public int CustomerId { get; set; }

    public int? ExpertId { get; set; }

    public DateTime CreateOrderDate { get; set; }

    public int CustomerScore { get; set; }

    public int ExpertScore { get; set; }

    public virtual User Customer { get; set; } = null!;

    public virtual User? Expert { get; set; }

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual Service Service { get; set; } = null!;
}
