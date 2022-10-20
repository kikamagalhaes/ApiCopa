using System.ComponentModel.DataAnnotations;

namespace apicopa.models
{
    public class Selecao
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(20)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(300)]
        public string Bandeira { get; set; }
    }
}
