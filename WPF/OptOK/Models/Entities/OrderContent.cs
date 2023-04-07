﻿using System;
using System.Collections.Generic;

namespace OptOK.Models.Entities;

public partial class OrderContent
{
    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
