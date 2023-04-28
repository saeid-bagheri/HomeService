using System;
using System.Collections.Generic;

namespace HomeService.Models.Entities;

public partial class ExpertService
{
    public int ExpertId { get; set; }

    public int ServiceId { get; set; }

    public int? Score { get; set; }

    public virtual User Expert { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
