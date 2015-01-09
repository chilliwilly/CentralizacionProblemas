using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problema_class
{
    public class DetalleSeguimiento
    {
        public String seguimiento_id { get; set; }
        public String estado_id { get; set; }
        public String problema_id { get; set; }
        public String seguimiento_responsable { get; set; }
        public String seguimiento_accion { get; set; }
        public String seguimiento_fcompromiso { get; set; }
        public String seguimiento_fcierre { get; set; }
        public String seguimiento_observacion { get; set; }

        public DetalleSeguimiento() { }
    }
}
