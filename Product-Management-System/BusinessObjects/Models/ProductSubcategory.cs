﻿using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class ProductSubcategory
{
    public int SubcategoryId { get; set; }

    public string? Category { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
