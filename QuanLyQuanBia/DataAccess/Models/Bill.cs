using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Bill
{
    public int Id { get; set; }

    public DateTime TimeCheckIn { get; set; }

    public DateTime? TimeCheckOut { get; set; }

    public int IdTableBia { get; set; }

    public int Status { get; set; }

    public double totalPrice { get; set; }


    public virtual ICollection<BillInfo> BillInfos { get; set; } = new List<BillInfo>();

    public virtual TableBia IdTableBiaNavigation { get; set; } = null!;
    public double TotalPrice
    {
        get
        {
            if (TimeCheckOut != null && TimeCheckIn != null && IdTableBiaNavigation != null)
            {
                TimeSpan duration = TimeCheckOut.Value - TimeCheckIn;
                double price = IdTableBiaNavigation.IdCategoryNavigation.Price; // Assuming this is where the price is derived from
                return (double)duration.TotalHours * price; // Adjust formula as per your pricing logic
            }
            return 0; // Handle null values or default cases
        }
    }

}


