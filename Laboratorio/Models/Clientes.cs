using System.ComponentModel.DataAnnotations;

namespace Laboratorio.Models
{
    public class Clientes
    {
        [Key]
        public int clienteId { get; set; }
        public string nombreCliente { get; set; }
        public string direccion { get; set; }
    }
}
