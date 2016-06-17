<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageMembreEdit.ascx.cs" Inherits="DesktopModules_AIS_Page_Member_Edit_PageMemberEdit" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<asp:Panel ID="Panel1" runat="server">

    <div>
        <h3><asp:Label runat="server" ID="Label2" Text="Titre de présentation : " /></h3>
        <asp:TextBox runat="server" ID="TBX_Titre" AutoPostBack="true" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Le titre n'a pas été saisi" ControlToValidate="TBX_Titre"></asp:RequiredFieldValidator>
    </div>

    <div>
        <h3><asp:Label runat="server" ID="Label1" Text="Société : " /></h3>
        <asp:TextBox runat="server" ID="TBX_Societe" AutoPostBack="true" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="La société n'a pas été saisie" ControlToValidate="TBX_Societe"></asp:RequiredFieldValidator>
    </div>

    <div>
        <h3><asp:Label runat="server" ID="Label3" Text="Présentation : " /></h3>
        <telerik:RadEditor runat="server" ID="TXT_Editor" ToolsFile="~/DesktopModules/AIS/Page Membre Edit/XMLFile.xml" style="width:100%;" AutoPostBack="true" ></telerik:RadEditor>
	    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="La présentation n'a pas été saisie" Display="None" ControlToValidate="TXT_Editor"></asp:RequiredFieldValidator>
    </div>

    <div>
        <asp:Image runat="server" ID="IMG_Photo" />
	    <%--<telerik:RadAsyncUpload ID="FU_Photo" Localization-Select="Changer la photo" HideFileInput="true" DisablePlugins="true" MultipleFileSelection="Disabled" runat="server" OnClientFileUploaded="OnClientPhotoUploaded" AllowedFileExtensions="jpg,jpeg,gif,png,bmp" ></telerik:RadAsyncUpload>
	    <div style="display:none; width:130px;">
		    <asp:Button runat="server" ID="BT_Upload_Photo" Text="Mettre à jour" OnClick="BT_Upload_Photo_Click" />
		    <script>function OnClientPhotoUploaded(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt = document.getElementById('<%=BT_Upload_Photo.ClientID %>'); bt.click(); }</script>
	    </div>
        <asp:HiddenField runat="server" ID="HF_Photo" />
        <asp:Button runat="server" ID="BT_Effacer_Photo" Text="Supprimer la photo" OnClick="BT_Effacer_Photo_Click" />--%>
    </div>

    <div>
        <asp:Label runat="server" ID="LBL_Nom_Prenom" />
    </div>

    <div>
        <asp:Label runat="server" ID="LBL_Fonction" />
    </div>
    
    <div>
        <asp:Label runat="server" ID="LBL_Classification" />
    </div>

    <div>
        <h3><asp:Label runat="server" ID="Label5" Text="Logo : " /></h3>
        <asp:Image runat="server" ID="IMG_Logo" />
        <asp:HiddenField runat="server" ID="HF_Logo" />
        <telerik:RadAsyncUpload ID="FU_Logo" HideFileInput="true" Localization-Select="Sélectionner un logo"  MultipleFileSelection="Disabled" runat="server" OnClientFileUploaded="OnClientLogoUploaded" AllowedFileExtensions="jpg,jpeg,gif,png,bmp" ></telerik:RadAsyncUpload>
        <%--<div style="display:none">--%>
        <div style="display:none">
        	<asp:Button runat="server" ID="BT_Upload_Logo" Text="Mettre à jour" OnClick="BT_Upload_Logo_Click" CausesValidation="false" />
        	<script>function OnClientLogoUploaded(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt2 = document.getElementById('<%=BT_Upload_Logo.ClientID %>'); bt2.click(); }</script>
        </div>
        <asp:Button runat="server" ID="BT_Effacer_Logo" Text="Supprimer le logo" OnClick="BT_Effacer_Logo_Click" CausesValidation="false" />
    </div>

    <div>
        <asp:Label runat="server" ID="Label4" Text="URL du site web : " />
        <asp:TextBox runat="server" ID="TBX_URL" AutoPostBack="true" />    
    </div>

    <div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" HeaderText="Veuillez compléter le formulaire avant de valider..." ShowMessageBox="true" ShowSummary="false" />
        <asp:Button runat="server" ID="BT_Valider" Text="Valider" OnClick="BT_Valider_Click" CausesValidation="true" />
        &nbsp;
        <asp:Button runat="server" ID="BT_Annuler" Text="Annuler" OnClick="BT_Annuler_Click" CausesValidation="false" />
    </div>

</asp:Panel>








