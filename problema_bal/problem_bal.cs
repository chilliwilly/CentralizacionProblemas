using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using problema_class;
using problema_dal;
using System.Data;

namespace problema_bal
{
    public class problem_bal
    {
        problem_dal objProblemaDal;

        public void setProblema(Problema p) 
        {
            objProblemaDal = new problem_dal();
            
            int p_area_id = Convert.ToInt32(p.area_id);
            int p_mejora_id = Convert.ToInt32(p.mejora_id);
            int p_amejora_id = Convert.ToInt32(p.amejora_id);
            int p_cliente_id = Convert.ToInt32(p.cliente_id);           

            objProblemaDal.insertProblema(p.problema_fecha, p.problema_informante, p.problema_oioe, p.problema_detmejora, p.problema_creadorpc, p_area_id, p_mejora_id, p_amejora_id, p_cliente_id);
        }

        public Boolean validaFecha(String inFecha) 
        {
            Boolean flag = true;
            DateTime dt;
            if (!(DateTime.TryParse(inFecha, out dt)))
            {
                flag = false;
            }

            return flag;
        }

        public List<Problema> getAllProblema() 
        {
            objProblemaDal = new problem_dal();
            List<Problema> p = new List<Problema>();

            DataTable dt = objProblemaDal.selectAllProblema().Tables["cur_datos"];

            foreach (DataRow dr in dt.Rows) 
            {
                Problema pr = new Problema();
                pr.problema_id = dr["PROBLEMA_ID"].ToString();
                pr.problema_fecha = Convert.ToDateTime(dr["PROBLEMA_FECHA"]).ToShortDateString().ToString();
                pr.problema_informante = dr["PROBLEMA_INFORMANTE"].ToString();
                pr.problema_oioe = dr["PROBLEMA_OIOE"].ToString();
                pr.problema_detmejora = dr["PROBLEMA_DETMEJORA"].ToString();
                pr.problema_creadorpc = dr["PROBLEMA_CREADORPC"].ToString();
                pr.area_id = dr["AREA_NOMBRE"].ToString();
                pr.mejora_id = dr["MEJORA_NOMBRE"].ToString();
                pr.amejora_id = dr["AMEJORA_NOMBRE"].ToString();
                pr.cliente_id = dr["NOMCLIENTE"].ToString();

                p.Add(pr);
            }

            return p;
        }

        public List<Problema> getUsrProblema(String id_usr) 
        {
            objProblemaDal = new problem_dal();
            List<Problema> p = new List<Problema>();

            DataTable dt = objProblemaDal.selectUsrProblema(id_usr).Tables["cur_datos"];

            foreach (DataRow dr in dt.Rows)
            {
                Problema pr = new Problema();
                pr.problema_id = dr["PROBLEMA_ID"].ToString();
                pr.problema_fecha = Convert.ToDateTime(dr["PROBLEMA_FECHA"]).ToShortDateString().ToString();
                pr.problema_informante = dr["PROBLEMA_INFORMANTE"].ToString();
                pr.problema_oioe = dr["PROBLEMA_OIOE"].ToString();
                pr.problema_detmejora = dr["PROBLEMA_DETMEJORA"].ToString();
                pr.problema_creadorpc = dr["PROBLEMA_CREADORPC"].ToString();
                pr.area_id = dr["AREA_NOMBRE"].ToString();
                pr.mejora_id = dr["MEJORA_NOMBRE"].ToString();
                pr.amejora_id = dr["AMEJORA_NOMBRE"].ToString();
                pr.cliente_id = dr["NOMCLIENTE"].ToString();

                p.Add(pr);
            }

            return p;
        }

