using System;
using System.Collections.Generic;

namespace DSPMVC.Models;

public partial class ClientesDispatcherOpc
{
    public string CliCod { get; set; } = null!;

    public int? CliTipoClienteId { get; set; }

    public string? CodTpRdCli { get; set; }

    public string? CliRegion { get; set; }

    public string? CliPassword { get; set; }

    public int? CliSector { get; set; }

    public bool? CliTicket { get; set; }

    public string? CliDescripcion { get; set; }

    public int? CliExcesoVel { get; set; }

    public int? CliDetencionMin { get; set; }

    public int? CliDetencionMax { get; set; }

    public string? CliBuzonesAlerta { get; set; }

    public bool? CliZonaCiega { get; set; }

    public bool? CliZonaRuta { get; set; }

    public bool? CliZonaDesacople { get; set; }

    public int? CliMntsZonaCiega { get; set; }

    public bool? CliZonaSalida { get; set; }

    public bool? CliEntraZona { get; set; }

    public bool? CliAlerTodos { get; set; }

    public string? AlertipId { get; set; }

    public decimal? CliMinAlerta { get; set; }

    public bool? CliInteres { get; set; }

    public bool? CliDetPermitido { get; set; }

    public int? IdTipoZonaIt { get; set; }

    public int? CliSobreestadia { get; set; }
}
