<%@ Page Title="Cambio Contraseña - Problemas CAL" Language="C#" AutoEventWireup="true" CodeBehind="load_pwd_cambiar.aspx.cs" Inherits="CentralizacionProblemas.load_pwd_cambiar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table align="center">
            <tr>
                <td align="center">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img_files/LOGO DTS UN Man Cal.bmp"/>
                </td>
            </tr>
            <tr>
                <td>
                    <h2 style="font-family:Arial; text-align:center;">Gestión de Mejora</h2>
                </td>
            </tr>
            <tr>
                <td style="font-family:Arial; text-align:center;">
                    Si tiene problemas contacte con el administrador
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/img_files/loading.gif" Width="200px" Height="200px" />
                </td>
            </tr>  
            <tr>
                <td style="text-align: center; font-weight:bold; font-size:large; font-family:Arial;">
                    Actualizando Datos Contraseña Espere...
                </td>
            </tr>          
        </table>
    </form>
</body>
</html>
