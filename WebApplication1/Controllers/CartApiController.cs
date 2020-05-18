using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.sqlmodel;

namespace WebApplication1.Controllers
{
    public class CartApiController : ApiController
    {
        vueapiEntities1 db = new vueapiEntities1();
        // GET api/<controller>
        public object Get()
        {
            var bb = db.carts.ToList();            
            return bb;
        }

        // GET api/<controller>/5
        public object Get(int id)
        {
            var aa = db.users.ToList();
            var bb = db.carts.ToList();
            var cc = db.members.ToList();
            var dd = db.uermembers.ToList();
            var ee = db.buys.ToList();

            var i = from n in ee
                    where n.userid == id
                    join m in aa
                    on n.userid equals m.id
                    join o in bb 
                    on n.cartid equals o.id
                    join p in dd
                    on m.id equals p.userid
                    join q in cc
                    on p.memberid equals q.id                    
                    select new { n, m, o, p, q };
            return i;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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