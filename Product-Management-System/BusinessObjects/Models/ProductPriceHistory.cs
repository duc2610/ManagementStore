﻿using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class ProductPriceHistory
{
    public int ProductId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal Price { get; set; }

    public virtual Product Product { get; set; } = null!;
}
