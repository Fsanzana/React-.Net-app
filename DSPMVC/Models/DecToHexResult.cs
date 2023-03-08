using System.ComponentModel.DataAnnotations;

namespace DSPMVC.Models
{
    public partial class DecToHexResult
    {
        [Key]
        public string Valor { get; set; } = null!;
    }
}
