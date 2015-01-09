using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using AjaxControlToolkit;
using System.Security.Principal;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

//namespace CentralizacionProblemas
//{
    /// <summary>
    /// Descripción breve de problema_llenado_cbo
    /// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//[System.ComponentModel.ToolboxItem(false)]
// Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
[System.Web.Script.Services.ScriptService]
public class problema_llenado_cbo : System.Web.Services.WebService
{

    private static string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ora_problem_cal"].ConnectionString;

    public problema_llenado_cbo()
    {

    }

    [WebMethod]
    public CascadingDropDownNameValue[] getCliente(string knownCategoryValues)
    {
        string qryCliente = "SELECT IDCLIENTE, NOMCLIENTE FROM TBLCLIENTE ORDER BY NOMCLIENTE";
        List<CascadingDropDownNameValue> cli = getData(qryCliente);
        return cli.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] getArea(string knownCategoryValues) 
    {
        string qryArea = "SELECT AREA_ID, AREA_NOMBRE FROM TBLAREA ORDER BY AREA_ID";
        List<CascadingDropDownNameValue> area = getData(qryArea);
        return area.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] getAreaMejora(string knownCategoryValues)
    {
        string qryAream = "SELECT AMEJORA_ID, AMEJORA_NOMBRE FROM TBLMEJORA ORDER BY AMEJORA_ID";
        List<CascadingDropDownNameValue> aream = getData(qryAream);
        return aream.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] getTipoMejora(string knownCategoryValues)
    {
        string area = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)["AMEJORA_ID"];
        string qryTAream = string.Format("SELECT MEJORA_ID, MEJORA_NOMBRE FROM TBLTIPOMEJORA WHERE AMEJORA_ID = {0} ORDER BY MEJORA_ID", area);
        List<CascadingDropDownNameValue> Taream = getData(qryTAream);
        return Taream.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] getInformante(string knownCategoryValues) 
    {
        //string areausr = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)["AREA_ID"];
        string qryInfr = string.Format("SELECT USER_ID, USER_NOMBRE ||' '|| USER_PATERNO USER_NOM FROM TBLUSUARIO");// JOIN TBLUSUARIOAREA USING (USER_ID) WHERE AREA_ID = {0} ORDER BY USER_ID", areausr);
        List<CascadingDropDownNameValue> info = getData(qryInfr);
        return info.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] getResponsable(string knownCategoryValues)
    {
        string areausr = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)["AREA_ID"];
        string qryInfr = string.Format("SELECT USER_ID, USER_NOMBRE ||' '|| USER_PATERNO USER_NOM FROM TBLUSUARIO JOIN TBLUSUARIOAREA USING (USER_ID) WHERE AREA_ID = {0} ORDER BY USER_ID", areausr);
        List<CascadingDropDownNameValue> info = getData(qryInfr);
        return info.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] getEstado(string knownCategoryValues) 
    {
        string qryEstd = "SELECT ESTADO_ID, ESTADO_NOMBRE FROM TBLESTADO ORDER BY ESTADO_ID";
        List<CascadingDropDownNameValue> estd = getData(qryEstd);
        return estd.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] getEstadoFiltro(string knownCategoryValues)
    {
        string qryEstd = "SELECT ESTADO_ID, ESTADO_NOMBRE FROM TBLESTADO UNION SELECT 0,'Todo' FROM DUAL ORDER BY ESTADO_ID";
        List<CascadingDropDownNameValue> estd = getData(qryEstd);
        return estd.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] getEstadoSinCerrar(string knownCategoryValues) 
    {
        string qryEstdC = "SELECT ESTADO_ID, ESTADO_NOMBRE FROM TBLESTADO WHERE ESTADO_ID <> 3";
        List<CascadingDropDownNameValue> estdc = getData(qryEstdC);
        return estdc.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] getAreaMejoraFiltro(string knownCategoryValues)
    {
        string qryAream = "SELECT AMEJORA_ID, AMEJORA_NOMBRE FROM TBLMEJORA UNION SELECT 0,'Todo' FROM DUAL ORDER BY AMEJORA_ID";
        List<CascadingDropDownNameValue> aream = getData(qryAream);
        return aream.ToArray();
    }

    [WebMethod]
    public String getNumeroMejora()
    {
        problema_bal.problem_bal objProblema = new problema_bal.problem_bal();

        return objProblema.getNumeroProblema();
    }

    private List<CascadingDropDownNameValue> getData(string  qry_in)
    {        
        //OracleCommand cmdgd = new OracleCommand(qry_in);
        List<CascadingDropDownNameValue> valor = new List<CascadingDropDownNameValue>();

        using (OracleConnection conOr = new OracleConnection(conStr))
        {
            conOr.Open();
            //cmdgd.Connection = conOr;
            using (OracleCommand cmdgd = new OracleCommand(qry_in, conOr))
            {
                using (OracleDataReader readOr = cmdgd.ExecuteReader())
                {
                    while (readOr.Read())
                    {
                        valor.Add(new CascadingDropDownNameValue
                        {
                            value = readOr[0].ToString(),
                            name = readOr[1].ToString()
                        });
                    }
                    readOr.Close();
                    conOr.Close();
                    return valor;
                }
            }
        }       
    }

    private List<CascadingDropDownNameValue> getUnique(string qry_in)
    {       
        //OracleCommand cmdCoti = new OracleCommand(qry_in);
        List<CascadingDropDownNameValue> valores = new List<CascadingDropDownNameValue>();

        using (OracleConnection conCoti = new OracleConnection(conStr))
        {
            conCoti.Open();
            //cmdCoti.Connection = conCoti;
            using (OracleCommand cmdCoti = new OracleCommand(qry_in, conCoti))
            {
                using (OracleDataReader readCoti = cmdCoti.ExecuteReader())
                {
                    while (readCoti.Read())
                    {
                        valores.Add(new CascadingDropDownNameValue
                        {
                            value = readCoti[0].ToString(),
                            name = readCoti[0].ToString()
                        });
                    }
                    readCoti.Close();
                    conCoti.Close();
                    return valores;
                }
            }
        }
    }

}
//}