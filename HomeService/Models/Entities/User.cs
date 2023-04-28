using System;
using System.Collections.Generic;

namespace HomeService.Models.Entities;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public string Family { get; set; } = null!;

    public string NationalCode { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Score { get; set; }

    public virtual ICollection<ExpertService> ExpertServices { get; set; } = new List<ExpertService>();

    public virtual ICollection<Order> OrderCustomers { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderExperts { get; set; } = new List<Order>();

    public virtual Role Role { get; set; } = null!;
}
