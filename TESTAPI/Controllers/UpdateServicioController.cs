using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TESTAPI.Objetos;

namespace TESTAPI.Controllers
{
    public class UpdateServicioController : ApiController
    {
        BDClass conn = new BDClass();
        // GET: api/UpdateServicio
        public string Get(Int64 folio, byte caso)
        {
            int valid = conn.update_servicio(folio,caso);
            if (valid == 1)
            {
                return "{\"valid\": \"1\" }";
            }
            else {
                return "{\"valid\": \"0\" }";
            }
        }

        // GET: api/UpdateServicio/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UpdateServicio
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UpdateServicio/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UpdateServicio/5
        public void Delete(int id)
        {
        }
    }
}
