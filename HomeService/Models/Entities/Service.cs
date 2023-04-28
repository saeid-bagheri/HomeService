using System;
using System.Collections.Generic;

namespace HomeService.Models.Entities;

public partial class Service
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ExpertService> ExpertServices { get; set; } = new List<ExpertService>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
}
