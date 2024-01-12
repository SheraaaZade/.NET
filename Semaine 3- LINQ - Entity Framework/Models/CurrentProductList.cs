using System;
using System.Collections.Generic;

namespace Semaine_3__LINQ___Entity_Framework.Models;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
