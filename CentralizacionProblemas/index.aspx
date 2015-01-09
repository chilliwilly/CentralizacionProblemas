<%@ Page Title="Inicio - Gestion de Mejoras" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CentralizacionProblemas.index" EnableSessionState="False" EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Stylesheet" href="../css/jquery-ui.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/jquery-migrate-1.2.1.js"></script>
    <script type="text/javascript">
        if (/chrom(e|ium)/.test(navigator.userAgent.toLowerCase())) {
            alert("El navegador que esta utilizando aun no es compatible. Puede que visualize algunos problemas de diseño en algunas paginas o de funcionalidad. Se recomienda usar Internet Explorer o Mozilla Firefox");
        } 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>INICIO</h1>
<br />
<h1>cambios realizados y otros.</h1>
<br />
<p><asp:HyperLink ID="id01" runat="server" NavigateUrl="~/adjunto_doc/Informacion_Gestion_de_Mejora.pdf" Target="_blank">Documento de Ayuda del Sistema</asp:HyperLink></p>
</asp:Content>
