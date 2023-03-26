using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using projetoBlog.Models;
using projetoBlog.Models.Home;
using System.Linq.Expressions;
using MongoDB.Bson;

namespace projetoBlog.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var dbMongo = new AcessoMongoDB();
            var PublicacoesRecentes = await dbMongo.Publicacoes.
                Find(new BsonDocument()).
                SortByDescending(pub => pub.DataCriacao).
                Limit(10).
                ToListAsync();

            //XXX TRABALHE AQUI
            // liste as dez mais recentes publicações
            // Descomente as linhas abaixo
            var model = new IndexModel
            {
                PublicacoesRecentes = PublicacoesRecentes
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult NovaPublicacao()
        {
            return View(new NovaPublicacaoModel());
        }

        [HttpPost]
        public async Task<ActionResult> NovaPublicacao(NovaPublicacaoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var post = new Publicacao()
            {
                Autor = User.Identity.Name,
                Titulo = model.Titulo,
                Conteudo = model.Conteudo,
                Tags = model.Tags.Split(' ', ',', ';'),
                DataCriacao = DateTime.Now,
                Comentarios = new List<Comentario>(),
            };

            //XXX TRABALHE AQUI
            // Inclua a publicação na base de dados
            // Descomete a linha abaixo
            var dbMongo = new AcessoMongoDB();
            await dbMongo.Publicacoes.InsertOneAsync(post);
            return RedirectToAction("Publicacao", new { id = post.Id });
        }

        [HttpGet]
        public async Task<ActionResult> Publicacao(string id)
        {

            //XXX TRABALHE AQUI
            // Busque na base MongoDB a publicação pelo ID

            var connectarMongoDB = new AcessoMongoDB();
            var publicacao = await connectarMongoDB.Publicacoes.Find(x => x.Id == id).SingleOrDefaultAsync();
            // Descomente as linhas abaixo
            if (publicacao == null)
            {
                return RedirectToAction("Index");
            }

            var model = new PublicacaoModel
            {
                Publicacao = publicacao,
                NovoComentario = new NovoComentarioModel
                {
                    PublicacaoId = id
                }
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Publicacoes(string tag = null)
        {
            var dbMongo = new AcessoMongoDB();
            
           
            List<Publicacao> posts = new List<Publicacao>();

            if (tag == null) posts = await dbMongo.Publicacoes
                    .Find(new BsonDocument())
                    .SortByDescending(pub => pub.DataCriacao)
                    .Limit(10)
                    .ToListAsync();
            
            if(tag != null)
            {
                var constructor = Builders<Publicacao>.Filter;
                var condicao = constructor.AnyEq(pub => pub.Tags, tag);
                posts = await dbMongo.Publicacoes
                    .Find(condicao)
                    .SortByDescending(pub => pub.DataCriacao)
                    .Limit(10)
                    .ToListAsync();
            }
                       
            return View(posts);
        }

        [HttpPost]
        public async Task<ActionResult> NovoComentario(NovoComentarioModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Publicacao", new { id = model.PublicacaoId });
            }

            var comentario = new Comentario()
            {
                Autor = User.Identity.Name,
                Conteudo = model.Conteudo,
                DataCriacao = DateTime.UtcNow
            };

            var dbMongo = new AcessoMongoDB();
            var constructor = Builders<Publicacao>.Filter;
            var condicao = constructor.Eq(pub => pub.Id , model.PublicacaoId);
            var constructorAlteracao = Builders<Publicacao>.Update;
            var condicaoAlteracao = constructorAlteracao.Push(pub => pub.Comentarios, comentario);

            await dbMongo.Publicacoes.UpdateOneAsync(condicao, condicaoAlteracao);
                        
             return RedirectToAction("Publicacao", new { id = model.PublicacaoId });
        }
    }
}