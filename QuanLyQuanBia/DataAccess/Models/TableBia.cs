using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess.Models;

public partial class TableBia
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int IdCategory { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual TableCategory IdCategoryNavigation { get; set; } = null!;

 

}
