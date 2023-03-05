using System;
using System.Collections.Generic;

namespace HomeWork2;

public partial class Deposit
{
    public int Id { get; set; }

    public int? Managerid { get; set; }

    public DateTime? Opennigdate { get; set; }

    public virtual ICollection<Client> Clients { get; } = new List<Client>();

    public virtual Manager? Manager { get; set; }
}
