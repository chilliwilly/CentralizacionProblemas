using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using problema_class;
using problema_dal;
using System.Data;

namespace problema_bal
{
    public class filtro_bal
    {
        filtro_dal objFiltro;

        public List<AreaMejora> getAreaMejoras() 
        {
            objFiltro = new filtro_dal();
            List<AreaMejora> ls = new List<AreaMejora>();
            DataTable dt = objFiltro.selectAreaMejora();

            foreach (DataRow dr in dt.Rows) 
            {
                AreaMejora am = new AreaMejora();
                am.idnam = dr["AMEJORA_ID"].ToString();
                am.nomam = dr["AMEJORA_NOMBRE"].ToString();
                ls.Add(am);
            }
            return ls;
        }

        public List<EstadoMejora> getEstadoMejoras() 
        {
            objFiltro = new filtro_dal();
            List<EstadoMejora> ls = new List<EstadoMejora>();
            DataTable dt = objFiltro.selectEstadoMejora();

            foreach (DataRow dr in dt.Rows) 
            {
                EstadoMejora em = new EstadoMejora();
                em.idnem = dr["ESTADO_ID"].ToString();
                em.nomem = dr["ESTADO_NOMBRE"].ToString();
                ls.Add(em);
            }
            return ls;
        }

        public List<EstadoMejora> getEstadoMejoraA() 
        {
            objFiltro = new filtro_dal();
            List<EstadoMejora> ls = new List<EstadoMejora>();
            DataTable dt = objFiltro.selectEstadoMejoraA();

            foreach (DataRow dr in dt.Rows) 
            {
                EstadoMejora em = new EstadoMejora();
                em.idnem = dr["ESTADO_ID"].ToString();
                em.nomem = dr["ESTADO_NOMBRE"].ToString();
                ls.Add(em);
            }
            return ls;
        }
    }
}
