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
        public int SelecaoAId { get; set; }
        [Column(name: "SelecaoBId")]
        [Required]
        public int SelecaoBId { get; set; }
        [Column(name: "GolSelecaoA")]
        public int GolsSelecaoA { get; set; }
        [Column(name: "GolSelecaoB")]
        public int GolsSelecaoB { get; set; }

        [Column(name: "FaseId")]
        [Required]
        public int FaseCopaId { get; set; }
        [Column(name: "InicioJogo")]
        public DateTime InicioJogo { get; set; }
        [Column(name: "FimJogo")]
        public DateTime FimJogo { get; set; }

        [Column(name: "TempoAtual")]
        public DateTime TempoAtual { get; set; }
    }
}
