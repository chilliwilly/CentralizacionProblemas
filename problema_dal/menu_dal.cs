using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace problema_dal
{
    public class menu_dal
    {
        public DataSet selectMenuUser(int idFunc)
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ora_problem_cal"].ConnectionString))
            {
                con.Open();
                String qry = "FN_SELECT_MENU_USER";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("cur_menu_user", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("IDFUNC", OracleDbType.Int32)).Value = idFunc;
                    cmd.Parameters["IDFUNC"].Direction = ParameterDirection.Input;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(ds, "cur_menu_user");
                    }
                }
                con.Close();
            }

            return ds;
        }
    }
}
