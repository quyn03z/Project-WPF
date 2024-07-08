using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class TableCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public virtual ICollection<TableBia> TableBia { get; set; } = new List<TableBia>();
}
