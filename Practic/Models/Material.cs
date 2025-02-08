using System;
using System.Collections.Generic;

namespace Practic.Models;

public partial class Material
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Percent { get; set; }
}
