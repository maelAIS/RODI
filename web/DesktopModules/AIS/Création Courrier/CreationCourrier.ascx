<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CreationCourrier.ascx.cs" Inherits="DesktopModules_AIS_Création_Courrier_CreationCourrier" %>


<asp:Panel runat="server" ID="pnl_page">

    
    <p> Année et mois du courrier : <asp:DropDownList ID="ddl_year" runat="server"></asp:DropDownList> <asp:DropDownList ID="ddl_month" runat="server"></asp:DropDownList></p>
    

   <%-- <asp:Panel runat="server" ID="pnl_settings" Visible="false">
        <h1>Paramètres : </h1>
        <p>Catégorie : 
        <asp:RadioButtonList ID="rbl_category" runat="server">
            <asp:ListItem Text="District" Value="District"></asp:ListItem>
            <asp:ListItem Text="Club" Value="Clubs"></asp:ListItem>
            <asp:ListItem Text="Courrier du District" Value="courrierdistrict" Selected="True"></asp:ListItem>
        </asp:RadioButtonList>
        </p>
        <p>Nombre de News : <asp:TextBox ID="tbx_nbNews" runat="server" Text="0"></asp:TextBox></p>
        <p>Style : <asp:TextBox runat="server" ID="tbx_style" Text="MiniNews"></asp:TextBox></p>
        <p>Tags à inclure : <asp:TextBox runat="server" ID="tbx_tagsIncluded" ></asp:TextBox></p>
        <p>Tags à exclure : <asp:TextBox runat="server" ID="tbx_tagsExcluded" ></asp:TextBox></p>
    
    </asp:Panel>--%>
    



    <br />
    <asp:Button runat="server" CssClass="btn btn-primary" ID="btn_creation" Text="Créer les pages" OnClick="btn_creation_Click"/>
</asp:Panel>

<asp:Panel runat="server" ID="pnl_error" Visible="false">
    <asp:Label runat="server" Visible="true" ID="lbl_pageExists" Text="La page que vous essayez de créer existe déjà"></asp:Label><asp:HyperLink ID="hlk_pageExists" runat="server" Text=" ici"></asp:HyperLink>
    <asp:Label runat="server" Visible="false" ID="lbl_pageInBin" Text="truc"> La page a déjà été créée puis effacée, il faut d'abord vider la corbeille afin de pouvoir la recréer (merci de contacter :<asp:HyperLink Target="_blank" NavigateUrl="mailto:webmaster@rotary1730.org" Text="webmaster@rotary1730.org" runat="server" ID="hl_contact"></asp:HyperLink> )</asp:Label>
    <asp:Button runat="server" CssClass="btn btn-default" Text="Retour" ID="btn_back" OnClick="btn_back_Click" />
    
</asp:Panel>

<asp:Panel runat="server" ID="pnl_success" Visible="false">
    <asp:Label runat="server" Text="Vos pages ont été créées"></asp:Label>
</asp:Panel>
