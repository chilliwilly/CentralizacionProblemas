using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentralizacionProblemas
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["v_pr"] != null)
            {
                HttpCookie myCookie = new HttpCookie("v_pr");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);                
            }

            Response.AddHeader("REFRESH", "3;URL=login.aspx");
        }
    }
}