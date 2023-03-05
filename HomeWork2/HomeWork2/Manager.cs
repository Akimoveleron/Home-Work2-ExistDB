using System;
using System.Collections.Generic;

namespace HomeWork2;

public partial class Manager
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Patronymic { get; set; }

    public string? Email { get; set; }

    public string? Managerposition { get; set; }

    public string? Phonenumber { get; set; }

    public virtual ICollection<Deposit> Deposits { get; } = new List<Deposit>();
}
