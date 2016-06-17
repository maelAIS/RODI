<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageMembre.ascx.cs" Inherits="DesktopModules_AIS_Page_Member_PageMember" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<div class="row">
    <div class="col-sm-8">
	    <h3><asp:Label runat="server" ID="LBL_Titre2" Text="" /></h3>
	    <asp:Literal runat="server" ID="LTL_Texte2"  />
    </div>
    
    <div class="col-sm-4 text-center">
	    <asp:Image runat="server" ID="IMG_Photo2" /><br />
        <strong><asp:Label runat="server" ID="LBL_Nom_Prenom2" /></strong>
        <asp:Label runat="server" ID="LBL_Fonction2" /><br />
        <asp:Label runat="server" ID="LBL_Classification2" />
        <div class="pe-spacer size10"></div>
        <asp:Label runat="server" ID="LBL_Societe" />
        <div class="pe-spacer size10"></div>
        <asp:Image runat="server" ID="IMG_Logo2" />
        <div class="pe-spacer size10"></div>
        <asp:HyperLink runat="server" ID="HLK_URL2"  Target="_blank" Text="Accès au site web"/><br />
        <asp:Hyperlink runat="server" ID="HLK_Contact2" Imageurl="/Portals/_default/Skins/Rotary/images/mail.png" ToolTip="Lui envoyer un message" Text="Lui envoyer un message" />
    </div>

	<div class="clear"></div>
    <asp:Button runat="server" ID="BTN_Edit" Text="Modifier la présentation" OnClick="BTN_Edit_Click" />
</div>






