using System;
using System.Collections.Generic;

namespace ABMSucursales.Models;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string NombreSucursal { get; set; } = null!;

    public string DireccionSucursal { get; set; } = null!;

    public string TelefonoSucursal { get; set; } = null!;

    public string EmailSucursal { get; set; } = null!;

    public string AreaSucursal { get; set; } = null!;

    public int? NumeroEmpleadosSucursal { get; set; }

    public TimeSpan HorarioAtencionApertura { get; set; }

    public TimeSpan HorarioAtencionClausura { get; set; }

    public string? Observaciones { get; set; }

    public int? IdResponsable { get; set; }

    public virtual ResponsableSucursal? IdResponsableNavigation { get; set; }
}
