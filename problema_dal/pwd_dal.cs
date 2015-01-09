using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace problema_dal
{
    public class pwd_dal
    {
        public void updatePassword(int id_usr, String new_pwd) 
        {
            using (OracleConnection con = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ora_problem_cal"].ConnectionString))
            {
                con.Open();
                String qry = "SP_REEMPLAZAR_PWD";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("id_usuario", OracleDbType.Int32)).Value = id_usr;
                    cmd.Parameters["id_usuario"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("pwd_usuario", OracleDbType.Varchar2)).Value = new_pwd;
                    cmd.Parameters["pwd_usuario"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }        
        }
    }
}
