﻿using System.ComponentModel.DataAnnotations;

namespace apideteste.models
{
    public class Selecao
    {
        [Key]
        public int SelecaoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(20)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(300)]
        public string UrlImagemBandeira { get; set; }
    }
}
