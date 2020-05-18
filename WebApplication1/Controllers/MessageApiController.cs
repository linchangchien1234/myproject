using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.sqlmodel;
namespace WebApplication1.Controllers
{
    public class MessageApiController : ApiController
    {
        vueapiEntities1 db = new vueapiEntities1();
        
        // GET api/<controller>
        public List<message> Get()
        {
            return db.messages.ToList();
        }

        // GET api/<controller>/5
        public message Get(int id)
        {
            var messages = db.messages.Find(id);
            return messages;
        }

        // POST api/<controller>
        public void Post([FromBody]message message)
        {
            db.messages.Add(message);
            db.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]message message)
        {
            var messages = db.messages.Find(id);
            messages.body = message.body;
            messages.userid = message.userid;
            db.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}