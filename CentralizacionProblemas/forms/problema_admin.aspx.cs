using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using problema_bal;
using problema_class;
using System.Drawing;

namespace CentralizacionProblemas
{
    public partial class problema_admin : System.Web.UI.Page
    {
        problem_bal objProblemaBal;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFechaH.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            }
        }        

        private void getProblemaTodo()
        {
            objProblemaBal = new problem_bal();
            gvListaProblema.DataSource = objProblemaBal.getAllProblema();
            gvListaProblema.DataBind();
        }

        private void getSeguimientoProblema(String id_sgto)
        {
            objProblemaBal = new problem_bal();
            gvTodoSegto.DataSource = objProblemaBal.getSeguimiento(id_sgto);
            gvTodoSegto.DataBind();
        }

        private void cleanSeguimientoProblema()
        {
            gvTodoSegto.DataSource = null;
            gvTodoSegto.DataBind();
        }

        protected void gvListaProblema_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "bVer")
            {
                int fIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;

                Session["id_problema"] = "";

                txtMejora.Text = ((Label)gvListaProblema.Rows[fIndex].FindControl("PROBLEMA_DETMEJORA")).Text;
                txtCreadorPc.Text = ((Label)gvListaProblema.Rows[fIndex].FindControl("PROBLEMA_CREADORPC")).Text;
                lblObs.Text = ((Label)gvListaProblema.Rows[fIndex].FindControl("PROBLEMA_ID")).Text;
                lblTituloMejora.Text = ((Label)gvListaProblema.Rows[fIndex].FindControl("PROBLEMA_ID")).Text;

                Session["id_problema"] = ((Label)gvListaProblema.Rows[fIndex].FindControl("PROBLEMA_ID")).Text;                

                cleanSeguimientoProblema();
                getSeguimientoProblema(((Label)gvListaProblema.Rows[fIndex].FindControl("PROBLEMA_ID")).Text);

                gvListaProblema.Rows[fIndex].BackColor = ColorTranslator.FromHtml("#A1DCF2");

                for (int j = 0; j < gvListaProblema.Rows.Count; j++)
                {
                    if (j != fIndex)
                    {
                        gvListaProblema.Rows[j].BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                }             

                updTituloMejora.Update();
                updTituloTodoSgto.Update();
                updMejora.Update();
                updTodoSegto.Update();
            }
        }

        protected void gvListaProblema_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            String[] ilarea;
            String[] ilestado;
            ChkListAreaEstado(out ilarea, out ilestado);

            gvListaProblema.PageIndex = e.NewPageIndex;
            bindMejoraSelect(ilarea, ilestado, txtFechaD.Text, txtFechaH.Text);
        }

        protected void gvTodoSegto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTodoSegto.PageIndex = e.NewPageIndex;
            getSeguimientoProblema(Session["id_problema"].ToString());
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            String[] ilarea;
            String[] ilestado;
            ChkListAreaEstado(out ilarea, out ilestado);

            if (ilarea.Length <= 0 || ilestado.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", "validaChkBox();", true);
            }
            else if (String.IsNullOrEmpty(txtFechaD.Text)) 
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", "validaFechaD();", true);
            }
            else
            {
                bindMejoraSelect(ilarea, ilestado, txtFechaD.Text, txtFechaH.Text);
            }

            limpiaTodo();
        }

        private void bindMejoraSelect(String[] amejora, String[] mestado, String fechad, String fechah)
        {
            objProblemaBal = new problem_bal();
            gvListaProblema.DataSource = objProblemaBal.getAreaMejoraEstado(null, amejora, mestado, fechad, fechah).OrderByDescending(it => Convert.ToInt32(it.problema_id)).ToList();
            gvListaProblema.DataBind();
        }

        private void limpiaTodo() 
        {
            lblObs.Text = "";
            lblTituloMejora.Text = "";
            txtCreadorPc.Text = "";
            txtMejora.Text = "";            
            cleanSeguimientoProblema();
            updListaProblema.Update();
            updTituloMejora.Update();
            updMejora.Update();
            updTituloTodoSgto.Update();
            updTodoSegto.Update();
        }

        protected void chkListArea_Init(object sender, EventArgs e)
        {
            filtro_bal objFiltro = new filtro_bal();

            foreach (var chk in objFiltro.getAreaMejoras())
            {
                ListItem item = new ListItem();
                item.Text = chk.nomam;
                item.Value = chk.idnam;
                item.Selected = false;
                chkListArea.Items.Add(item);
            }
        }

        protected void chkListEstado_Init(object sender, EventArgs e)
        {
            filtro_bal objFiltro = new filtro_bal();

            foreach (var chk in objFiltro.getEstadoMejoraA())
            {
                ListItem item = new ListItem();
                item.Text = chk.nomem;
                item.Value = chk.idnem;
                item.Selected = false;
                chkListEstado.Items.Add(item);
            }
        }

        public void ChkListAreaEstado(out String[] area, out String[] estado)
        {
            int a = 0;
            int es = 0;

            foreach (ListItem li in chkListArea.Items)
            {
                if (li.Selected)
                {
                    a = a + 1;
                }
            }

            foreach (ListItem li in chkListEstado.Items)
            {
                if (li.Selected)
                {
                    es = es + 1;
                }
            }

            area = new String[a];
            estado = new String[es];
            int posa = 0;
            int pose = 0;

            foreach (ListItem li in chkListArea.Items)
            {
                if (li.Selected)
                {
                    area[posa] = li.Value;
                    posa = posa + 1;
                }
            }

            foreach (ListItem li in chkListEstado.Items)
            {
                if (li.Selected)
                {
                    estado[pose] = li.Value;
                    pose = pose + 1;
                }
            }
        }
    }
}