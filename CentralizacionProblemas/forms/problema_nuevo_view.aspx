<%@ Page Title="Ver Mejoras - Gestion de Mejoras" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="problema_nuevo_view.aspx.cs" Inherits="CentralizacionProblemas.forms.problema_nuevo_view" 
    EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Stylesheet" href="../css/jquery-ui.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>

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
        
    <h1>Busqueda Mejora</h1>
    <asp:Panel ID="panMejoraBuscar" runat="server">
    <asp:UpdatePanel ID="upMejoraBuscar" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>                
                <tr>
                    <td>Nro Buscar &nbsp;</td>
                    <td>                        
                        <input type="text" name="txtNumero" id="txtNumero" style="width:80px;"/>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>Area Mejora &nbsp;</td>
                    <td>
                        <asp:CascadingDropDown ID="cddAreaInformante" runat="server" TargetControlID="cboAreaMejora" LoadingText="Cargando Area..." PromptText="Seleccione Area" 
                                ServicePath="~/asmx_files/problema_llenado_cbo.asmx" ServiceMethod="getAreaMejoraFiltro" 
                                Category="amejora_id">
                        </asp:CascadingDropDown>
                        <asp:DropDownList ID="cboAreaMejora" runat="server" Width="170px" onchange="cambiaAreaInformante();">
                        </asp:DropDownList>
                        <%--<asp:RequiredFieldValidator ID="rfvAreaMejora" runat="server" ErrorMessage="Debe seleccionar area mejora" Display="None" ControlToValidate="cboAreaMejora"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vceAreaMejora" runat="server" TargetControlID="rfvAreaMejora" HighlightCssClass="validatorCalloutHighlight">
                        </asp:ValidatorCalloutExtender>--%>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>Estado Mejora &nbsp;</td>
                    <td>
                        <asp:CascadingDropDown ID="cddInformante" runat="server" TargetControlID="cboEstado" LoadingText="Cargando Estados..." PromptText="Seleccione Estados" 
                                ServicePath="~/asmx_files/problema_llenado_cbo.asmx" ServiceMethod="getEstadoFiltro" Category="estado_id">
                        </asp:CascadingDropDown>
                        <asp:DropDownList ID="cboEstado" runat="server" Width="170px" onchange="cambiaInformante();">
                        </asp:DropDownList>
                        <%--<asp:RequiredFieldValidator ID="rfvEstado" runat="server" ErrorMessage="Debe seleccionar une estado" Display="None" ControlToValidate="cboEstado"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vceEstado" runat="server" TargetControlID="rfvEstado" HighlightCssClass="validatorCalloutHighlight">
                        </asp:ValidatorCalloutExtender>--%>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>Fecha Creacion Desde &nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtFechaD" runat="server" Width="120px" style="text-align:center;"></asp:TextBox>
                        <asp:CalendarExtender ID="ceFechaD" TargetControlID="txtFechaD" runat="server"
                                FirstDayOfWeek="Monday" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                        <%--<asp:RequiredFieldValidator ID="rfvFechaD" runat="server" ErrorMessage="Debe seleccionar una fecha" Display="None" ControlToValidate="txtFechaD"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vceFechaD" runat="server" TargetControlID="rfvFechaD" HighlightCssClass="validatorCalloutHighlight">
                        </asp:ValidatorCalloutExtender>--%>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>Fecha Creacion Hasta &nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtFechaH" runat="server" Width="120px" style="text-align:center;"></asp:TextBox>
                        <asp:CalendarExtender ID="ceFechaH" TargetControlID="txtFechaH" runat="server"
                                FirstDayOfWeek="Monday" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                        <%--<asp:RequiredFieldValidator ID="rfvFechaH" runat="server" ErrorMessage="Debe seleccionar una fecha" Display="None" ControlToValidate="txtFechaH"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vceFechaH" runat="server" TargetControlID="rfvFechaH" HighlightCssClass="validatorCalloutHighlight">
                        </asp:ValidatorCalloutExtender>--%>
                    </td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                            onclick="btnBuscar_Click" />
                    </td>
                </table>
                <table width="100%">
                    <tr>
                        <td style="font-weight:bold; text-align:center;">SOLO PUEDE BUSCAR POR NUMERO DE MEJORA O POR LOS FILTROS QUE APARECEN ARRIBA PERO NO POR AMBOS</td>
                    </tr>
                </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Panel>
    
    <br />

    <h3>Mejoras Ingresadas</h3>
    <asp:Panel ID="panMejora" runat="server" Height="300px">
    <asp:UpdatePanel ID="updMejora" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            
            <asp:GridView ID="gvListaMejora" runat="server" AllowPaging="true" 
                AutoGenerateColumns="false" PageSize="5" 
                PagerSettings-PageButtonCount="3" PagerSettings-Mode="NumericFirstLast" 
                PagerSettings-FirstPageText="Primera" PagerSettings-LastPageText="Ultima" 
                onrowcommand="gvListaMejora_RowCommand" 
                onpageindexchanging="gvListaMejora_PageIndexChanging">
                <EmptyDataTemplate>    
                    <center>                    
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img_files/data_backup.png" Width="150px" Height="150px"/>
                        <br />
                        <h1>NO HAY MEJORAS INGRESADAS POR EL USUARIO</h1>
                    </center>
                </EmptyDataTemplate>
                <Columns>

                    <asp:TemplateField HeaderText="Item" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="PROBLEMA_ID" runat="server" Text='<%# Bind("PROBLEMA_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="PROBLEMA_FECHA" runat="server" Text='<%# Bind("PROBLEMA_FECHA") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Area Informante" ItemStyle-Width="150px">
                        <ItemTemplate>
                            <asp:Label ID="AREA_ID" runat="server" Text='<%# Bind("AREA_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--<asp:TemplateField HeaderText="Informante" ItemStyle-Width="120px">
                        <ItemTemplate>
                            <asp:Label ID="PROBLEMA_INFORMANTE" runat="server" Text='<%# Bind("PROBLEMA_INFORMANTE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Area Mejora" ItemStyle-Width="120px">
                        <ItemTemplate>
                            <asp:Label ID="AMEJORA_ID" runat="server" Text='<%# Bind("AMEJORA_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="OI / OE" ItemStyle-Width="120px">
                        <ItemTemplate>
                            <asp:Label ID="PROBLEMA_OIOE" runat="server" Text='<%# Bind("PROBLEMA_OIOE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cliente" ItemStyle-Width="170px">
                        <ItemTemplate>
                            <asp:Label ID="CLIENTE_ID" runat="server" Text='<%# Bind("CLIENTE_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Observación" ItemStyle-Width="300px">
                        <ItemTemplate>
                            <asp:Label ID="MEJORA_ID" runat="server" Text='<%# Bind("MEJORA_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="DetalleMejora" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="PROBLEMA_DETMEJORA" runat="server" Text='<%# Bind("PROBLEMA_DETMEJORA") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CreadorPc" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="PROBLEMA_CREADORPC" runat="server" Text='<%# Bind("PROBLEMA_CREADORPC") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Estado Mejora" Visible="true" ItemStyle-Width="120px">
                        <ItemTemplate>
                            <asp:Label ID="NOM_ESTADO" runat="server" Text='<%# Bind("NOM_ESTADO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Detalle / Segto" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate> 
                            <asp:LinkButton ID="btnVer" runat="server" CausesValidation="true" CommandName="bVer" Text="Mostrar"></asp:LinkButton>                              
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Panel>

    <br />
    
    <asp:UpdatePanel ID="updDetalleMejora" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h3>Detalle de la Mejora y Documentos Adjuntos de la Mejora Nro &nbsp; <asp:Label ID="lblTituloMejora" runat="server" Text=""></asp:Label></h3>
            <asp:TextBox ID="txtMejora" runat="server" TextMode="MultiLine" Width="650px" Height="150px" ReadOnly="true"></asp:TextBox>
        </ContentTemplate>
    </asp:UpdatePanel>

    <br />

    <asp:UpdatePanel ID="upAdjunto" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gvFileUpload" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="ADJUNTO_ID,USRPC_ID" 
                onrowcommand="gvFileUpload_RowCommand" AllowPaging="true" PageSize="5" 
                PagerSettings-PageButtonCount="3" PagerSettings-Mode="NumericFirstLast" 
                    PagerSettings-FirstPageText="Primera" 
                PagerSettings-LastPageText="Ultima" 
                onpageindexchanging="gvFileUpload_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Item">
                        <ItemTemplate>
                            <asp:Label ID="IdAdjunto" runat="server" Text='<%# Bind("ADJUNTO_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="USR PC" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="IdPc" runat="server" Text='<%# Bind("USRPC_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nombre Documento" ItemStyle-Width="250px">
                        <ItemTemplate>                            
                            <asp:HyperLink ID="hlnkDocumento" runat="server" Text='<%# Eval("ADJUNTO_NOMBRE") %>' NavigateUrl='<%# Eval("ADJUNTO_DIR") %>' Target="_blank"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="URL Doc" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="DirAdjunto" runat="server" Text='<%# Bind("ADJUNTO_DIR") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

