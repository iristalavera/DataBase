using System;
using System.Collections.Generic;

namespace ReporteVentas.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public int IdCodigo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public virtual CodigoPostal IdCodigoNavigation { get; set; } = null!;
}
