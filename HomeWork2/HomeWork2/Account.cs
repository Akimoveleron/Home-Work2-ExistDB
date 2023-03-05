using System;
using System.Collections.Generic;

namespace HomeWork2;

public partial class Account
{
    public int Id { get; set; }

    public int? Amount { get; set; }

    public virtual ICollection<Client> Clients { get; } = new List<Client>();
}
