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
                HttpCookie myCookie1 = new HttpCookie("v_u");
                HttpCookie myCookie2 = new HttpCookie("v_n");
                HttpCookie myCookie3 = new HttpCookie("v_ec");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                myCookie1.Expires = DateTime.Now.AddDays(-1d);
                myCookie2.Expires = DateTime.Now.AddDays(-1d);
                myCookie3.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
                Response.Cookies.Add(myCookie1);
                Response.Cookies.Add(myCookie2);
                Response.Cookies.Add(myCookie3);
            }

            Response.AddHeader("REFRESH", "3;URL=login.aspx");
        }
    }
}