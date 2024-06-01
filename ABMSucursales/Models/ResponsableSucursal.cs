using System;
using System.Collections.Generic;

namespace ABMSucursales.Models;

public partial class ResponsableSucursal
{
    public int IdResponsable { get; set; }

    public string NombreResponsable { get; set; } = null!;

    public string ApellidoResponsable { get; set; } = null!;

    public string? CargoResponsable { get; set; }

    public string EmailResponsable { get; set; } = null!;

    public string TelefonoResponsable { get; set; } = null!;

    public TimeSpan HorarioAtencionApertura { get; set; }

    public TimeSpan HorarioAtencionClausura { get; set; }

    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();
}
