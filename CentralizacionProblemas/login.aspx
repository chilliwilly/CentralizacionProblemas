<%@ Page Title="Login - Gestion de Mejoras" Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CentralizacionProblemas.login" %>

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
                    <h2 style="font-family:Arial; text-align:center;">Acceso Gestión de Mejora</h2>
                </td>
            </tr>
            <tr>
                <td style="font-family:Arial; text-align:center;">
                    Si tiene problemas de acceso contacte con el 
                    <a href="mailto:wcontreras@dts.cl?subject=Problema Sistema Gestion de Mejora">administrador</a>
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
                    Contraseña
                </td>
            </tr>
            <tr>
                <td style="text-align:center;">
                    <asp:TextBox ID="txtPwd" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:center;">
                    <asp:Button ID="btnEntrar" runat="server" Text="Entrar" 
                        onclick="btnEntrar_Click" />
                </td>                
            </tr>
            <tr>
                <td style="text-align:center; font-family:Arial;">
                    <a href="forms/pwd_recordar.aspx">Resetear Contraseña</a>
                    <br />
                    <a href="forms/pwd_cambiar.aspx">Cambiar Contraseña</a>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
