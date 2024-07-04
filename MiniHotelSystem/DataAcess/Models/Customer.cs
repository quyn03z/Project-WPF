using System;
using System.Collections.Generic;

namespace DataAcess.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerFullName { get; set; } = null!;

    public string TelePhone { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public DateOnly CustormerBirthday { get; set; }

    public bool CustormetStatus { get; set; }

    public string Password { get; set; } = null!;
}
