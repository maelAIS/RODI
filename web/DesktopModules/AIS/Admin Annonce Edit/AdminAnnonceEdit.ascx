<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminAnnonceEdit.ascx.cs" Inherits="DesktopModules_AIS_Admin_Annonce_Edit_AdminAnnonceEdit" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<asp:Panel ID="Panel1" runat="server">

    <div>
        <h3><asp:Label runat="server" ID="Label2" Text="Titre :   " /></h3>
        <asp:TextBox runat="server" ID="TBX_Titre" AutoPostBack="true" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Le titre n'a pas été saisi" ControlToValidate="TBX_Titre"></asp:RequiredFieldValidator>
    </div>

    <div>
        <asp:RadioButton id="RBT_Offre" Text="Offre" Checked="True" GroupName="typeAnnonce" runat="server"/>
        <asp:RadioButton id="RBT_Demande" Text="Demande" GroupName="typeAnnonce" runat="server"/>
    </div>

    <div>
        <telerik:RadEditor runat="server" ID="TXT_Editor" ToolsFile="~/DesktopModules/AIS/Page Membre Edit/XMLFile.xml" style="width:100%;" AutoPostBack="true" ></telerik:RadEditor>
	    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="L'annonce n'a pas été saisie" Display="None" ControlToValidate="TXT_Editor"></asp:RequiredFieldValidator>
    </div>

    <div>
        <h3><asp:Label runat="server" ID="Label5" Text="Visuel de l'annonce (apparaîtra à droite de mon annonce) : " /></h3>
        <asp:Image runat="server" ID="IMG_Logo" />
        <asp:HiddenField runat="server" ID="HF_Logo" />
        <telerik:RadAsyncUpload ID="FU_Logo" HideFileInput="true" Localization-Select="Sélectionner une image"  MultipleFileSelection="Disabled" runat="server" OnClientFileUploaded="OnClientLogoUploaded" AllowedFileExtensions="jpg,jpeg,gif,png,bmp" ></telerik:RadAsyncUpload>
		<asp:Button runat="server" ID="BT_Upload_Logo" Text="Mettre à jour le visuel" OnClick="BT_Upload_Logo_Click" CausesValidation="false" />
		<script>function OnClientLogoUploaded(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt2 = document.getElementById('<%=BT_Upload_Logo.ClientID %>'); bt2.click(); }</script>
        <asp:Button runat="server" ID="BT_Effacer_Logo" Text="Supprimer le visuel" OnClick="BT_Effacer_Logo_Click" CausesValidation="false" />
    </div>

    <div>
	    <h3><asp:Label runat="server" ID="Label1" Text="Fichier téléchargeable par vos visiteurs (facultatif) : " /></h3>
	    <asp:HyperLink runat="server" ID="HL_Url" Target="_blank"></asp:HyperLink>
	    <telerik:RadAsyncUpload ID="FU_Url" HideFileInput="true" DisablePlugins="true" Localization-Select="Sélectionner un fichier" MultipleFileSelection="Disabled" runat="server" OnClientFileUploaded="OnClientFileUploaded" ></telerik:RadAsyncUpload>
	    <asp:Button runat="server" ID="BT_Upload_Fichier" Text="Envoyer" OnClick="BT_Upload_Fichier_Click" CausesValidation="false"  />
	    <script>function OnClientFileUploaded(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt = document.getElementById('<%=BT_Upload_Fichier.ClientID %>'); bt.click(); }</script>
	</div>
    <div>
        <asp:Label runat="server" ID="Label4" Text="Nom visible du fichier : " />
	    <asp:TextBox runat="server" ID="TXT_Url_Texte"></asp:TextBox>
	    <asp:Button runat="server" ID="BT_Effacer_Fichier" Text="Supprimer le fichier" OnClick="BT_Effacer_Fichier_Click"  CausesValidation="false" />
	</div>

    <div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" HeaderText="Veuillez compléter le formulaire avant de valider..." ShowMessageBox="true" ShowSummary="false" />
        <asp:Button runat="server" ID="BT_Valider" Text="Valider" OnClick="BT_Valider_Click" CausesValidation="true" />
        &nbsp;
        <asp:Button runat="server" ID="BT_Annuler" Text="Annuler" OnClick="BT_Annuler_Click" CausesValidation="false" />
    </div>

</asp:Panel>








