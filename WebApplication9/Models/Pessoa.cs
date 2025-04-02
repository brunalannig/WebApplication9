using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models
{
    public class Pessoa
    {
        [Key]
        public int IdPessoa { get; set; }
        public string? Nome { get; set; }
        public int? IdEstadoCivil { get; set; }
        public int? Idade { get; set; }
    }
}
