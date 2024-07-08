using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class BillInfo
{
    public int Id { get; set; }

    public int IdBill { get; set; }

    public int IdWater { get; set; }

    public int Quantity { get; set; }

    public virtual Bill IdBillNavigation { get; set; } = null!;

    public virtual Water IdWaterNavigation { get; set; } = null!;
    public double TotalPrice
    {
        get
        {
            if (IdWaterNavigation != null)
            {
                return IdWaterNavigation.Price * Quantity;
            }
            return 0; // Return 0 if IdWaterNavigation is null
        }
    }

}
