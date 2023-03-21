using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    internal class AcessandoMongoDB
    {
        public string ConnectionString { get; set; }
        public IMongoClient Client { get; set; }
        public IMongoDatabase DataBase { get; set; }
        public IMongoCollection<BsonDocument> Colecao { get; set; }

        public AcessandoMongoDB()
        {
            ConnectionString = "mongodb://localhost:27017";

            Client = new MongoClient(ConnectionString);

            DataBase = Client.GetDatabase("Biblioteca");

            Colecao = DataBase.GetCollection<BsonDocument>("Livros");
        }

        public async Task InsertOnMongoDB(BsonDocument doc)
        {
            Colecao.InsertOneAsync(doc);
            Console.WriteLine("Documento Incluido!");
            Console.ReadLine();
        }
    }
}
