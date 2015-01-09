using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using problema_class;
using problema_dal;
using System.Data;

namespace problema_bal
{
    public class adjunto_bal
    {
        adjunto_dal objAdj;

        public void addAdjunto(String usr_pc, String nomdoc, String dirdoc)
        {
            objAdj = new adjunto_dal();
            objAdj.insertAdjunto(usr_pc, nomdoc, dirdoc);
        }

        public void deleteAdjunto(String idadj, String idmejora)
        {
            objAdj = new adjunto_dal();
            int id_adj = int.Parse(idadj);
            int id_mejora = int.Parse(idmejora);
            objAdj.deleteAdjunto(id_adj, id_mejora);
        }

        public List<Adjunto> getAdjunto(String id_mejora)
        {
            objAdj = new adjunto_dal();
            int mejora_id = int.Parse(id_mejora);
            List<Adjunto> lsAdj = new List<Adjunto>();
            DataTable dt = objAdj.selectAdjunto(mejora_id).Tables["cur_datos"];

            foreach (DataRow dr in dt.Rows)
            {
                Adjunto objAdju = new Adjunto();
                objAdju.adjunto_id = dr["ADJUNTO_ID"].ToString();
                objAdju.usrpc_id = dr["PROBLEMA_ID"].ToString();
                objAdju.adjunto_nombre = dr["ADJUNTO_NOMBRE"].ToString();
                objAdju.adjunto_dir = dr["ADJUNTO_DIR"].ToString();
                lsAdj.Add(objAdju);
            }

            return lsAdj;
        }

        public String adjuntarDocumento(String file_name, String pc_usr) 
        {
            String dirFile = "~/adjunto_doc/";

            String arch = System.IO.Path.GetFileName(file_name);
            String[] nomArch = arch.Split('.');
            String dirArch = arch;

            addAdjunto(pc_usr, nomArch[0], dirArch);

            return dirArch;
        }
    }
}
