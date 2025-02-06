using System;
using System.Collections.Generic;

namespace Practic.Models;

public partial class Product
{
    public int Id { get; set; }

    public int ProductTypeId { get; set; }

    public string Title { get; set; } = null!;

    public string Articul { get; set; } = null!;

    public decimal MinPrice { get; set; }

    public virtual ICollection<PartnersProduct> PartnersProducts { get; set; } = new List<PartnersProduct>();

    public virtual ProductType ProductType { get; set; } = null!;
}
