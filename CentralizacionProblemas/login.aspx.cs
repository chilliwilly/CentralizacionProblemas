using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using problema_bal;
using problema_class;

namespace CentralizacionProblemas
{
    public partial class login : System.Web.UI.Page
    {
        Usuario objUser;
        login_bal objLogin;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                txtUser.Text = System.Environment.UserName;                
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            String u = txtUser.Text;
            String p = txtPwd.Text;
            String v_u, v_p, v_pr, v_n, usra, usrinf;
            Boolean vU, vP;
            DateTime dtExpire;
            objLogin = new login_bal();

            vU = objLogin.validaUsuario(u);            

            if (vU)
            {
                vP = objLogin.validaPwd(u, p);

                if (!vP)
                {
                    String notificacionUno = "alert(\"Contraseña ingresada no coincide.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUno, true);
                    Response.AddHeader("REFRESH", "0.5;URL=login.aspx");
                }
                else
                {

                    objUser = objLogin.getUserLogin(u);
                    v_u = objUser.user_nick;
                    v_pr = objUser.user_perfil;
                    v_n = objUser.user_nombre;
                    dtExpire = DateTime.Now.AddMinutes(5);

                    HttpCookie cookie_user = new HttpCookie("v_u");
                    HttpCookie cookie_perfil = new HttpCookie("v_pr");
                    HttpCookie cookie_nombre = new HttpCookie("v_n");
                    HttpCookie cookie_expira = new HttpCookie("v_ec");

                    cookie_user.Value = v_u;
                    cookie_perfil.Value = v_pr;
                    cookie_nombre.Value = v_n;
                    cookie_expira.Value = dtExpire.ToString();

                    cookie_user.Expires = DateTime.Now.AddMinutes(5);
                    cookie_perfil.Expires = DateTime.Now.AddMinutes(5);
                    cookie_nombre.Expires = DateTime.Now.AddMinutes(5);
                    cookie_expira.Expires = DateTime.Now.AddMinutes(5);

                    Response.Cookies.Add(cookie_user);
                    Response.Cookies.Add(cookie_perfil);
                    Response.Cookies.Add(cookie_nombre);
                    Response.Cookies.Add(cookie_expira);

                    Session["nom_logeado"] = txtUser.Text;

                    objLogin.getUsuarioArea(txtUser.Text, out usra, out usrinf);

                    Session["UsrArea"] = usra;
                    Session["UsrInfo"] = usrinf;

                    Response.Redirect("~/index.aspx");
                }
            }
            else 
            {
                String notificacionUno = "alert(\"Usuario ingresado no coincide.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUno, true);
                Response.AddHeader("REFRESH", "0.5;URL=login.aspx");
            }
        }
    }
}