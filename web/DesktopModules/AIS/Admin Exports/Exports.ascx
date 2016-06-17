<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Exports.ascx.cs" Inherits="DesktopModules_AIS_Admin_Exports_Exports" %>

<asp:Panel runat="server" ID="panel">
    <asp:Button ID="btn_exportPres" runat="server" OnClick="btn_exportPres_Click" CssClass="btn btn-primary" Text="Exporter les présidents élus" />
    <asp:Button ID="btn_exportBureau" runat="server" OnClick="btn_exportBureau_Click" CssClass="btn btn-primary" Text="Exporter le bureau de l'année prochaine" />
    <asp:Button ID="btn_exportClubsSansBureau" runat="server" OnClick="btn_exportClubsSansBureau_Click" CssClass="btn btn-primary" Text="Exporter les clubs qui n'ont pas déclaré de bureau" />
</asp:Panel>


