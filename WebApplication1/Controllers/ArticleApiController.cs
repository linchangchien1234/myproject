using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.sqlmodel;

namespace WebApplication1.Controllers
{    
    
    public class ArticleApiController : ApiController
    {
        vueapiEntities1 db = new vueapiEntities1();
        // GET api/<controller>
        public object Get()
        {            
            var aa = db.articles.ToList();
            var bb = db.users.ToList();
            var i = from n in aa
                    join m in bb
                    on n.userid equals m.id                    
                    select new { n ,m};            
            return i;
        }

        // GET: api/ArticleApi/5
        public object Get(int id)
        {
            var aa = db.articles.ToList();
            var bb = db.users.ToList();
            var cc = db.article_message.ToList();
            var dd = db.messages.ToList();

            var i = from n in aa
                    where n.id == id
                    join m in bb
                    on n.userid equals m.id
                    join o in cc
                    on n.id equals o.articleid
                    join p in dd
                    on o.messageid equals p.id
                    join q in bb
                    on p.userid equals q.id
                    select new { n, m, o, p, q };
            return i;
         }
        

        // POST: api/ArticleApi
        [HttpPost]
        public void ABC([FromBody]article article)
        {
            db.articles.Add(article);
            db.SaveChanges();
        }

        // PUT: api/ArticleApi/5
        public void Put(int id, [FromBody]article article)
        {
            var articles = db.articles.Find(id);
            articles.header = article.header;
            articles.body = article.body;
            articles.userid = article.userid;
            db.SaveChanges();
        }

        // DELETE: api/ArticleApi/5
        public void Delete(int id)
        {
            var articles = db.articles.Find(id);
            db.articles.Remove(articles);
            db.SaveChanges();
        }
    }
}