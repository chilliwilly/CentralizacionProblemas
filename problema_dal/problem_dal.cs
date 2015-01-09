using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace problema_dal
{
    public class problem_dal
    {
        private static String conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ora_problem_cal"].ConnectionString;

        public void insertProblema(String fecha, String informante, String oioe, String detmejora, String creador, int area, int mejora, int amejora, int cliente)
        {
            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "PKG_DATOS_PROBLEMA.SP_INSERT_PROBLEMA";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("prob_fecha", OracleDbType.Varchar2)).Value = fecha;
                    cmd.Parameters["prob_fecha"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("prob_informante", OracleDbType.Varchar2)).Value = informante;
                    cmd.Parameters["prob_informante"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("prob_oioe", OracleDbType.Varchar2)).Value = oioe;
                    cmd.Parameters["prob_oioe"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("prob_detmejora", OracleDbType.Varchar2)).Value = detmejora;
                    cmd.Parameters["prob_detmejora"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("prob_creador", OracleDbType.Varchar2)).Value = creador;
                    cmd.Parameters["prob_creador"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("prob_area", OracleDbType.Int32)).Value = area;
                    cmd.Parameters["prob_area"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("prob_mejora", OracleDbType.Int32)).Value = mejora;
                    cmd.Parameters["prob_mejora"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("prob_amejora", OracleDbType.Int32)).Value = amejora;
                    cmd.Parameters["prob_amejora"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("prob_cliente", OracleDbType.Int32)).Value = cliente;
                    cmd.Parameters["prob_cliente"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }        
        }
                
        public DataSet selectAllProblema() 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ora_problem_cal"].ConnectionString))
            {
                con.Open();
                String qry = "PKG_DATOS_PROBLEMA.FN_SELECT_ALL_PROBLEMA";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("cur_datos", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(ds, "cur_datos");
                    }
                }
                con.Close();
            }

            return ds;
        }

        public DataSet selectAreaMejoraEstado(int numbusca, int aream, int estadom, String fd, String fh) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ora_problem_cal"].ConnectionString))
            {
                con.Open();
                String qry = "PKG_DATOS_PROBLEMA.FN_SELECT_FILTRO_PROBLEMA";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("cur_datos", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("idbusca", OracleDbType.Int32)).Value = numbusca;
                    cmd.Parameters["idbusca"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("id_amejora", OracleDbType.Int32)).Value = aream;
                    cmd.Parameters["id_amejora"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("id_estado", OracleDbType.Int32)).Value = estadom;
                    cmd.Parameters["id_estado"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("fechad_mejora", OracleDbType.Varchar2)).Value = fd;
                    cmd.Parameters["fechad_mejora"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("fechah_mejora", OracleDbType.Varchar2)).Value = fh;
                    cmd.Parameters["fechah_mejora"].Direction = ParameterDirection.Input;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(ds, "cur_datos");
                    }
                }
                con.Close();
            }

            return ds;
        }

        public DataSet selectUsrProblema(String id_usr) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ora_problem_cal"].ConnectionString))
            {
                con.Open();
                String qry = "PKG_DATOS_PROBLEMA.FN_SELECT_USR_PROBLEMA";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("cur_datos", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("id_usr", OracleDbType.Varchar2)).Value = id_usr;
                    cmd.Parameters["id_usr"].Direction = ParameterDirection.Input;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(ds, "cur_datos");
                    }
                }
                con.Close();
            }

            return ds;
        }

        public DataSet selectSeguimiento(int id_problema) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "PKG_DATOS_PROBLEMA.FN_SELECT_SEGUIMIENTO";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("cur_datos", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("id_problema", OracleDbType.Int32)).Value = id_problema;
                    cmd.Parameters["id_problema"].Direction = ParameterDirection.Input;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(ds, "cur_datos");
                    }
                }
                con.Close();
            }

            return ds;
        }

        public String selectFirstDate(int id_problema) 
        {
            String rFcompromiso = "";

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT PKG_DATOS_PROBLEMA.FN_SELECT_MIN_FSGTO(:id_problema) AS FC FROM DUAL";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new OracleParameter("id_problema", OracleDbType.Int32)).Value = id_problema;
                    cmd.Parameters["id_problema"].Direction = ParameterDirection.Input;

                    using (OracleDataReader odr = cmd.ExecuteReader()) 
                    {
                        while (odr.Read())
                        {
                            rFcompromiso = odr["FC"].ToString();
                        } 
                    }
                                       
                }
                con.Close();
            }

            return rFcompromiso;
        }

        public String selectCurrentId() 
        {
            String id_retorno = "";

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT PKG_DATOS_PROBLEMA.FN_SELECT_ID_MAIL AS ID_R FROM DUAL";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataReader odr = cmd.ExecuteReader())
                    {
                        while (odr.Read())
                        {
                            id_retorno = odr["ID_R"].ToString();
                        }
                    }

                }
                con.Close();
            }

            return id_retorno;
        }

        public String selectUsrCurrentId(int usr_id) 
        {
            String usr_nom = "";

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT PKG_DATOS_PROBLEMA.FN_SELECT_MAIL(:id_usr) AS MAIL_R FROM DUAL";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new OracleParameter("id_usr", OracleDbType.Int32)).Value = usr_id;
                    cmd.Parameters["id_usr"].Direction = ParameterDirection.Input;

                    using (OracleDataReader odr = cmd.ExecuteReader())
                    {
                        while (odr.Read())
                        {
                            usr_nom = odr["MAIL_R"].ToString();
                        }
                    }

                }
                con.Close();
            }

            return usr_nom;
        }

        public void insertSeguimiento(int ds_estado_id, int ds_problema_id, String ds_sgto_responsable, String ds_sgto_accion, String ds_sgto_fcompromiso, String ds_sgto_fcierre, String ds_sgto_obs) 
        {
            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "PKG_DATOS_PROBLEMA.SP_INSERT_SEGUIMIENTO";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("ds_estado_id", OracleDbType.Int32)).Value = ds_estado_id;
                    cmd.Parameters["ds_estado_id"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("ds_problema_id", OracleDbType.Int32)).Value = ds_problema_id;
                    cmd.Parameters["ds_problema_id"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("ds_sgto_responsable", OracleDbType.Varchar2)).Value = ds_sgto_responsable;
                    cmd.Parameters["ds_sgto_responsable"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("ds_sgto_accion", OracleDbType.Varchar2)).Value = ds_sgto_accion;
                    cmd.Parameters["ds_sgto_accion"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("ds_sgto_fcompromiso", OracleDbType.Varchar2)).Value = ds_sgto_fcompromiso;
                    cmd.Parameters["ds_sgto_fcompromiso"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("ds_sgto_fcierre", OracleDbType.Varchar2)).Value = ds_sgto_fcierre;
                    cmd.Parameters["ds_sgto_fcierre"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("ds_sgto_obs", OracleDbType.Varchar2)).Value = ds_sgto_obs;
                    cmd.Parameters["ds_sgto_obs"].Direction = ParameterDirection.Input;   

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            } 
        }

        public String selectNombreLogin(String nickusr) 
        {
            String usr_nom = "";

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT PKG_DATOS_PROBLEMA.FN_SELECT_FULL_NAME(:usrnick) AS FULL_NAME FROM DUAL";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new OracleParameter("usrnick", OracleDbType.Varchar2)).Value = nickusr;
                    cmd.Parameters["usrnick"].Direction = ParameterDirection.Input;

                    using (OracleDataReader odr = cmd.ExecuteReader())
                    {
                        while (odr.Read())
                        {
                            usr_nom = odr["FULL_NAME"].ToString();
                        }
                    }

                }
                con.Close();
            }

            return usr_nom;
        }

        public DataTable selectNumeroMejora() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "SELECT PROBLEMA_ID FROM TBLPROBLEMA ORDER BY PROBLEMA_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    oda.Fill(dt);
                }
                con.Close();
            }
            return dt;
        }

        public int selectMejoraArea(int nroMejora) 
        {
            int nro = 0;

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "SELECT AMEJORA_ID FROM TBLPROBLEMA WHERE PROBLEMA_ID = :nroMejora";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new OracleParameter("nroMejora", OracleDbType.Int32)).Value = nroMejora;
                    cmd.Parameters["nroMejora"].Direction = ParameterDirection.Input;

                    using (OracleDataReader odr = cmd.ExecuteReader()) 
                    {
                        while (odr.Read()) 
                        {
                            nro = Convert.ToInt32(odr["AMEJORA_ID"].ToString());
                        }
                    }
                }
                con.Close();
            }
            return nro;
        }

        public String selectNickUsrMA(int idMejora) 
        {
            String nick = "";

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "SELECT USER_NICK FROM TBLUSUARIO WHERE USER_NOMBRE||' '||USER_PATERNO " +
                             "= (SELECT SEGUIMIENTO_RESPONSABLE FROM TBLDETALLESEGUIMIENTO WHERE SEGUIMIENTO_ID " +
                             "= (SELECT MAX(SEGUIMIENTO_ID) FROM TBLDETALLESEGUIMIENTO WHERE PROBLEMA_ID = :idMejora) AND PROBLEMA_ID = :idMejora)";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new OracleParameter("idMejora", OracleDbType.Int32)).Value = idMejora;
                    cmd.Parameters["idMejora"].Direction = ParameterDirection.Input;

                    using (OracleDataReader odr = cmd.ExecuteReader()) 
                    {
                        while (odr.Read())
                        {
                            nick = odr["USER_NICK"].ToString();
                        }
                    }
                }
                con.Close();
            }
            return nick;
        }
    }
}