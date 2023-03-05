using System;
using System.Collections.Generic;

namespace HomeWork2;

public partial class Client
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Patronymic { get; set; }

    public string? Email { get; set; }

    public string? Passportnumber { get; set; }

    public string? Phonenumber { get; set; }

    public int? Accountid { get; set; }

    public int? Depositid { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Deposit? Deposit { get; set; }
}
