using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.sqlmodel;

namespace WebApplication1.Controllers
{
    public class MessagesToArticleController : ApiController
    {
        vueapiEntities1 db = new vueapiEntities1();
        // GET: api/MessagesToArticle
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MessagesToArticle/5
        public string Get(int id)
        {

            return "value";
        }

        // POST: api/MessagesToArticle
        public void Post([FromBody] article_message articleTomessage)
        {
            db.article_message.Add(articleTomessage);
            db.SaveChanges();
        }

        // PUT: api/MessagesToArticle/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MessagesToArticle/5
        public void Delete(int id)
        {
        }
    }
}
