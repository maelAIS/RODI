<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_Création_Courrier_Settings" %>

<table>
    <tr>
        <td><asp:Label Text="Role autorisé à modifier : " runat="server"></asp:Label></td>
        <td><asp:TextBox ID="tbx_role" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label Text="Chemin d'accès aux fichiers par défaut : " runat="server"></asp:Label></td>
        <td><asp:TextBox ID="tbx_path" runat="server" ></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label Text="Style du bandeau : " runat="server"></asp:Label></td>
        <td><asp:TextBox ID="tbx_style" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label Text="Page d'impression : " runat="server"></asp:Label></td>
        <td><asp:TextBox ID="tbx_impress" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label Text="Chemin de redirection : " runat="server"></asp:Label></td>
        <td><asp:TextBox ID="tbx_redirect" runat="server"></asp:TextBox></td>
    </tr>
</table>
