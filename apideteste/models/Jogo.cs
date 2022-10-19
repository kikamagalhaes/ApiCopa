using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace apideteste.models
{
    public class Jogo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id")]
        public int Id { get; set; }


        [Column(name: "SelecaoAId")]
        [Required]
        [ForeignKey("Selecao")]
        public int SelecaoAId { get; set; }
        public Selecao SelecaoA { get; set; }
        [Column(name: "SelecaoBId")]
        [Required]
        [ForeignKey("Selecao")]
        public int SelecaoBId { get; set; }
        public Selecao SelecaoB { get; set; }

        [Column(name: "GolSelecaoA")]
        [ForeignKey("Selecao")]
        public int GolsSelecaoA { get; set; }
        [Column(name: "GolSelecaoB")]
        public int GolsSelecaoB { get; set; }

        [Column(name: "FaseCopaId")]
        [Required]
        [ForeignKey("FaseCopa")]
        public int FaseCopaId { get; set; }
        public FaseCopa FaseCopa { get; set; }

        [Column(name: "InicioJogo")]
        public DateTime InicioJogo { get; set; }
        [Column(name: "FimJogo")]
        public DateTime FimJogo { get; set; }

        [Column(name: "TempoAtual")]
        public DateTime TempoAtual { get; set; }
    }
}
