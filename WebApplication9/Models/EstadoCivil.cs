using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models
{
    public class EstadoCivil
    {
        [Key]
        public int IdEstadoCivil { get; set; }
        public string? Descricao { get; set; }
    }
}
