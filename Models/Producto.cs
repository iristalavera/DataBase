using System;
using System.Collections.Generic;

namespace ReporteVentas.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Marca { get; set; } = null!;

    public string Talla { get; set; } = null!;

    public double Precio { get; set; }

    public int Stock { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
