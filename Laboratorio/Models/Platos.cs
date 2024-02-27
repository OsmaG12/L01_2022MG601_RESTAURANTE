using System.ComponentModel.DataAnnotations;

namespace Laboratorio.Models
{
    public class Platos
    {
        [Key]
        public int platoId { get; set; }
        public string nombrePlato { get; set; }
        public decimal precio { get; set; }
    }
}
