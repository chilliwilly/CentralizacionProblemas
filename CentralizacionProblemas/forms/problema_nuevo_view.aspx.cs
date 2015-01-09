using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using problema_bal;
using problema_class;
using System.IO;
using System.Drawing;

namespace CentralizacionProblemas.forms
{
    public partial class problema_nuevo_view : System.Web.UI.Page
    {
        problem_bal objProblemaBal;
        adjunto_bal objAdjunto;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvListaMejora_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            String[] am = new String[] { cboAreaMejora.SelectedValue };
            String[] em = new String[] { cboEstado.SelectedValue };

            gvListaMejora.PageIndex = e.NewPageIndex;
            bindMejoraSelect(Request.Form["txtNumero"].ToString(), am, em, txtFechaD.Text, txtFechaH.Text);
        }

        private void bindMejoraSelect(String num, String[] amejora, String[] mestado, String fechad, String fechah) 
        {
            objProblemaBal = new problem_bal();
            gvListaMejora.DataSource = objProblemaBal.getAreaMejoraEstado(num, amejora, mestado, fechad, fechah);
            gvListaMejora.DataBind();
        }

        private void bindSeguimientoProblema(String id_sgto)
        {
            objProblemaBal = new problem_bal();
            gvTodoSegto.DataSource = objProblemaBal.getSeguimiento(id_sgto);
            gvTodoSegto.DataBind();
        }

        private void bindEmptySeguimientoProblema() 
        {
            gvTodoSegto.DataSource = null;
            gvTodoSegto.DataBind();
        }

        private void bindEmptyAdjunto() 
        {
            gvFileUpload.DataSource = null;
            gvFileUpload.DataBind();
        }

        protected void gvListaMejora_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "bVer")
            {
                int fIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;

                txtMejora.Text = ((Label)gvListaMejora.Rows[fIndex].FindControl("PROBLEMA_DETMEJORA")).Text;
                lblObs.Text = ((Label)gvListaMejora.Rows[fIndex].FindControl("PROBLEMA_ID")).Text;
                lblTituloMejora.Text = ((Label)gvListaMejora.Rows[fIndex].FindControl("PROBLEMA_ID")).Text;

                bindDetalleAdj(lblTituloMejora.Text);
                bindSeguimientoProblema(lblTituloMejora.Text);

                gvListaMejora.Rows[fIndex].BackColor = ColorTranslator.FromHtml("#A1DCF2");

                for (int j = 0; j < gvListaMejora.Rows.Count; j++)
                {
                    if (j != fIndex)
                    {
                        gvListaMejora.Rows[j].BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                }

                upAdjunto.Update();
                updDetalleMejora.Update();
                updSeguimiento.Update();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            String[] am = new String[] { cboAreaMejora.SelectedValue };
            String[] em = new String[] { cboEstado.SelectedValue };

            bindMejoraSelect(Request.Form["txtNumero"].ToString(), am, em, txtFechaD.Text, txtFechaH.Text);
            limpiaTodo();
        }

        protected void gvTodoSegto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTodoSegto.PageIndex = e.NewPageIndex;
            bindSeguimientoProblema(lblObs.Text);
        }

        private void limpiaTodo() 
        {
            lblObs.Text = "";
            lblTituloMejora.Text = "";
            txtMejora.Text = "";
            bindEmptySeguimientoProblema();
            bindEmptyAdjunto();
            upAdjunto.Update();
            updMejora.Update();
            updDetalleMejora.Update();
            updSeguimiento.Update();
        }

        protected void gvFileUpload_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFileUpload.PageIndex = e.NewPageIndex;
            bindDetalleAdj(lblTituloMejora.Text);
        }

        protected void gvFileUpload_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            objAdjunto = new adjunto_bal();

            if (e.CommandName == "fDelete")
            {
                int fIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;

                String nroItem = ((Label)gvFileUpload.Rows[fIndex].FindControl("IdAdjunto")).Text;
                String dirArch = ((Label)gvFileUpload.Rows[fIndex].FindControl("DirAdjunto")).Text;

                objAdjunto.deleteAdjunto(nroItem, lblTituloMejora.Text);

                System.IO.File.Delete(Server.MapPath(dirArch));

                bindDetalleAdj(lblTituloMejora.Text);
            }
        }

        private void bindDetalleAdj(String in_idmejora)
        {
            objAdjunto = new adjunto_bal();
            gvFileUpload.DataSource = objAdjunto.getAdjunto(in_idmejora);
            gvFileUpload.DataBind();
        }
    }
}