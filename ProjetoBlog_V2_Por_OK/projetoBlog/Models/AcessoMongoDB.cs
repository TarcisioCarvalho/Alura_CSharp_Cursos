using MongoDB.Bson;
using MongoDB.Driver;

namespace projetoBlog.Models
{
    public class AcessoMongoDB
    {

        public const string CONNECTION_STRING = "mongodb://localhost:27017";
        public const string NAME_DATABASE = "Blog";
        public const string NAME_COLLECTION_USUARIOS = "Usuarios";
        public const string NAME_COLLECTION_PUBLICACOES = "Publicacoes";

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

        public IMongoCollection<Usuario> Usuarios
        {
            get
            {
                return _dataBase.GetCollection<Usuario>(NAME_COLLECTION_USUARIOS);
            }
        }

        public IMongoCollection<Publicacao> Publicacoes
        {
            get
            {
                return _dataBase.GetCollection<Publicacao>(NAME_COLLECTION_PUBLICACOES);
            }
        }
        public AcessoMongoDB()
        {
            _client = new MongoClient(CONNECTION_STRING);
            _dataBase = _client.GetDatabase(NAME_DATABASE);
        }

    }
}
