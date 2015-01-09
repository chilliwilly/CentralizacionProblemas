using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using problema_dal;
using problema_class;
using System.Data;

namespace problema_bal
{
    public class menu_bal
    {
        menu_dal objMenu;

        public List<MenuUsuario> getMenuUser(String idFunc) 
        {
            objMenu = new menu_dal();
            int id_Func = Convert.ToInt32(idFunc);
            DataTable dt = objMenu.selectMenuUser(id_Func).Tables["cur_menu_user"];
            List<MenuUsuario> m = new List<MenuUsuario>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToInt32(dr[0]) == Convert.ToInt32(dr[2])) 
                    {
                        MenuUsuario menu = new MenuUsuario();
                        menu.menu_nom = dr[1].ToString();
                        menu.menu_id = dr[0].ToString();
                        menu.menu_grupo = String.Empty;
                        menu.menu_link = dr[3].ToString();

                        m.Add(menu);
                    }
                }
            }
            return m;
        }

        public List<MenuUsuario> getSubMenuUser(String idFunc) 
        {
            objMenu = new menu_dal();
            int id_Func = Convert.ToInt32(idFunc);
            DataTable dt = objMenu.selectMenuUser(id_Func).Tables["cur_menu_user"];
            List<MenuUsuario> m = new List<MenuUsuario>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MenuUsuario menu = new MenuUsuario();
                    menu.menu_nom = dr[1].ToString();
                    menu.menu_id = dr[0].ToString();
                    menu.menu_grupo = dr[2].ToString();
                    menu.menu_link = dr[3].ToString();

                    m.Add(menu);
                }
            }
            return m;
        }
    }
}
