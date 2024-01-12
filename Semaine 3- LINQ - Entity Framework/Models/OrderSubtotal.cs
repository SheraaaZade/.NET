using System;
using System.Collections.Generic;

namespace Semaine_3__LINQ___Entity_Framework.Models;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
