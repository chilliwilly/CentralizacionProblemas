using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problema_class
{
    public class Problema
    {
        public String problema_id { get; set; }
        public String problema_fecha { get; set; }
        public String problema_informante { get; set; }
        public String problema_oioe { get; set; }        
        public String problema_detmejora { get; set; }
        public String problema_creadorpc { get; set; }
        public String area_id { get; set; }
        public String mejora_id { get; set; }
        public String amejora_id { get; set; }
        public String cliente_id { get; set; }
        public String nom_estado { get; set; }

        public Problema() { }

        public Problema(String problema_fecha, String problema_informante, String problema_oioe, String problema_detmejora, String problema_creadorpc, String area_id, String mejora_id, String amejora_id, String cliente_id)
        {
            //this.problema_id = problema_id;
            this.problema_fecha = problema_fecha;
            this.problema_informante = problema_oioe;
            this.problema_oioe = problema_oioe;
            this.problema_detmejora = problema_detmejora;
            this.problema_creadorpc = problema_creadorpc;
            this.area_id = area_id;
            this.mejora_id = mejora_id;
            this.amejora_id = amejora_id;
            this.cliente_id = cliente_id;
        }
    }
}
