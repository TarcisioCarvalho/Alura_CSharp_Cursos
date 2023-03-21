using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    public class Livro
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public int Paginas { get; set; }
        public List<string> Assuntos { get; set; }

        public Livro()
        { 
        }

        public Livro( string titulo, string autor, int ano, int paginas, string assuntos)
        {
           
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Paginas = paginas;
            Assuntos = assuntos.Split(",").ToList();
        }
    }
}
