using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apideteste.models
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id")]

        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(255)]
        [Column(name: "nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [MaxLength(100)]
        [Column(name: "email")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
        [Column(name: "senha")]

        public string Senha { get; set; }

        [NotMapped]
        public string Perm => "admin";
    }
}
