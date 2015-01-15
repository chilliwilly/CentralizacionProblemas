<%@ Page Title="Nueva Mejora - Gestion de Mejoras" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="problema_nuevo.aspx.cs" Inherits="CentralizacionProblemas.problema_nuevo"
 EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<link rel="Stylesheet" href="../css/jquery-ui.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>--%>
    
    <style type="text/css">
        .style1
        {
            width: 103px;
        }
        .style2
        {
            width: 215px;
        }
        .style3
        {
            width: 111px;
        }
        .style4
        {
            width: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">        
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True" ScriptMode="Release" EnablePartialRendering="true" LoadScriptsBeforeUI="false">
    </asp:ToolkitScriptManager>    
        
    <h1>Ingreso Mejora</h1>
    <asp:UpdatePanel ID="upProblema" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        
            <table style="width: 100%;">
                <tr>
                    <td class="style1">Fecha</td>
                    <td class="style2">
                        <asp:TextBox ID="txtFecha" runat="server" Width="150px" style="text-align:center;"></asp:TextBox>
                        <asp:CalendarExtender ID="ceFecha" TargetControlID="txtFecha" runat="server"
                                FirstDayOfWeek="Monday" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </td>
                    <td class="style4"></td>
                    <td class="style3">OI / OE</td>
                    <td>
                        <asp:TextBox ID="txtOrden" runat="server" Width="170px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">Area Informante</td>
                    <td class="style2">
                        <asp:CascadingDropDown ID="cddAreaInformante" runat="server" TargetControlID="cboAreaInformante" LoadingText="Cargando Area..." PromptText="Seleccione Area" 
                                ServicePath="~/asmx_files/problema_llenado_cbo.asmx" ServiceMethod="getArea" 
                                Category="area_id">
                        </asp:CascadingDropDown>
                        <asp:DropDownList ID="cboAreaInformante" runat="server" Width="170px" onchange="cambiaAreaInformante();" Enabled="false">
                        </asp:DropDownList>
                    </td>
                    <td class="style4"></td>
                    <td class="style3">Cliente</td>
                    <td>
                        <asp:CascadingDropDown ID="cddCliente" runat="server" TargetControlID="cboCliente" LoadingText="Cargando Clientes..." PromptText="Seleccione Cliente" 
                                ServicePath="~/asmx_files/problema_llenado_cbo.asmx" ServiceMethod="getCliente" 
                                Category="idcliente">
                        </asp:CascadingDropDown>
                        <asp:DropDownList ID="cboCliente" runat="server" onchange="cambiaCliente();" Width="265px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style1">Informante</td>
                    <td class="style2">        
                        <asp:CascadingDropDown ID="cddInformante" runat="server" TargetControlID="cboInformante" LoadingText="Cargando Informante..." PromptText="Seleccione Informante" 
                                ServicePath="~/asmx_files/problema_llenado_cbo.asmx" ServiceMethod="getInformante" Category="user_id"><%--ParentControlID="cboAreaInformante"--%>
                        </asp:CascadingDropDown>
                        <asp:DropDownList ID="cboInformante" runat="server" Width="170px" onchange="cambiaInformante();" Enabled="false">
                        </asp:DropDownList>
                    </td>
                    <td class="style4"></td>
                    <td class="style3"></td>
                    <td>
                        
                    </td>
                </tr>
                <tr>
                    <td class="style1">Area Mejora *</td>
                    <td class="style2">
                        <asp:CascadingDropDown ID="cddAreaMejora" runat="server" TargetControlID="cboAreaMejora" LoadingText="Cargando Area Mejora..." PromptText="Seleccione Area Mejora" 
                                ServicePath="~/asmx_files/problema_llenado_cbo.asmx" ServiceMethod="getAreaMejora" 
                                Category="amejora_id">
                        </asp:CascadingDropDown>
                        <asp:DropDownList ID="cboAreaMejora" runat="server" onchange="cambiaAMejora();" Width="170px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvAreaMejora" runat="server" ErrorMessage="Debe seleccionar area mejora" Display="None" ControlToValidate="cboAreaMejora"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vceAreaMejora" runat="server" TargetControlID="rfvAreaMejora" HighlightCssClass="validatorCalloutHighlight">
                        </asp:ValidatorCalloutExtender>
                    </td>
                    <td class="style4"></td>
                    <td class="style3">Observación *</td>
                    <td>   
                        <asp:CascadingDropDown ID="cddTipoMejora" runat="server" TargetControlID="cboTipoMejora" LoadingText="Cargando Tipo Mejora..." PromptText="Seleccione Tipo Mejora" 
                                ServicePath="~/asmx_files/problema_llenado_cbo.asmx" ServiceMethod="getTipoMejora" ParentControlID="cboAreaMejora"
                                Category="mejora_id">
                        </asp:CascadingDropDown>
                        <asp:DropDownList ID="cboTipoMejora" runat="server" onchange="cambiaTipoMejora();" Width="265px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvTipoMejora" runat="server" ErrorMessage="Debe seleccionar tipo mejora <br> O bien seleccionar previamente un area mejora" Display="None" ControlToValidate="cboTipoMejora"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vceTipoMejora" runat="server" TargetControlID="rfvTipoMejora" HighlightCssClass="validatorCalloutHighlight">
                        </asp:ValidatorCalloutExtender>             
                    </td>
                </tr>
                <tr>
                    <td class="style1">Detalle Mejora *</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtDetalleMejora" runat="server" TextMode="MultiLine" Width="500px" Height="70px" MaxLength="450"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDetalleMejora" runat="server" ErrorMessage="Debe escribir algun detalle para la mejora" Display="None" ControlToValidate="txtDetalleMejora"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vceDetalleMejora" runat="server" TargetControlID="rfvDetalleMejora" HighlightCssClass="validatorCalloutHighlight">
                        </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="font-weight:bold; text-align:left;">
                        Campos con * son obligatorios
                    </td>
                </tr>
            </table>

        </ContentTemplate>
    </asp:UpdatePanel>

    <br />

    <h3>
        <asp:ImageButton ID="imgAttach" runat="server" ImageUrl="~/img_files/Attach.png" width="25px" Height="25px" Enabled="False"/>
        Adjuntar Documentos
    </h3>

    <br />

    <asp:AjaxFileUpload ID="AjaxFileUpload" runat="server" 
    ThrobberID="imgCarga" onuploadcomplete="AjaxFileUpload_UploadComplete"/>
    <asp:Image id="imgCarga" ImageUrl="~/img_files/ajax-loader.gif" Style="display:None" runat="server" />    
    
    <br />

    <!--
        INSERTAR CODIGO DE ADJUNTAR DOCUMENTO
     -->
     <asp:UpdatePanel ID="upBoton" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar Mejora" 
        onclick="btnIngresar_Click" />
        </ContentTemplate>
        </asp:UpdatePanel>

        <!-- 
            INICIO JAVASCRIPT
        -->

        <script type="text/javascript" language="javascript">
            function cambiaCliente() {
                var getidCli = document.getElementById("<%=cboCliente.ClientID %>");
                var getid = getidCli.value;
            }

            function cambiaAreaInformante() {
                var getidA = document.getElementById("<%=cboAreaInformante.ClientID %>");
                var geta = getidA.value;
            }

            function cambiaAMejora() {
                var getidAM = document.getElementById("<%=cboAreaMejora.ClientID %>");
                var getam = getidAM.value;
            }

            function cambiaTipoMejora() {
                var getidTAM = document.getElementById("<%=cboTipoMejora.ClientID %>");
                var gettam = getidTAM.value;
            }

            function cambiaInformante() {
                var getidInf = document.getElementById("<%=cboInformante.ClientID %>");
                var getInf = getidInf.value;
            }

            $(document).ready(function () {
                AjaxFileUpload_change_text();
            });

            function AjaxFileUpload_change_text() {
                Sys.Extended.UI.Resources.AjaxFileUpload_SelectFile = "Seleccione";
                Sys.Extended.UI.Resources.AjaxFileUpload_DropFiles = "Seleccione Archivos";
                Sys.Extended.UI.Resources.AjaxFileUpload_Pending = "Pendiente";
                Sys.Extended.UI.Resources.AjaxFileUpload_Remove = "Quitar";
                Sys.Extended.UI.Resources.AjaxFileUpload_Upload = "Subir";
                Sys.Extended.UI.Resources.AjaxFileUpload_FileInQueue = "{0} archivo(s) en cola.";
                Sys.Extended.UI.Resources.AjaxFileUpload_UploadedPercentage = "Completado {0} %";
                Sys.Extended.UI.Resources.AjaxFileUpload_SelectFileToUpload = "Seleccione archivo(s) para subir.";
                Sys.Extended.UI.Resources.AjaxFileUpload_AllFilesUploaded = "Se han subido los archivos.";
                Sys.Extended.UI.Resources.AjaxFileUpload_Cancel = "Cancelar";
                Sys.Extended.UI.Resources.AjaxFileUpload_Canceled = "Cancelado";
                Sys.Extended.UI.Resources.AjaxFileUpload_UploadCanceled = "Archivo Cancelado";
                Sys.Extended.UI.Resources.AjaxFileUpload_UploadingInputFile = "Subiendo Archivo: {0}.";
                Sys.Extended.UI.Resources.AjaxFileUpload_Uploaded = "Subido";
            }

            function validaLargoDetMej() {
                //$(document).ready(function () {
                $("<div id='dialog' title='Largo Texto Detalle Mejora'><p>El texto del Detalle Mejora no puede superar los 500 caracteres.</p></div>").dialog({ modal: true });
                //});
            }
        </script>
    <!-- 
        FIN JAVASCRIPT
    -->

</asp:Content>