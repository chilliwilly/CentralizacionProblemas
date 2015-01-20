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

        public List<Accion> getAccionSgto() 
        {
            objFiltro = new filtro_dal();
            List<Accion> ls = new List<Accion>();
            DataTable dt = objFiltro.selectAccionSgto();

            foreach (DataRow dr in dt.Rows) 
            {
                Accion a = new Accion();
                a.idnacc = dr["ACC_ID"].ToString();
                a.nomacc = dr["ACC_NOMBRE"].ToString();
                ls.Add(a);
            }
            return ls;
        }

        public Boolean setAccionSgto(String nombre) 
        {
            objFiltro = new filtro_dal();
            Boolean valida = true;
            DataTable dt = objFiltro.selectAccionSgto();

            foreach (DataRow dr in dt.Rows) 
            {
                if (dr["ACC_NOMBRE"].ToString().ToLower().Equals(nombre.ToLower())) 
                {
                    valida = false;                    
                    break;
                }
            }

            if (valida) 
            {
                objFiltro.insertAccionSgto(nombre);
            }

            return valida;
        }
    }
}
