using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TESTAPI.Objetos
{
    public class ObjListFallas
    {
        public string apodo { get; set; }
        public Int64 folio { get; set; }
        public string nombres { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public string fecha { get; set; }
        public Boolean cierre { get; set; }
        public Boolean iniciado { get; set; }
        public string reservacion { get; set; }
    }
}