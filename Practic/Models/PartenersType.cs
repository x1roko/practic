using System;
using System.Collections.Generic;

namespace Practic.Models;

public partial class PartenersType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
}
