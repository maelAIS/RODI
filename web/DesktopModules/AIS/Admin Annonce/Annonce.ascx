<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Annonce.ascx.cs" Inherits="DesktopModules_AIS_Admin_Annonce_Annonce" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Panel ID="Panel2" runat="server">
    <div class="left spacingRight">
        <h3><asp:Label runat="server" ID="LBL_Titre2" Text="" /></h3>
        <asp:Literal runat="server" ID="LTL_Texte2"  />
    </div>

    <div class="InfosMembre">
        <asp:Image runat="server" ID="IMG_Logo2" />
        <asp:HyperLink runat="server" ID="HLK_URL2"  Target="_blank" Text="Télécharger le fichier"/>
        <asp:Hyperlink runat="server" ID="HLK_Contact2" Imageurl="/Portals/_default/Skins/Rotary/images/mail.png" ToolTip="Lui envoyer un message" Text="Lui envoyer un message" />
    </div>
    
    <div class="clear"></div>
    <asp:Button runat="server" ID="BTN_Edit" Text="Modifier l'annonce" OnClick="BTN_Edit_Click" />

</asp:Panel>




