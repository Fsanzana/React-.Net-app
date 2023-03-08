using System.ComponentModel.DataAnnotations;

namespace DSPMVC.Models
{
    public partial class DspClienteTipoResponse
    {
        [Key]
        public int CliTipoClienteID { get; set; }
        public string? CliDescripcionTipo { get; set; }
    }
}