<%--                    <asp:TemplateField HeaderText="" ShowHeader="false">
                        <ItemTemplate>
                            <asp:LinkButton ID="fileDelete" runat="server" CausesValidation="false" CommandName="fDelete" Text="Borrar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
    
        </ContentTemplate>
    </asp:UpdatePanel>

    <br />    
          
    <asp:Panel ID="panSeguimiento" runat="server" Height="250px">
    <asp:UpdatePanel ID="updSeguimiento" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <h3>Seguimientos de la Mejora Nro &nbsp; <asp:Label ID="lblObs" runat="server" Text=""></asp:Label></h3>  

            <asp:GridView ID="gvTodoSegto" runat="server" AllowPaging="true" 
                AutoGenerateColumns="false" PageSize="5" PagerSettings-PageButtonCount="3" PagerSettings-Mode="NumericFirstLast" 
                PagerSettings-FirstPageText="Primera" PagerSettings-LastPageText="Ultima" 
                onpageindexchanging="gvTodoSegto_PageIndexChanging">
                <EmptyDataTemplate>    
                    <center>                    
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img_files/data_backup.png" Width="150px" Height="150px"/>
                        <br />
                        <h1>NO HAY SEGUIMIENTOS PARA EL ITEM SELECCIONADO</h1>
                    </center>
                </EmptyDataTemplate>
                <RowStyle CssClass="nomTodoSegto" />
                <Columns>
                    
                    <asp:TemplateField HeaderText="Nro" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="SEGUIMIENTO_ID" runat="server" CssClass="nroSegto" Text='<%# Bind("SEGUIMIENTO_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Estado" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="ESTADO_ID" runat="server" Text='<%# Bind("ESTADO_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ID Problema" ItemStyle-HorizontalAlign="Center" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="PROBLEMA_ID" runat="server" Text='<%# Bind("PROBLEMA_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Responsable" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="SEGUIMIENTO_RESPONSABLE" runat="server" Text='<%# Bind("SEGUIMIENTO_RESPONSABLE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Acción" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="SEGUIMIENTO_ACCION" runat="server" Text='<%# Bind("SEGUIMIENTO_ACCION") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha Compromiso" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="SEGUIMIENTO_FCOMPROMISO" runat="server" Text='<%# Bind("SEGUIMIENTO_FCOMPROMISO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha Cierre" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="SEGUIMIENTO_FCIERRE" runat="server" Text='<%# Bind("SEGUIMIENTO_FCIERRE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Observación" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label Visible="false" ID="SEGUIMIENTO_OBSERVACION" runat="server" Text='<%# Bind("SEGUIMIENTO_OBSERVACION") %>'></asp:Label>
                            <a href="javascript:void(null);" id="a-ver-obs" onclick="verObservacion();">Ver Observacion</a>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Panel>

    <div id="dialog-segto" title="Observacion" style="display:none">
        Nro Seguimiento: &nbsp; <label id="lblNroSegto"></label>
        <br />
        Observacion: <br /> <label id="lblObsSegto"></label>
    </div>

    <!-- 
        INICIO JAVASCRIPT
    -->
    <script type="text/javascript" language="javascript">

        function cambiaAreaInformante() {
            var getidA = document.getElementById("<%=cboAreaMejora.ClientID %>");
            var geta = getidA.value;
        }

        function cambiaInformante() {
            var getidInf = document.getElementById("<%=cboEstado.ClientID %>");
            var getInf = getidInf.value;
        }

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            if (args.get_error() == undefined) {
                reloadNumeroMejora();
            }
        }

        function reloadNumeroMejora() {
            $(document).ready(function () {
                $.ajax({
                    type: "POST",

                    url: "/asmx_files/problema_llenado_cbo.asmx/getNumeroMejora",
                    dataType: "json",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    options: { items: Infinity },

                    success: function (data) {

                        var dataFromServer = data.d.split(":");
                        $("#txtNumero").autocomplete({
                            source: dataFromServer
                        });
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus);
                    }
                });
            })
        }
        reloadNumeroMejora();

        function verObservacion() {
            $('.nomTodoSegto').on('click', function () {
                var segtoID = $(".nroSegto", $(this).closest("tr")).html();
                var problID = $("#<%=lblObs.ClientID %>").text();

                $.ajax({
                    type: "POST",
                    url: "/asmx_files/problema_llenado_cbo.asmx/getObservacion",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({ "pid": problID, "sid": segtoID }),
                    success: function (data, status) {
                        $("#lblObsSegto").html(data.d);
                    },
                    error: function (data) {
                        alert("Error al consultar");
                    }
                });

                $("#lblNroSegto").html(segtoID);
                $("#dialog-segto").dialog({
                    modal: true,
                    width: "600px",
                    buttons: {
                        "OK": function () {
                            $(this).dialog('close');
                        }
                    }
                });
            });
            return false;
        }
        </script>
    <!-- 
        FIN JAVASCRIPT
    -->

</asp:Content>