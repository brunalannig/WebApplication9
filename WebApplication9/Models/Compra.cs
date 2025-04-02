using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models
{
    public class Compra
    {
        [Key]
        public int IdCompra { get; set; }
        public int? IdPessoa { get; set; }
        public float? Valor { get; set; }
        public int? NumeroNotaFiscal { get; set; }
    }
}
