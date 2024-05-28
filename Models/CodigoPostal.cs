using System;
using System.Collections.Generic;

namespace ReporteVentas.Models;

public partial class CodigoPostal
{
    public int IdCodigo { get; set; }

    public int IdCliente { get; set; }

    public int Codigo { get; set; }

    public string Localidad { get; set; } = null!;

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<Proveedor> Proveedors { get; set; } = new List<Proveedor>();
}
