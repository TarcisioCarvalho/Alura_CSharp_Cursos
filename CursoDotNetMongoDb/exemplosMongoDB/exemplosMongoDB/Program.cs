using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainAsync();
        }
        static async Task MainAsync()
        {
            var doc = new BsonDocument()
            {
                {"Titulo","A Guerra Dos Tronos"}
            };
            doc.Add("Autor", "Geoger R R Martin");
            doc.Add("Ano", 1999);
            doc.Add("Páginas", 856);
            var assuntoArray = new BsonArray();
            assuntoArray.Add("Ação");
            assuntoArray.Add("Fantasia");
            doc.Add("Assunto", assuntoArray);

            AcessandoMongoDB acessandoMongoDB = new AcessandoMongoDB();
            acessandoMongoDB.InsertOnMongoDB(doc);
        }
    }
}
