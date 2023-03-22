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


        public const string CONNECTION_STRING = "mongodb://localhost:27017";
        public const string NAME_DATABASE = "Biblioteca";
        public const string NAME_COLLECTION = "Livros";

        private readonly IMongoClient _client;
        private readonly IMongoDatabase _dataBase;

        public IMongoClient Client
        {
            get
            {
                return _client;
            }
        }

        public IMongoDatabase DataBase { get { return _dataBase; } }

        public IMongoCollection<Livro> Livros
        {
            get
            {
                return _dataBase.GetCollection<Livro>(NAME_COLLECTION);
            }
        }
        public AcessandoMongoDB()
        {
            _client = new MongoClient(CONNECTION_STRING);
            _dataBase = _client.GetDatabase(NAME_DATABASE);
        }




    }

}
