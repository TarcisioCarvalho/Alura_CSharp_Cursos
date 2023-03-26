using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoBlog.Models.Home
{
    public class NovoComentarioModel
    {
        [HiddenInput(DisplayValue = false)]
        public string PublicacaoId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Comentário")]
        public string Conteudo { get; set; }
    }
}