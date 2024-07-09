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
            if (TimeCheckOut != null && TimeCheckIn != null && IdTableBiaNavigation != null && IdTableBiaNavigation.IdCategoryNavigation != null)
            {
                TimeSpan duration = TimeCheckOut.Value - TimeCheckIn;
                double price = IdTableBiaNavigation.IdCategoryNavigation.Price; // Assuming this is where the price is derived from
                return (double)duration.TotalHours * price; // Adjust formula as per your pricing logic
            }
            return 0; 
        }
    }

    public TimeSpan TimePlay
    {
        get
        {
            if (TimeCheckOut != null && TimeCheckIn != null && IdTableBiaNavigation != null && IdTableBiaNavigation.IdCategoryNavigation != null)
            {
                TimeSpan duration = TimeCheckOut.Value - TimeCheckIn;
                return duration;
            }
            else
            {
                // Handle null values or default cases
                return TimeSpan.Zero; // Return default value if conditions are not met
            }
        }
    }

}


