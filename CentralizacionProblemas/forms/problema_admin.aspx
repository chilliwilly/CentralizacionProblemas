﻿<%@ Page Title="Ver Seguimiento - Gestion de Mejoras" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="problema_admin.aspx.cs" Inherits="CentralizacionProblemas.problema_admin" 
    EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link type="text/css" rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
    <script type="text/javascript" src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
    <%--//code.jquery.com/jquery-2.1.3.min.js //ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True" ScriptMode="Release" EnablePartialRendering="true" LoadScriptsBeforeUI="false">
    </asp:ToolkitScriptManager>
    <!-- 
        INICIO JAVASCRIPT
    -->
            <script type="text/javascript" language="javascript">
                function validaChkBox() {
                    $(document).ready(function () {
                        $("<div id='dialog' title='Faltan Campos'><p>Debe seleccionar almenos un Area de Mejora y un Estado de la Mejora.</p></div>").dialog({ modal: true });
                    });
                }

                function validaFechaD() {
                    $(document).ready(function () {
                        $("<div id='dialog' title='Fecha Desde'><p>Debe seleccionar fecha creacion mejora.</p></div>").dialog({ modal: true });
                    });
                }

                $(function () {
                    $("[id*=chkTodoArea]").bind("click", function () {
                        if ($(this).is(":checked")) {
                            $("[id*=chkListArea] input").attr("checked", "checked");
                        } else {
                            $("[id*=chkListArea] input").removeAttr("checked");
                        }
                    });
                    $("[id*=chkListArea] input").bind("click", function () {
                        if ($("[id*=chkListArea] input:checked").length == $("[id*=chkListArea] input").length) {
                            $("[id*=chkTodoArea]").attr("checked", "checked");
                        } else {
                            $("[id*=chkTodoArea]").removeAttr("checked");
                        }
                    });

                    $("[id*=chkTodoEstado]").bind("click", function () {
                        if ($(this).is(":checked")) {
                            $("[id*=chkListEstado] input").attr("checked", "checked");
                        } else {
                            $("[id*=chkListEstado] input").removeAttr("checked");
                        }
                    });
                    $("[id*=chkListEstado] input").bind("click", function () {
                        if ($("[id*=chkListEstado] input:checked").length == $("[id*=chkListEstado] input").length) {
                            $("[id*=chkTodoEstado]").attr("checked", "checked");
                        } else {
                            $("[id*=chkTodoEstado]").removeAttr("checked");
                        }
                    });
                });              
            </script>
    <!-- 
        FIN JAVASCRIPT
    -->

    <h1>Ver Seguimiento</h1>
    <br />    
    <asp:Panel ID="panMejoraBuscar" runat="server">
    <asp:UpdatePanel ID="upMejoraBuscar" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td>Area Mejora &nbsp;</td>
                    <td>
                        <%--<asp:CascadingDropDown ID="cddAreaInformante" runat="server" TargetControlID="cboAreaMejora" LoadingText="Cargando Area..." PromptText="Seleccione Area" 
                                ServicePath="~/asmx_files/problema_llenado_cbo.asmx" ServiceMethod="getAreaMejoraFiltro" 
                                Category="amejora_id">
                        </asp:CascadingDropDown>
                        <asp:DropDownList ID="cboAreaMejora" runat="server" Width="170px" onchange="cambiaAreaInformante();">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvAreaMejora" runat="server" ErrorMessage="Debe seleccionar area mejora" Display="None" ControlToValidate="cboAreaMejora"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vceAreaMejora" runat="server" TargetControlID="rfvAreaMejora" HighlightCssClass="validatorCalloutHighlight">
                        </asp:ValidatorCalloutExtender>--%>

                        <table><tr><td><asp:CheckBox ID="chkTodoArea" runat="server" Text="Todo"/></td></tr></table>
                        <asp:CheckBoxList ID="chkListArea" runat="server" oninit="chkListArea_Init" RepeatColumns="3">
                        </asp:CheckBoxList>                 
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>Estado Mejora &nbsp;</td>
                    <td>
                        <%--<asp:CascadingDropDown ID="cddInformante" runat="server" TargetControlID="cboEstado" LoadingText="Cargando Estados..." PromptText="Seleccione Estados" 
                                ServicePath="~/asmx_files/problema_llenado_cbo.asmx" ServiceMethod="getEstadoFiltro" Category="estado_id">
                        </asp:CascadingDropDown>
                        <asp:DropDownList ID="cboEstado" runat="server" Width="170px" onchange="cambiaInformante();">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvEstado" runat="server" ErrorMessage="Debe seleccionar une estado" Display="None" ControlToValidate="cboEstado"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vceEstado" runat="server" TargetControlID="rfvEstado" HighlightCssClass="validatorCalloutHighlight">
                        </asp:ValidatorCalloutExtender>--%>

                        <table><tr><td><asp:CheckBox ID="chkTodoEstado" runat="server" Text="Todo"/></td></tr></table>
                        <asp:CheckBoxList ID="chkListEstado" runat="server" oninit="chkListEstado_Init" RepeatColumns="2">
                        </asp:CheckBoxList>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>Fecha Desde &nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtFechaD" runat="server" Width="120px" style="text-align:center;" placeholder="Fecha Mejora"></asp:TextBox>
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
                    <td>Fecha Hasta &nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtFechaH" runat="server" Width="120px" style="text-align:center;"></asp:TextBox>
                        <asp:CalendarExtender ID="ceFechaH" TargetControlID="txtFechaH" runat="server"
                                FirstDayOfWeek="Monday" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                        <asp:RequiredFieldValidator ID="rfvFechaH" runat="server" ErrorMessage="Debe seleccionar una fecha" Display="None" ControlToValidate="txtFechaH"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vceFechaH" runat="server" TargetControlID="rfvFechaH" HighlightCssClass="validatorCalloutHighlight">
                        </asp:ValidatorCalloutExtender>
                    </td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                            onclick="btnBuscar_Click"/>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Panel>

    <br />
    <asp:Panel ID="panListaProblema" runat="server" Width="100%" Height="250px">
        <asp:UpdatePanel ID="updListaProblema" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="gvListaProblema" runat="server" AllowPaging="true" 
                    AutoGenerateColumns="false" PageSize="5" 
                    PagerSettings-PageButtonCount="10" PagerSettings-Mode="NumericFirstLast" 
                    PagerSettings-FirstPageText="Primera" PagerSettings-LastPageText="Ultima" 
                    onrowcommand="gvListaProblema_RowCommand" 
                    onpageindexchanging="gvListaProblema_PageIndexChanging">
                    <EmptyDataTemplate>    
                        <center>
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

                        <asp:TemplateField HeaderText="Area Informante" ItemStyle-Width="120px">
                            <ItemTemplate>
                                <asp:Label ID="AREA_ID" runat="server" Text='<%# Bind("AREA_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Informante" ItemStyle-Width="120px">
                            <ItemTemplate>
                                <asp:Label ID="PROBLEMA_INFORMANTE" runat="server" Text='<%# Bind("PROBLEMA_INFORMANTE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

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

                        <asp:TemplateField HeaderText="Cliente" ItemStyle-Width="120px">
                            <ItemTemplate>
                                <asp:Label ID="CLIENTE_ID" runat="server" Text='<%# Bind("CLIENTE_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Observación" ItemStyle-Width="200px">
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

                        <asp:TemplateField HeaderText="Detalle / Segto" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center">
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

    <asp:UpdatePanel ID="updTituloMejora" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h1>Detalle Mejora <asp:Label ID="lblTituloMejora" runat="server" Text=""></asp:Label></h1>
        </ContentTemplate>
    </asp:UpdatePanel>   

    <br />

    <asp:Panel ID="panMejora" runat="server">
        <asp:UpdatePanel ID="updMejora" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <table>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtMejora" runat="server" TextMode="MultiLine" Width="650px" Height="150px" ReadOnly="true"></asp:TextBox>
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            Creado Desde PC
                        </td>
                        <td>
                            <asp:TextBox ID="txtCreadorPc" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                </table>                                

            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

    <br /><br />

    <asp:UpdatePanel ID="updTituloTodoSgto" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h1>Seguimientos Para Nro <asp:Label ID="lblObs" runat="server" Text=""></asp:Label></h1>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <br />

    <asp:Panel ID="panTodoSegto" runat="server" Width="100%" Height="250px">
        <asp:UpdatePanel ID="updTodoSegto" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="gvTodoSegto" runat="server" AllowPaging="true" 
                    AutoGenerateColumns="false" PageSize="5" PagerSettings-PageButtonCount="10" PagerSettings-Mode="NumericFirstLast" 
                    PagerSettings-FirstPageText="Primera" PagerSettings-LastPageText="Ultima" 
                    onpageindexchanging="gvTodoSegto_PageIndexChanging">
                    <EmptyDataTemplate>    
                        <center>                    
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/img_files/data_backup.png" Width="150px" Height="150px"/>
                            <br />
                            <h1>NO HAY SEGUIMIENTOS PARA EL ITEM SELECCIONADO</h1>
                        </center>
                    </EmptyDataTemplate>
                    <Columns>
                    
                        <asp:TemplateField HeaderText="Nro" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="SEGUIMIENTO_ID" runat="server" Text='<%# Bind("SEGUIMIENTO_ID") %>'></asp:Label>
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
                                <asp:Label ID="SEGUIMIENTO_OBSERVACION" runat="server" Text='<%# Bind("SEGUIMIENTO_OBSERVACION") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
