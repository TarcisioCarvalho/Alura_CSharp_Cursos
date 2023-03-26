using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace projetoBlog.Models
{
    public class Publicacao
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Autor { get; set; }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }

        public string[] Tags { get; set; }

        public DateTime DataCriacao { get; set; }

        public List<Comentario> Comentarios { get; set; }
    }
}