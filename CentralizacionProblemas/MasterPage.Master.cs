using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using problema_bal;
using problema_class;
using System.Web.Services;

namespace CentralizacionProblemas
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        String columna = "";
        menu_bal objMenu;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["v_pr"] != null)
            {
                if (Request.Cookies["v_pr"].Value.Equals("1"))
                {
                    columna = "MENU_FUNCMAIN";
                }

                if (Request.Cookies["v_pr"].Value.Equals("2"))
                {
                    columna = "MENU_FUNCSEC";
                }

                if (!String.IsNullOrEmpty(columna))
                {
                    //ejecutar llenado menu
                    BindMenuControl(columna);
                }
                else
                {                    
                    Response.Redirect("~/login.aspx");
                }
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "", "venceCookie();", true);
                Response.Redirect("~/login.aspx");
            }

            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        protected void BindMenuControl(String colPrivilegio) 
        {
            objMenu = new menu_bal();
            String reqCookie = Request.Cookies["v_pr"].Value.ToString();

            foreach (MenuUsuario m in objMenu.getMenuUser(reqCookie))
            {
                MenuItem mItem = new MenuItem(m.menu_nom, m.menu_id, m.menu_grupo, m.menu_link);
                NavigationMenu.Items.Add(mItem);                                
                AddChildItem(ref mItem, reqCookie);
            }            
        }

        protected void AddChildItem(ref MenuItem mItem, String idFuncion)
        {
            objMenu = new menu_bal();
            foreach (MenuUsuario m in objMenu.getSubMenuUser(idFuncion))
            {
                if (Convert.ToInt32(m.menu_grupo) == Convert.ToInt32(mItem.Value) && Convert.ToInt32(m.menu_id) != Convert.ToInt32(m.menu_grupo))
                {
                    MenuItem miSubItem = new MenuItem(m.menu_nom, m.menu_id, String.Empty, m.menu_link);
                    mItem.ChildItems.Add(miSubItem);
                    AddChildItem(ref miSubItem, idFuncion);
                }
            }
        }        
    }
}