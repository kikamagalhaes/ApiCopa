using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apideteste.models
{
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(name: "nome")]
        [MaxLength(255)]
        [Required]
        public string Nome { get; set; }
        [Column(name: "Telefone")]
        [MaxLength(255)]
        [Required]
        public string Telefone { get; set; }

    }
}
