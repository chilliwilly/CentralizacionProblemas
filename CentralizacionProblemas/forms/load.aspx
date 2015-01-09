<%@ Page Title="Cargando ... - Gestion de Mejoras" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="load.aspx.cs" Inherits="CentralizacionProblemas.load" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table align="center">
    <tr>
        <td>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/img_files/loading.gif" Width="200px" Height="200px" />
        </td>
    </tr>
    <tr>
        <td style="text-align: center; font-weight:bold;">
            GUARDANDO DATOS ESPERE....
        </td>
    </tr>
</table>
</asp:Content>
