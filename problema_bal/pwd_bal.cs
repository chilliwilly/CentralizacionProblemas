using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using problema_dal;
using problema_class;

namespace problema_bal
{
    public class pwd_bal
    {
        login_bal objLogin;
        codificar_pwd objCodPwd;
        mail_bal objMail;
        pwd_dal objPwd;
        String resetPwd = "5f4dcc3b5aa765d61d8327deb882cf99";// password

        public Boolean setPasswordReset(String usr_name)
        {
            objLogin = new login_bal();
            objPwd = new pwd_dal();
            objMail = new mail_bal();
            Usuario u;
            int usr_id;
            Boolean flag = false;

            if (objLogin.validaUsuario(usr_name))
            {
                u = objLogin.getUserLogin(usr_name);

                usr_id = int.Parse(u.user_id);

                objPwd.updatePassword(usr_id, resetPwd);

                objMail.envioMailRenueva(usr_name);

                flag = true;
            }

            return flag;
        }

        public Boolean setPasswordChange(String usr_name, String usr_old_pwd, String usr_new_pwd)
        {
            Boolean flag = false;
            objLogin = new login_bal();
            objPwd = new pwd_dal();
            objCodPwd = new codificar_pwd();
            objMail = new mail_bal();
            Usuario u;
            int usr_id;
            String new_pwd = objCodPwd.cryptoPwd(usr_new_pwd);

            if (objLogin.validaUsuario(usr_name))
            {
                if (objLogin.validaPwd(usr_name, usr_old_pwd))
                {
                    u = objLogin.getUserLogin(usr_name);

                    usr_id = int.Parse(u.user_id);

                    objPwd.updatePassword(usr_id, new_pwd);

                    objMail.envioMailCambia(usr_name);

                    flag = true;
                }
            }

            return flag;
        }
    }
}
