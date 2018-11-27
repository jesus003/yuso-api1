using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TESTAPI.Models
{
    public class Evento
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int tbl_id { get; set; }
        public string id { get; set; }
        public string user { get; set; }
        public string fecha { get; set; }
        public int personas { get; set; }
        public string categoria { get; set; }
        public string descripcion { get; set; }
    }
}