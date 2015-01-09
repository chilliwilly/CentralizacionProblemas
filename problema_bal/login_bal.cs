using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using problema_class;
using problema_dal;
using System.Data;

namespace problema_bal
{
    public class login_bal
    {
        login_dal objLogin;
        codificar_pwd objCode;

        public Usuario getUserLogin(String inuser) 
        {
            objLogin = new login_dal();            
            Usuario user = new Usuario();

            DataTable dt = objLogin.selectUserLogin(inuser).Tables["cur_data_login"];

            foreach (DataRow dr in dt.Rows)
            {
                user.user_nick = dr["USER_NICK"].ToString();
                user.user_pwd = dr["USER_PWD"].ToString();
                user.user_perfil = dr["USER_PERFIL"].ToString();
                user.user_nombre = dr["USER_FULLNAME"].ToString();
                user.user_id = dr["USER_ID"].ToString(); 
            }

            return user;
        }

        public Boolean validaUsuario(String inuser)
        {
            Boolean flag = false;
            Usuario u = getUserLogin(inuser);

            if (!String.IsNullOrEmpty(u.user_nick))
            {
                if (u.user_nick.Equals(inuser))
                {
                    flag = true;
                }
            }

            return flag;
        }

        public Boolean validaPwd(String inuser, String inpwd) 
        {
            Boolean flag = false;
            objCode = new codificar_pwd();
            Usuario u = getUserLogin(inuser);
            String pwd = objCode.cryptoPwd(inpwd);

            if (u.user_pwd.Equals(pwd)) 
            {
                flag = true;
            }

            return flag;
        }

        public void getUsuarioArea(String usr, out String area, out String inf) 
        {
            objLogin = new login_dal();
            objLogin.selectAreaUsr(usr, out area, out inf);            
        }
    }
}
