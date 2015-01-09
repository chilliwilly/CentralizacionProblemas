using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using problema_bal;

namespace CentralizacionProblemas
{
    public partial class pwd_cambiar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            pwd_bal objPwd = new pwd_bal();

            if (!(txtPwdNew.Text.Equals(txtPwdNewR.Text)))
            {
                String notificacionUno = "alert(\"Contraseñas nuevas no coinciden.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUno, true);
            }
            else
            {
                if (!objPwd.setPasswordChange(txtUser.Text, txtPwd.Text, txtPwdNew.Text))
                {
                    String notificacionUno = "alert(\"Contraseña ingresada no coincide.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUno, true);
                }
                else
                {
                    Response.AddHeader("REFRESH", "0.5;URL=/forms_load/load_pwd_cambiar.aspx");
                }
            }
        }
    }
}