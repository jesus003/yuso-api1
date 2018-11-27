using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TESTAPI.Objetos;

namespace TESTAPI.Controllers
{
    public class ListServiciosController : ApiController
    {
        BDClass conn = new BDClass();
        // GET: api/ListServicios
        public string Get(string id)
        {
           List<ObjListFallas> lsit  = conn.listReportes(id);
            string strserialize = JsonConvert.SerializeObject(lsit);
            return strserialize;

        }

       
        // POST: api/ListServicios
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListServicios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListServicios/5
        public void Delete(int id)
        {
        }
    }
}
