using System;
using System.Collections.Generic;

namespace ReporteVentas.Models;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public int IdCliente { get; set; }

    public int IdProducto { get; set; }

    public DateTime Fecha { get; set; }

    public double Monto { get; set; }

    public string FormaPago { get; set; } = null!;

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
