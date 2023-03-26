using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoBlog.Models.Home
{
    public class PublicacaoModel
    {
        public Publicacao Publicacao { get; set; }

        public NovoComentarioModel NovoComentario { get; set; }
    }
}