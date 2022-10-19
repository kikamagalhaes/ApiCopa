using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apideteste.models
{
    public class FaseCopa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id")]

        public int Id { get; set; }

        [Column(name: "nome")]
        [MaxLength(255)]
        [Required]
        public string Nome { get; set; }
    }
}
