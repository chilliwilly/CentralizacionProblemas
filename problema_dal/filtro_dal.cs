using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace problema_dal
{
    public class filtro_dal
    {
        private static String conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ora_problem_cal"].ConnectionString;

        public DataTable selectAreaMejora() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();//UNION SELECT 0,'Todo' FROM DUAL
                String qry = "SELECT AMEJORA_ID, AMEJORA_NOMBRE FROM TBLMEJORA ORDER BY AMEJORA_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    //cmd.ExecuteReader();

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectEstadoMejora() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();//SELECT ESTADO_ID, ESTADO_NOMBRE FROM TBLESTADO UNION SELECT 0,'Todo' FROM DUAL ORDER BY ESTADO_ID
                String qry = "SELECT ESTADO_ID, ESTADO_NOMBRE FROM TBLESTADO WHERE ESTADO_ID <> 3";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectEstadoMejoraA() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "SELECT ESTADO_ID, ESTADO_NOMBRE FROM TBLESTADO";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }
    }
}
