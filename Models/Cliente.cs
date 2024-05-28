using System;
using System.Collections.Generic;

namespace ReporteVentas.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NumCedula { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public virtual ICollection<CodigoPostal> CodigoPostals { get; set; } = new List<CodigoPostal>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
