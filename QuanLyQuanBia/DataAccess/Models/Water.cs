using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Water
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public virtual ICollection<BillInfo> BillInfos { get; set; } = new List<BillInfo>();
}
