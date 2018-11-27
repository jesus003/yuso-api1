using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using TESTAPI.Objetos;
namespace TESTAPI.Controllers
{
    public class LoginController : ApiController
    {
        
        BDClass conn = new BDClass();
        // GET: api/student
        [EnableCors(origins: "http://201.174.71.55", headers: "*", methods: "*")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/student/5
        public string Get(string usuario,string password)
        {
            ObjLogin login = conn.login(usuario,password);
            if (login.nombre!="")
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(login);
                return json;
            }
            else
            {
                return "{\"id\":0,\"nombre\":\"\"}";
            }
        }

        // POST: api/student
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/student/5
        public String Put(int id, int comezon, [FromBody]string value)
        {
            return "";
        }

        // DELETE: api/student/5
        public void Delete(int id)
        {
        }
    }
}
