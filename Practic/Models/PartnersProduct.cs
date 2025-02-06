using System;
using System.Collections.Generic;

namespace Practic.Models;

public partial class PartnersProduct
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int PartnerId { get; set; }

    public int Quantity { get; set; }

    public DateOnly SaleDate { get; set; }

    public virtual Partner Partner { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
