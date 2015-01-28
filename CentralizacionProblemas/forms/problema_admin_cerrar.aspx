<%@ Page Title="Cerrar Seguimiento - Gestion de Mejoras" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="problema_admin_cerrar.aspx.cs" 
    Inherits="CentralizacionProblemas.forms.problema_admin_cerrar" EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True" ScriptMode="Release" EnablePartialRendering="true" LoadScriptsBeforeUI="false">
    </asp:ToolkitScriptManager>
        <script type="text/javascript">
            function muestraModal() {                
                $("#accion").val("");
                $("#btnAgregaAcc").click(function () {
                    $("#dialog-form").dialog({
                        buttons: {
                            "Agregar": guardaAccion
                            ,
                            Cerrar: function () {
                                $(this).dialog('close');
                            }
                        },
                        modal: true
                    });
                });
            }

            function muestraAccion() {
                $("#btnEditaAcc").click(function () {
                    __doPostBack('<%=upListaAccion.ClientID %>', '');
                    $("#dialog-accion").dialog({
                        modal: true,
                        width: "300px",
                        buttons: {
                            Cerrar: function () {
                                $(this).dialog('close');
                            }
                        }
                    });
                });
            }

            function guardaAccion() {
                if (validaInputAcc($("#accion").val())) {
                    guardarAccion($("#accion").val());
                    __doPostBack('<%=cboAccion.ClientID %>', '');                    
                }
                else {
                    alert("La accion ingresada ya existe");
                    __doPostBack('<%=cboAccion.ClientID %>', '');
                }
            }
        </script>

    <h1>Cierre Seguimiento</h1>
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

                        <asp:CheckBoxList ID="chkListArea" runat="server" oninit="chkListArea_Init" RepeatColumns="3">
                        </asp:CheckBoxList>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>Estado Mejora &nbsp;</td>
                    <td>
                        <%--<asp:CascadingDropDown ID="cddInformante" runat="server" TargetControlID="cboEstadoBusca" LoadingText="Cargando Estados..." PromptText="Seleccione Estados" 
                                ServicePath="~/asmx_files/problema_llenado_cbo.asmx" ServiceMethod="getEstadoSinCerrar" Category="estado_id">
                        </asp:CascadingDropDown>
                        <asp:DropDownList ID="cboEstadoBusca" runat="server" Width="170px" onchange="cambiaInformante();">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvEstado" runat="server" ErrorMessage="Debe seleccionar une estado" Display="None" ControlToValidate="cboEstadoBusca"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vceEstado" runat="server" TargetControlID="rfvEstado" HighlightCssClass="validatorCalloutHighlight">
                        </asp:ValidatorCalloutExtender>--%>

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
                            onclick="btnBuscar_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Panel>

    <br />
    <asp:Panel ID="panListaProblema" runat="server" Width="100%" Height="300px">
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
                <asp:TextBox ID="txtMejora" runat="server" TextMode="MultiLine" Width="650px" Height="150px" ReadOnly="true"></asp:TextBox>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

    <br />

    <asp:UpdatePanel ID="updTituloSgto" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h1>Seguimiento Para Nro <asp:Label ID="lblTituloSgto" runat="server" Text=""></asp:Label></h1>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div id="dialog-form" title="Ingreso Accion" style="display:none;">
        <p class="validateTips">Nombre de la acción a ingresar</p>
        <form>
            <fieldset>
                <label for="name">Nombre Accion</label>
                <input type="text" name="name" id="accion" value="" class="text ui-widget-content ui-corner-all"/>    
            </fieldset>
        </form>
    </div>

    <div id="dialog-accion" title="Ingreso Accion" style="display:none;">
        <form>
        <fieldset>
            <label for="name">Nombre Accion</label>
            <input type="text" name="nomAcc" id="nomAcc" value="" class="text ui-widget-content ui-corner-all" />
            <br /><br />
            <input type="button" value="Agregar" name="Agregar" id="btnAccAdd" />
        </fieldset>
        </form>
        <asp:UpdatePanel ID="upListaAccion" runat="server" UpdateMode="Conditional" 
            onload="upListaAccion_Load">
            <ContentTemplate>                
                <asp:GridView HorizontalAlign="Center" ID="gvListaAccion" runat="server" AutoGenerateColumns="false" 
                    AllowPaging="true" PageSize="5" PagerSettings-PageButtonCount="5" PagerSettings-Mode="NumericFirstLast" 
                            PagerSettings-FirstPageText="Primera" 
                    PagerSettings-LastPageText="Ultima" oninit="gvListaAccion_Init" 
                    onpageindexchanging="gvListaAccion_PageIndexChanging">
                    <RowStyle CssClass="nomTodoAccion" />
                    <Columns>
                        <asp:TemplateField HeaderText="IdAccion" ItemStyle-HorizontalAlign="Center" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIdAccion" CssClass="nroAccion" runat="server" Text='<%# Bind("IDNACC") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Accion" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <asp:Label ID="lblAccion" CssClass="nomAccion" runat="server" Text='<%# Bind("NOMACC") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <%--<a href="javascript:void(null);" id="btn-delete" class="ui-icon ui-icon-closethick"></a>--%>
                                <a href="javascript:void(null);" id="btn-update" onclick="actualizaAccion();" class="ui-icon ui-icon-transferthick-e-w"></a>
                                <%--<span class="ui-icon ui-icon-closethick"></span>                                
                                    &nbsp;
                                <span class="ui-icon ui-icon-transferthick-e-w"></span>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Button runat="server" ID="btnUpdateLista" Visible="false" 
                    onclick="btnUpdateLista_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <asp:Panel ID="panDatoProblema" runat="server">
        <asp:UpdatePanel ID="updDatoProblema" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <script type="text/javascript">
                    Sys.Application.add_load(muestraModal);
                    Sys.Application.add_load(muestraAccion);
     		    </script>
                <table>
                    <tr>
                        <td>
                            Mejora Creada PC
                        </td>
                        <td>
                            <asp:TextBox ID="txtCreadorPc" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                        <td>
                            
                        </td>
                        <td>
                            Accion *
                        </td>
                        <td>
                            <%--<asp:TextBox ID="txtAccion" runat="server" placeholder="Acción que se realiza"></asp:TextBox>--%>
                            <asp:DropDownList ID="cboAccion" runat="server" oninit="cboAccion_Init">
                            </asp:DropDownList>
                            <%--<asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />--%>
                            <input type="button" name="btnAgregaAcc" id="btnAgregaAcc" value="Agregar Accion" />
                            <input type="button" name="btnEditaAcc" id="btnEditaAcc" value="Editar Accion" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Estado *
                        </td>
                        <td>
                            <asp:CascadingDropDown ID="cddEstado" runat="server" TargetControlID="cboEstado" LoadingText="Cargando Estados..." PromptText="Seleccione Estado" 
                                ServicePath="~/asmx_files/problema_llenado_cbo.asmx" ServiceMethod="getEstado" 
                                Category="estado_id">
                            </asp:CascadingDropDown>
                            <asp:DropDownList ID="cboEstado" runat="server" Enabled="false">
                            </asp:DropDownList>
                        </td>
                        <td>
                            
                        </td>
                        <td>
                            Fecha Compromiso *
                        </td>
                        <td>
                            <asp:TextBox ID="txtFechaComp" runat="server" Enabled="false"></asp:TextBox>
                            <asp:CalendarExtender ID="ceFechaComp" TargetControlID="txtFechaComp" runat="server"
                                    FirstDayOfWeek="Monday" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Area *
                        </td>
                        <td>
                            <%--<asp:TextBox ID="txtResponsable" runat="server"></asp:TextBox>--%>
                            <asp:CascadingDropDown ID="cddArea" runat="server" TargetControlID="cboArea" LoadingText="Cargando Area..." PromptText="Seleccione Area" 
                                ServicePath="~/asmx_files/problema_llenado_cbo.asmx" ServiceMethod="getArea" 
                                Category="area_id">
                            </asp:CascadingDropDown>
                            <asp:DropDownList ID="cboArea" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            
                        </td>
                        <td>
                            Fecha Cierre *
                        </td>
                        <td>
                            <asp:TextBox ID="txtFechaCierre" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="ceFechaCierre" TargetControlID="txtFechaCierre" runat="server"
                                    FirstDayOfWeek="Monday" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>   
                    <tr>
                        <td>
                            Responsable *
                        </td>
                        <td colspan="4">
                            <asp:CascadingDropDown ID="cddResponsable" runat="server" TargetControlID="cboResponsable" LoadingText="Cargando Responsable..." PromptText="Seleccione Responsable" 
                                    ServicePath="~/asmx_files/problema_llenado_cbo.asmx" ServiceMethod="getResponsable" Category="user_id" ParentControlID="cboArea"><%--ParentControlID="cboAreaInformante"--%>
                            </asp:CascadingDropDown>
                            <asp:DropDownList ID="cboResponsable" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>                 
                    <tr>
                        <td>
                            Observaciones *
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtObservacion" runat="server" MaxLength="450" placeholder="Breve descripcion de la accion a tomar con esta mejora" TextMode="MultiLine" Width="500px" Height="70px"></asp:TextBox>
                        </td>                        
                    </tr>
                </table>
                
                <br />

                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar Seguimiento" 
                    onclick="btnCerrar_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

    <br /><br /><br />

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
                    <RowStyle CssClass="nomTodoSegto" />
                    <Columns>
                    
                        <asp:TemplateField HeaderText="Nro" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="SEGUIMIENTO_ID" CssClass="nroSegto" runat="server" Text='<%# Bind("SEGUIMIENTO_ID") %>'></asp:Label>
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

    <div id="dialog-tab" title="Elija Opcion" style="display:none">
        <div id="tab">
            <ul>
                <li><a href="#tab-upd">Actualizar</a></li>
                <li><a href="#tab-del">Borrar</a></li>
            </ul>
            <div id="tab-upd">
                <div id="dialog-actualiza" title="Actualiza Accion">
                    Ingrese el nuevo nombre de la accion
                    <br /><br />
                    Nombre Actual: &nbsp; <label id="lblAccionNomActual"></label>
                    <br />
                    Nombre Nuevo: &nbsp; <input type="text" id="txt-nom-acc" class="text ui-widget-content ui-corner-all" name="txt-nom-acc" value=""/>
                    <br /><br />
                    <input type="button" id="btn-actualiza-sgto" value="Actualizar" name="btn-actualiza-sgto" />
                </div>
            </div>

            <div id="tab-del">
                <div id="dialog-borra" title="Borrar Accion">
                    Esta seguro que desea borrar la siguiente Accion?
                    <br /><br />
                    Nombre Accion: &nbsp;
                    <label id="lblBorraSegto"></label>
                    <br /><br />
                    <input type="button" id="btn-borra-sgto" value="Borrar" name="btn-borra-sgto" />
                </div> 
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function cambiaCliente() {
            var getidEto = document.getElementById("<%=cboEstado.ClientID %>");
            var getEto = getidEto.value;
        }

        function validaChkBox() {
            $("<div id='dialog' title='Faltan Campos'><p>Debe seleccionar almenos un Area de Mejora y un Estado de la Mejora.</p></div>").dialog({ modal: true });            
        }

        function validaFechaD() {
            $("<div id='dialog' title='Fecha Desde'><p>Debe seleccionar fecha creacion mejora.</p></div>").dialog({ modal: true });            
        }

        function validaInMejora(msg) {
            $("<div id='dialog' title='Ingreso Seguimiento'><p>" + msg + ".</p></div>").dialog({ modal: true });            
        }

        function validaObsMejora() {
            $("<div id='dialog' title='Largo Texto Segto Mejora'><p>El texto del Seguimiento de la Mejora no puede superar los 500 caracteres.</p></div>").dialog({ modal: true });
        }

        $("#btnAccAdd").on('click', function () {
            if (validaInputAcc($("#nomAcc").val())) {
                guardarAccion($("#nomAcc").val());
                __doPostBack('<%=cboAccion.ClientID %>', '');                
                $("#dialog-accion").dialog("close");
                $("#dialog-accion").dialog("open");
            }
            else {
                alert("La accion ingresada ya existe");
                __doPostBack('<%=cboAccion.ClientID %>', '');
            }
            $("#nomAcc").val("");
        });

        $(document).ready(function () {
            var usrcookie = $.cookie("v_u");
            if (usrcookie != 'jocontreras' && usrcookie != 'wcontreras') {
                $("#btnAgregaAcc").css("display", "none");
                $("#btnEditaAcc").css("display", "none");
            }
        });

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

        var nomacc;
        function actualizaAccion() {
            $('.nomTodoAccion').on('click', function () {
                nomacc = $(".nomAccion", $(this).closest("tr")).html();

                $("#dialog-accion").dialog("close");

                $("#lblAccionNomActual").html(nomacc);
                $("#lblBorraSegto").html(nomacc);

                $("#dialog-tab").dialog({
                    modal: true,
                    width: "500px"
                });
            });
            return false;
        }

        $("#btn-borra-sgto").on('click', function () {
            borrarAccion(nomacc);
            $("#dialog-tab").dialog('close');
            __doPostBack('<%=cboAccion.ClientID %>', '');
        });

        $("#btn-actualiza-sgto").on('click', function () {
            if (validaInputAcc($("#txt-nom-acc").val())) {
                actualizarAccion(nomacc, $("#txt-nom-acc").val());
                $("#dialog-tab").dialog('close');
                __doPostBack('<%=cboAccion.ClientID %>', '');
            }
            else {
                alert("La accion ingresada ya existe");
                __doPostBack('<%=cboAccion.ClientID %>', '');
            }
            $("#txt-nom-acc").val("");
        });

        $(function () {
            $("#tab").tabs();
        });
        </script>
</asp:Content>