using System;
using System.Collections.Generic;

namespace Practic.Models;

public partial class Partner
{
    public int Id { get; set; }

    public int Type { get; set; }

    public string Title { get; set; } = null!;

    public string Director { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Inn { get; set; } = null!;

    public short Rating { get; set; }

    public byte[]? Logo { get; set; }

    public virtual ICollection<PartnersProduct> PartnersProducts { get; set; } = new List<PartnersProduct>();

    public virtual PartenersType TypeNavigation { get; set; } = null!;
}
