using System;
using System.Collections.Generic;

namespace Semaine_3__LINQ___Entity_Framework.Models;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
