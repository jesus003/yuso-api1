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
    public class ListServiciosPendientesController : ApiController
    {
        BDClass conn = new BDClass();
        // GET: api/ListServiciosPendientes
        public string Get(string id)
        {
            List<ObjListFallas> lsit = conn.listReportesPendientes(id);
            string strserialize = JsonConvert.SerializeObject(lsit);
            return strserialize;
        }

      

        // POST: api/ListServiciosPendientes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListServiciosPendientes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListServiciosPendientes/5
        public void Delete(int id)
        {
        }
    }
}
