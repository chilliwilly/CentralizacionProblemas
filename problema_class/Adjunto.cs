using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problema_class
{
    public class Adjunto
    {
        public String adjunto_id { get; set; }
        public String usrpc_id { get; set; }
        public String adjunto_nombre { get; set; }
        public String adjunto_dir { get; set; }

        public Adjunto(String adjunto_id, String usrpc_id, String adjunto_nombre, String adjunto_dir)
        {
            this.adjunto_id = adjunto_id;
            this.usrpc_id = usrpc_id;
            this.adjunto_nombre = adjunto_nombre;
            this.adjunto_dir = adjunto_dir;
        }

        public Adjunto() { }
    }
}
