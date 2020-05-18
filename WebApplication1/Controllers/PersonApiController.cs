using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.sqlmodel;

namespace WebApplication1.Controllers
{
    public class PersonApiController : ApiController
    {
        vueapiEntities1 db = new vueapiEntities1();
        // GET: api/PersonApi
        public List<user> Get()
        {
            return db.users.ToList();
        }

        // GET: api/PersonApi/5
        public object Get(int id)
        {
            var aa = db.users.ToList();
            var i = from m in aa
                    where m.id == id
                    select m;
            return i;
        }

        // POST: api/PersonApi
        public void Post([FromBody]user user)
        {
            db.users.Add(user);
            db.SaveChanges();
        }

        // PUT: api/PersonApi/5
        public void Put(int id, [FromBody]user user)
        {
            var users = db.users.Find(id);
            users.account = user.account;
            users.adress = user.adress;
            users.email = user.email;
            users.name = user.name;
            users.password = user.password;
            users.hobby = user.hobby;
            db.SaveChanges();
        }

        // DELETE: api/PersonApi/5
        public void Delete(int id)
        {
            var users = db.users.Find(id);
            db.users.Remove(users);
            db.SaveChanges();
        }
    }
}