        public List<Problema> getAreaMejoraEstado(String idbusca, String[] idaream, String[] idestadom, String fdesde, String fhasta) 
        {
            objProblemaDal = new problem_dal();
            List<Problema> p = new List<Problema>();

            for (int i = 0; i < idaream.Count(); i++) 
            {
                for (int j = 0; j < idestadom.Count(); j++) 
                {
                    int busca_id = 0;
                    int busca_aream = 0;
                    int busca_estadom = 0;
                    String fd = "";
                    String fh = "";

                    if (String.IsNullOrEmpty(idbusca) && String.IsNullOrEmpty(idaream[i]) && String.IsNullOrEmpty(idestadom[j]) && String.IsNullOrEmpty(fdesde) && String.IsNullOrEmpty(fhasta))
                    {
                        busca_id = 0;
                        busca_aream = 0;
                        busca_estadom = 0;
                        fd = "0";
                        fh = "0";
                    }
                    else if (String.IsNullOrEmpty(idbusca) && (String.IsNullOrEmpty(idaream[i]) || String.IsNullOrEmpty(idestadom[j]) || String.IsNullOrEmpty(fdesde) || String.IsNullOrEmpty(fhasta)))
                    {
                        busca_id = 0;
                        busca_aream = 0;
                        busca_estadom = 0;
                        fd = "0";
                        fh = "0";
                    }
                    else if (!String.IsNullOrEmpty(idbusca) && (String.IsNullOrEmpty(idaream[i]) || String.IsNullOrEmpty(idestadom[j]) || String.IsNullOrEmpty(fdesde) || String.IsNullOrEmpty(fhasta)))
                    {
                        busca_id = int.Parse(idbusca);
                        busca_aream = 0;
                        busca_estadom = 0;
                        fd = "0";
                        fh = "0";
                    }
                    else if (!String.IsNullOrEmpty(idbusca) && !String.IsNullOrEmpty(idaream[i]) && !String.IsNullOrEmpty(idestadom[j]) && !String.IsNullOrEmpty(fdesde) && !String.IsNullOrEmpty(fhasta))
                    {
                        busca_id = int.Parse(idbusca);
                        busca_aream = 0;
                        busca_estadom = 0;
                        fd = "0";
                        fh = "0";
                    }
                    else if (String.IsNullOrEmpty(idbusca) && !String.IsNullOrEmpty(idaream[i]) && !String.IsNullOrEmpty(idestadom[j]) && !String.IsNullOrEmpty(fdesde) && !String.IsNullOrEmpty(fhasta))
                    {
                        busca_id = 0;
                        busca_aream = int.Parse(idaream[i]);
                        busca_estadom = int.Parse(idestadom[j]);
                        fd = fdesde;
                        fh = fhasta;
                    }

                    //int idarea = int.Parse(idaream);
                    //int idestado = int.Parse(idestadom);
                    //int numid = int.Parse(idbusca);                    

                    DataTable dt = objProblemaDal.selectAreaMejoraEstado(busca_id, busca_aream, busca_estadom, fd, fh).Tables["cur_datos"];

                    foreach (DataRow dr in dt.Rows)
                    {
                        Problema pr = new Problema();
                        pr.problema_id = dr["PROBLEMA_ID"].ToString();
                        pr.problema_fecha = Convert.ToDateTime(dr["PROBLEMA_FECHA"]).ToShortDateString().ToString();
                        pr.problema_informante = dr["PROBLEMA_INFORMANTE"].ToString();
                        pr.problema_oioe = dr["PROBLEMA_OIOE"].ToString();
                        pr.problema_detmejora = dr["PROBLEMA_DETMEJORA"].ToString();
                        pr.problema_creadorpc = dr["PROBLEMA_CREADORPC"].ToString();
                        pr.area_id = dr["AREA_NOMBRE"].ToString();
                        pr.mejora_id = dr["MEJORA_NOMBRE"].ToString();
                        pr.amejora_id = dr["AMEJORA_NOMBRE"].ToString();
                        pr.cliente_id = dr["NOMCLIENTE"].ToString();
                        pr.nom_estado = dr["NOMESTADO"].ToString();

                        p.Add(pr);
                    }
                }
            }
            return p;
        }

        public List<DetalleSeguimiento> getSeguimiento(String id_sgto) 
        {
            objProblemaDal = new problem_dal();
            List<DetalleSeguimiento> dsgto = new List<DetalleSeguimiento>();
            int sgto = int.Parse(id_sgto);            

            DataTable dt = objProblemaDal.selectSeguimiento(sgto).Tables["cur_datos"];

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DetalleSeguimiento detSgto = new DetalleSeguimiento();
                    detSgto.seguimiento_id = dr["SEGUIMIENTO_ID"].ToString();
                    detSgto.estado_id = dr["ESTADO_NOMBRE"].ToString();
                    detSgto.problema_id = dr["PROBLEMA_ID"].ToString();
                    detSgto.seguimiento_responsable = dr["SEGUIMIENTO_RESPONSABLE"].ToString();
                    detSgto.seguimiento_accion = dr["SEGUIMIENTO_ACCION"].ToString();

                    if (dr["SEGUIMIENTO_FCOMPROMISO"] == DBNull.Value)
                    {
                        detSgto.seguimiento_fcompromiso = "-";
                    }
                    else
                    {
                        detSgto.seguimiento_fcompromiso = Convert.ToDateTime(dr["SEGUIMIENTO_FCOMPROMISO"]).ToShortDateString().ToString();
                    }

                    if (dr["SEGUIMIENTO_FCIERRE"] == DBNull.Value)
                    {
                        detSgto.seguimiento_fcierre = "-";
                    }
                    else
                    {
                        detSgto.seguimiento_fcierre = Convert.ToDateTime(dr["SEGUIMIENTO_FCIERRE"]).ToShortDateString().ToString();
                    }

                    detSgto.seguimiento_observacion = dr["SEGUIMIENTO_OBSERVACION"].ToString();

                    dsgto.Add(detSgto);
                }
            }
            else
            {
                dsgto = null;
            }

