using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetoBlog.Models.Home
{
    public class NovaPublicacaoModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Conteúdo")]
        public string Conteudo { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Tag")]
        public string Tags { get; set; }
    }
}