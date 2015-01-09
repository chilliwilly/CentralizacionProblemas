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
    public partial class problema_admin_mod : System.Web.UI.Page
    {
        problem_bal objProblemaBal;
        protected String id_problema;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //getProblemaTodo();
                txtFechaH.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            }
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
                lblTituloSgto.Text = ((Label)gvListaProblema.Rows[fIndex].FindControl("PROBLEMA_ID")).Text;
                lblTituloMejora.Text = ((Label)gvListaProblema.Rows[fIndex].FindControl("PROBLEMA_ID")).Text;

                Session["id_problema"] = ((Label)gvListaProblema.Rows[fIndex].FindControl("PROBLEMA_ID")).Text;

                gvListaProblema.Rows[fIndex].BackColor = ColorTranslator.FromHtml("#A1DCF2");

                for (int j = 0; j < gvListaProblema.Rows.Count; j++)
                {
                    if (j != fIndex)
                    {
                        gvListaProblema.Rows[j].BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                }

                cleanSeguimientoProblema();
                getSeguimientoProblema(((Label)gvListaProblema.Rows[fIndex].FindControl("PROBLEMA_ID")).Text);
                
                updTituloMejora.Update();
                updMejora.Update();
                updTituloSgto.Update();
                updDatoProblema.Update();
                updTituloTodoSgto.Update();
                updTodoSegto.Update();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            String msg = "";

            if (String.IsNullOrEmpty(cboEstado.SelectedValue)) 
            {
                msg += "Debe ingresar un estado<br>";
            }
            if (String.IsNullOrEmpty(cboArea.SelectedValue)) 
            {
                msg += "Debe ingresar un area<br>";
            }
            if (String.IsNullOrEmpty(cboResponsable.SelectedValue))
            {
                msg += "Debe ingresar un responsable<br>";
            }
            if (String.IsNullOrEmpty(txtAccion.Text))
            {
                msg += "Debe ingresar una accion<br>";
            }
            if (String.IsNullOrEmpty(txtFechaComp.Text))
            {
                msg += "Debe ingresar fecha compromiso<br>";
            }
            if (String.IsNullOrEmpty(txtObservacion.Text)) 
            {
                msg += "Debe ingresar una observacion<br>";
            }            

            if (!String.IsNullOrEmpty(msg))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", "validaInMejora('" + msg + "');", true);
            }
            else if (txtObservacion.Text.Length >= 500)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", "validaObsMejora();", true);
            }
            else
            {
                setSeguimientoProblema();
                cleanSeguimientoProblema();
                getSeguimientoProblema(Session["id_problema"].ToString());
                cleanAgregaSeguimiento();

                updDatoProblema.Update();
                updTodoSegto.Update();
            }
        }

        private void setSeguimientoProblema() 
        {
            objProblemaBal = new problem_bal();
                        
            DetalleSeguimiento detsgto = new DetalleSeguimiento();

            detsgto.estado_id = cboEstado.SelectedValue;
            detsgto.problema_id = Session["id_problema"].ToString();
            detsgto.seguimiento_responsable = cboResponsable.SelectedItem.ToString();//txtResponsable.Text;
            detsgto.seguimiento_accion = txtAccion.Text;
            detsgto.seguimiento_fcompromiso = txtFechaComp.Text;
            detsgto.seguimiento_fcierre = txtFechaCierre.Text;
            detsgto.seguimiento_observacion = txtObservacion.Text;

            objProblemaBal.setSeguimiento(detsgto, cboEstado.SelectedItem.ToString(), cboResponsable.SelectedValue, txtCreadorPc.Text);
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

        private void cleanAgregaSeguimiento()
        {
            cddEstado.SelectedValue = "0";
            cddArea.SelectedValue = "0";
            //txtResponsable.Text = "";
            txtAccion.Text = "";
            txtFechaComp.Text = "";
            txtFechaCierre.Text = "";
            txtObservacion.Text = "";
        }

        protected void gvListaProblema_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {            
            String[] ilarea;
            String[] ilestado;

            ChkListAreaEstado(out ilarea, out ilestado);

            gvListaProblema.PageIndex = e.NewPageIndex;
            bindMejoraSelect(ilarea, ilestado, txtFechaD.Text, txtFechaH.Text);
            //getProblemaTodo();
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

            foreach (var chk in objFiltro.getEstadoMejoras())
            {
                ListItem item = new ListItem();
                item.Text = chk.nomem;
                item.Value = chk.idnem;
                item.Selected = false;
                chkListEstado.Items.Add(item);
            }
        }
    }
}