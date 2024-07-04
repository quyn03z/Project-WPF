using System;
using System.Collections.Generic;

namespace DataAcess.Models;

public partial class RoomType
{
    public int RoomTypeId { get; set; }

    public string RoomTypeName { get; set; } = null!;

    public string TypeDescription { get; set; } = null!;

    public string TypenNote { get; set; } = null!;

}
