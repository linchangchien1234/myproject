using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.sqlmodel;

namespace WebApplication1.Controllers
{    
    public class TestController : ApiController
    {
        vueapiEntities1 db = new vueapiEntities1();
        // GET api/<controller>
        public object Get()
        {
            var aa = db.tests.ToList();
            var i = from n in aa
                    select n;
            return i;
        }

        // GET api/<controller>/5
        public object Get(int id)
        {
            var aa = db.tests.ToList();
            var i = from n in aa
                    where n.id == id
                    select new { n };
            return i;
        }

        // POST api/<controller>
        public void Post([FromBody]test test)
        {
            db.tests.Add(test);
            db.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}