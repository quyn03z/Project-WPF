using System;
using System.Collections.Generic;

namespace DataAcess.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public int RoomId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual RoomInformation RoomInformation { get; set; } = null!;


}
