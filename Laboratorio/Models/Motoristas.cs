using System.ComponentModel.DataAnnotations;

namespace Laboratorio.Models
{
    public class Motoristas
    {
        [Key]
        public int motoristaId { get; set; }
        public string nombreMotorista { get; set; } 
    }
}
