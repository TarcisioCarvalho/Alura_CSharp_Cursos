using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = MainAsync();
        }
        static async Task MainAsync()
        {
            //var doc = new BsonDocument()
            //{
            //    {"Titulo","A Guerra Dos Tronos"}
            //};
            //doc.Add("Autor", "Geoger R R Martin");
            //doc.Add("Ano", 1999);
            //doc.Add("Páginas", 856);
            //var assuntoArray = new BsonArray();
            //assuntoArray.Add("Ação");
            //assuntoArray.Add("Fantasia");
            //doc.Add("Assunto", assuntoArray);

            //Livro livro = new Livro()
            //{
            //    Titulo = "A Redoma",
            //    Autor = "Stephen King",
            //    Ano = 2012,
            //    Paginas = 679,
            //    Assuntos = new List<string>()
            //    {
            //        "Ação",
            //        "Ficção Cientifíca",
            //        "Aventura"
            //    }
            //};

            //Livro livro1 = new Livro()
            //{
            //    Titulo = "Star Wars",
            //    Autor = "Timoty",
            //    Ano = 2010,
            //    Paginas = 300,
            //    Assuntos = new List<string>()
            //    {
            //        "Ação",
            //        "Ficção Cientifica"
            //    }

            //};

            //InsertOnMongoDB(livro1);

            List<Livro> livros = new List<Livro>();
            livros.Add(new Livro("A Dança com os Dragões", "George R R Martin", 2011, 934, "Fantasia, Ação"));
            livros.Add(new Livro("Star Trek Portal do Tempo", "Crispin A C", 2002, 321, "Fantasia, Ação"));
            livros.Add(new Livro("Star Trek Enigmas", "Dedopolus Tim", 2006, 195, "Ficção Científica, Ação"));
            livros.Add(new Livro("Emília no Pais da Gramática", "Monteiro Lobato", 1936, 230, "Infantil, Literatura Brasileira, Didático"));
            livros.Add(new Livro("Chapelzinho Amarelo", "Chico Buarque", 2008, 123, "Infantil, Literatura Brasileira"));
            livros.Add(new Livro("20000 Léguas Submarinas", "Julio Verne", 1894, 256, "Ficção Científica, Ação"));
            livros.Add(new Livro("Primeiros Passos na Matemática", "Mantin Ibanez", 2014, 190, "Didático, Infantil"));
            livros.Add(new Livro("Saúde e Sabor", "Yeomans Matthew", 2012, 245, "Culinária, Didático"));
            livros.Add(new Livro("Goldfinger", "Iam Fleming", 1956, 267, "Espionagem, Ação"));
            livros.Add(new Livro("Da Rússia com Amor", "Iam Fleming", 1966, 245, "Espionagem, Ação"));
            livros.Add(new Livro("O Senhor dos Aneis", "J R R Token", 1948, 1956, "Fantasia, Ação"));

            // var T = InsertMultOnMongoDB(livros);
            // SearchOnMongo();
            SearchOnMongoFilter("George R R Martin");
        }
        static async Task InsertOnMongoDB(Livro livro)
        {
            AcessandoMongoDB acessandoMongoDB = new AcessandoMongoDB();
            acessandoMongoDB.Livros.InsertOneAsync(livro);
            Console.WriteLine("Documento Incluido!");
            Console.ReadLine();
        }
        static async Task InsertMultOnMongoDB(List<Livro> livros)
        {
            AcessandoMongoDB acessandoMongoDB = new AcessandoMongoDB();
            acessandoMongoDB.Livros.InsertManyAsync(livros);
            Console.WriteLine("Documentos Incluidos!");
            Console.ReadLine();
        }

        static void SearchOnMongo()
        {
            AcessandoMongoDB acessandoMongoDB = new AcessandoMongoDB();
            var listaLivros = acessandoMongoDB.Livros.Find(new BsonDocument()).ToList();

            listaLivros.ForEach(livro =>
            {
                Console.WriteLine(livro.ToJson<Livro>());
            });
        }

        static void SearchOnMongoFilter(string filter)
        {
            AcessandoMongoDB acessandoMongoDB = new AcessandoMongoDB();
            var filtro = new BsonDocument()
            {
                { "Autor",filter }
            };
            var listaLivros = acessandoMongoDB.Livros.Find(filtro).ToList();
            listaLivros.ForEach(livro =>
            {
                Console.WriteLine(livro.ToJson<Livro>());
            });
        }

        }
}
