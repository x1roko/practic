using System;
using System.Collections.Generic;

namespace Practic.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