            return dsgto;
        }

        public String getFComprimiso(String id_seguimiento) 
        {
            objProblemaDal = new problem_dal();
            int sgto = Int32.Parse(id_seguimiento);
            String fCompromiso = "";

            fCompromiso = Convert.ToDateTime(objProblemaDal.selectFirstDate(sgto)).ToShortDateString().ToString();

            return fCompromiso;
        }

        public void setSeguimiento(DetalleSeguimiento detsgto, String nomestado, String responsable, String NomCreado) //var responsable es el id del reponsable
        {
            objProblemaDal = new problem_dal();
            int id_estado = int.Parse(detsgto.estado_id);
            int id_problema = int.Parse(detsgto.problema_id);

            objProblemaDal.insertSeguimiento(id_estado, id_problema, detsgto.seguimiento_responsable, detsgto.seguimiento_accion, detsgto.seguimiento_fcompromiso, detsgto.seguimiento_fcierre, detsgto.seguimiento_observacion);

            enviarMailNuevoSegto(NomCreado, detsgto.problema_id, nomestado, detsgto.seguimiento_fcompromiso);
            enviarMailResponsableSgto(responsable, detsgto.problema_id, nomestado, detsgto.seguimiento_fcompromiso);
        }

        public void enviarMailProblemaIn(String estado_in, String usr) 
        {
            objProblemaDal = new problem_dal();
            mail_bal m = new mail_bal();
            String num_p = objProblemaDal.selectCurrentId();
            int idusr = Int32.Parse(usr);
            String usrnom = objProblemaDal.selectUsrCurrentId(idusr);
            m.envioMailNotificacion(num_p, estado_in, usrnom);
        }

        public void enviarMailNuevoSegto(String usrForMail, String num, String estado, String fcompromiso) 
        {
            objProblemaDal = new problem_dal();
            mail_bal m = new mail_bal();
            m.emailNuevoSeguimiento(usrForMail, num, estado, fcompromiso);
        }

        public void enviarMailResponsableSgto(String usrForMail, String num, String estado, String fcompromiso) 
        {
            objProblemaDal = new problem_dal();
            mail_bal m = new mail_bal();
            String usr = objProblemaDal.selectUsrCurrentId(int.Parse(usrForMail));
            m.emailResponsableSgto(usr, num, estado, fcompromiso);
        }

        public String getNombreLogin(String nickusr)
        {
            objProblemaDal = new problem_dal();
            return objProblemaDal.selectNombreLogin(nickusr);
        }

        public String getNumeroProblema()         
        {
            objProblemaDal = new problem_dal();
            DataTable dt = new DataTable();
            dt.Clear();
            dt = objProblemaDal.selectNumeroMejora();
            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in dt.Rows) 
            {
                sb.Append(dr["PROBLEMA_ID"].ToString() + ":");
            }

            return sb.ToString().Substring(0);
        }

        public String getMejoraArea(String idMejora) 
        {
            objProblemaDal = new problem_dal();
            String idarea = "";
            int idm = Convert.ToInt32(idMejora);

            idarea = objProblemaDal.selectMejoraArea(idm).ToString();

            return idarea;
        }

        public String[] getUsrArea(String idmejora) 
        {
            objProblemaDal = new problem_dal();
            login_dal log = new login_dal();
            String[] dato = new String[2];

            int idm = Convert.ToInt32(idmejora);
            String usr = objProblemaDal.selectNickUsrMA(idm);

            String oUsr, oAre;

            log.selectAreaUsr(usr, out oAre, out oUsr);

            dato[0] = oAre;
            dato[1] = oUsr;

            return dato;
        }
    }
}
