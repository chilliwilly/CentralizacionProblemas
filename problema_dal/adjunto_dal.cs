using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace problema_dal
{
    public class adjunto_dal
    {
        private static String conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ora_problem_cal"].ConnectionString;

        public void insertAdjunto(String usr_pc, String nomdoc, String dirdoc)
        {

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "PKG_DATOS_ADJUNTO.SP_INSERT_ADJPROV";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("usr_pc", OracleDbType.Varchar2)).Value = usr_pc;// idcoti;
                    cmd.Parameters["usr_pc"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("nomdoc", OracleDbType.Varchar2)).Value = nomdoc;// idcoti;
                    cmd.Parameters["nomdoc"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("dirdoc", OracleDbType.Varchar2)).Value = dirdoc;// idcoti;
                    cmd.Parameters["dirdoc"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void deleteAdjunto(int idadj, int idmej)
        {

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "PKG_DATOS_ADJUNTO.SP_DELETE_ADJORIG";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("id_mejora", OracleDbType.Int32)).Value = idmej;// idcoti;
                    cmd.Parameters["id_mejora"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("id_adjunto", OracleDbType.Int32)).Value = idadj;// idcoti;
                    cmd.Parameters["id_adjunto"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public DataSet selectAdjunto(int id_mejora)
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "PKG_DATOS_ADJUNTO.FN_SELECT_ADJUNTO";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("cur_datos", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("id_mejora", OracleDbType.Int32)).Value = id_mejora;
                    cmd.Parameters["id_mejora"].Direction = ParameterDirection.Input;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(ds, "cur_datos");
                    }
                }
                con.Close();
            }

            return ds;

        }
    }
}
