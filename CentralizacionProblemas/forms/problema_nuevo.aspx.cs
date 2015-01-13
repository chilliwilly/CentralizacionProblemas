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
    public partial class problema_nuevo : System.Web.UI.Page
    {
        problem_bal objProblemaBal;
        adjunto_bal objAdjunto;
        String msg = "";
        String pc_usr = System.Environment.UserName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                this.txtFecha.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                cddAreaInformante.SelectedValue = Session["UsrArea"].ToString();
                cddInformante.SelectedValue = Session["UsrInfo"].ToString();
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            //if (validaIngresoDato())
            //{
            //    String nu = @"<script type='text/javascript'> alert('" + msg + "'); </script>";
            //    ScriptManager.RegisterStartupScript(this, GetType(), "Faltan Campos", nu, false);
            //}
            //else 
            //{
                set_Problema();
            //}
        }

        private void set_Problema() 
        {
            //objProblemaBal = new problem_bal();
            //String f = txtFecha.Text;
            
            //Problema pr = new Problema();
            //pr.problema_fecha = f;
            //pr.problema_informante = cboInformante.SelectedItem.ToString();
            //pr.problema_oioe = txtOrden.Text;
            //pr.problema_detmejora = txtDetalleMejora.Text;
            //pr.problema_creadorpc = pc_usr;
            //pr.area_id = cboAreaInformante.SelectedValue;
            //pr.mejora_id = cboTipoMejora.SelectedValue;
            //pr.amejora_id = cboAreaMejora.SelectedValue;

            //if (cboCliente.SelectedValue.Equals(""))
            //{
            //    pr.cliente_id = null;
            //}
            //else
            //{
            //    pr.cliente_id = cboCliente.SelectedValue;
            //}

            //String idusr = cboInformante.SelectedValue;

            //if (!objProblemaBal.validaFecha(f))
            //{
            //    cddAreaMejora.SelectedValue = "0";
            //    String nd = "alert(\"Fecha Invalida.\");";
            //    ScriptManager.RegisterStartupScript(this, GetType(), "Error Mensaje", nd, true);
            //}
            //else 
            //{
            //    objProblemaBal.setProblema(pr);                
            //    objProblemaBal.enviarMailProblemaIn("Creado", idusr);
            //    String pathPage = "window.location='" + Request.ApplicationPath + "forms/load.aspx'";
            //    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", pathPage, true);
            //}
            if (txtDetalleMejora.Text.Length >= 500) 
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", "validaLargoDetMej();", true);
            }
        }

        protected void AjaxFileUpload_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            objAdjunto = new adjunto_bal();
            String adjunto = "";

            adjunto = objAdjunto.adjuntarDocumento(e.FileName, pc_usr);
            AjaxFileUpload.SaveAs(Server.MapPath("~/adjunto_doc/") + adjunto);

            //bindDetalleAdj();
            //upAdjunto.Update();
        }

        private Boolean validaIngresoDato() 
        {
            Boolean valida = false;

            if (cboAreaMejora.SelectedValue.Equals("")) 
            {
                valida = true;
                msg += "Debe Seleccionar un Area de Mejora\\n";
            }
            if (cboTipoMejora.SelectedValue.Equals("") && !cboAreaMejora.SelectedValue.Equals("")) 
            {
                valida = true;
                msg += "Debe Seleccionar un Tipo de Mejora para el Area de Mejora\\n";
            }
            if (txtDetalleMejora.Text.Trim().Equals("")) 
            {
                valida = true;
                msg += "Debe ingresar un detalle para la mejora";
            }

            return valida;
        }
    }
}