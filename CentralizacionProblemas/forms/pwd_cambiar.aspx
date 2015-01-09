<%@ Page Title="Cambio Contraseña - Gestion de Mejoras" Language="C#" AutoEventWireup="true" CodeBehind="pwd_cambiar.aspx.cs" Inherits="CentralizacionProblemas.pwd_cambiar" %>

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
                    <h2 style="font-family:Arial; text-align:center;">Centralización Problemas CAL</h2>
                </td>
            </tr>
            <tr>
                <td style="font-family:Arial; text-align:center;">
                    Ingrese datos para cambiar contraseña
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:center; font-family:Arial;">
                    Usuario
                </td>
            </tr>
            <tr>
                <td style="text-align:center;">
                    <asp:TextBox ID="txtUser" runat="server" style="text-align:center;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:center; font-family:Arial;">
                    Contraseña Antigua
                </td>
            </tr>
            <tr>
                <td style="text-align:center;">
                    <asp:TextBox ID="txtPwd" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:center; font-family:Arial;">
                    Contraseña Nueva
                </td>
            </tr>
            <tr>
                <td style="text-align:center;">
                    <asp:TextBox ID="txtPwdNew" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:center; font-family:Arial;">
                    Repita Contraseña Nueva
                </td>
            </tr>
            <tr>
                <td style="text-align:center;">
                    <asp:TextBox ID="txtPwdNewR" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:center;">
                    <asp:Button ID="btnCambiar" runat="server" Text="Cambiar" 
                        onclick="btnCambiar_Click" />
                </td>                
            </tr>            
        </table>
    </form>
</body>
</html>
