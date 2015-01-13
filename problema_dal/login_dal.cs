using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace problema_dal
{
    public class login_dal
    {
        public DataSet selectUserLogin(String inuser) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ora_problem_cal"].ConnectionString))
            {
                con.Open();                
                String qry = "FN_SELECT_LOGIN_DATA";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("cur_data_login", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("vusuario", OracleDbType.Varchar2)).Value = inuser;
                    cmd.Parameters["vusuario"].Direction = ParameterDirection.Input;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(ds, "cur_data_login");
                    }
                }
                con.Close();
            }

            return ds;
        }

        public void selectAreaUsr(String usrlog, out String area, out String usr) 
        {
            using (OracleConnection con = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ora_problem_cal"].ConnectionString))
            {
                con.Open();
                String qry = "PKG_DATOS_PROBLEMA.SP_SELECT_AREAUSR_LOGIN";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("usrlog", OracleDbType.Varchar2)).Value = usrlog;
                    cmd.Parameters["usrlog"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("areainf_id", OracleDbType.Int32)).Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(new OracleParameter("inf_id", OracleDbType.Int32)).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    area = cmd.Parameters["areainf_id"].Value.ToString();
                    usr = cmd.Parameters["inf_id"].Value.ToString();                    
                }
                con.Close();
            }
        }
    }
}
