﻿<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_News_List_Control" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Label ID="test" runat="server" />

<asp:Panel ID="Panel1" runat="server">
<asp:Button runat="server" Text="Ajouter une nouvelle" ID="BT_Ajouter_News" OnClick="BT_Ajouter_News_Click" CssClass="btn btn-primary" />
<h3><asp:Label runat="server" ID="lbl_TousADG" Visible="false" Text="Choisissez un club" /></h3>
<asp:GridView ID="GridView1" runat="server" CssClass="table table-striped"  AllowSorting="True"  GridLines="None" AllowPaging="True" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" OnSorting="GridView1_Sorting">
<Columns>
    <asp:BoundField DataField="dt" HeaderText="Date" SortExpression="dt" DataFormatString="{0:d}" />
    <asp:BoundField DataField="title" HeaderText="Titre"  SortExpression="title" />
    <asp:BoundField DataField="category" HeaderText="Catégorie" SortExpression="category" />
    <asp:BoundField DataField="tag1" HeaderText="Nature" SortExpression="tag1" />
    <asp:BoundField DataField="visible" HeaderText="Visible" SortExpression="visible" />
    <asp:ButtonField ButtonType="Link" runat="server" Text="Détail" CommandName="detail" />
</Columns>    
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>
<asp:HiddenField ID="tri" Value="dt" runat="server"/><asp:HiddenField ID="sens" Value="DESC" runat="server"/>
<asp:HiddenField ID="HF_Cric" runat="server" />
</asp:Panel>
<asp:Panel ID="Panel2" runat="server" Visible="false">
<asp:HiddenField runat="server" ID="HF_id" />

<div class="Marron">
	<h2><span class="Head">Détail de la nouvelle</span></h2>
</div>

<div class="Table">
	<div class="TableCell">
		<div>
			<span>Date : </span><telerik:RadDatePicker runat="server" ID="TXT_Dt"></telerik:RadDatePicker>
		</div>
		<asp:Panel runat="server" ID="PanelSujet">
	        <span>Catégorie :</span>
            <asp:DropDownList runat="server" ID="DL_Sujet" Width="25%">
            <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>            
            <asp:ListItem Text="Action" Value="Action"></asp:ListItem>
            <asp:ListItem Text="Bulletin" Value="Bulletin"></asp:ListItem>
            <asp:ListItem Text="Conférence" Value="Conférence"></asp:ListItem>
            <asp:ListItem Text="District 1730" Value="District 1730"></asp:ListItem>
            <asp:ListItem Text="Général" Value="Général"></asp:ListItem>
            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Veuillez sélectionner une catégorie" ControlToValidate="DL_Sujet" Display="None"></asp:RequiredFieldValidator>            
	    </asp:Panel>
	    <div>
	    	<span>Visible : </span>
	    	<asp:RadioButtonList ID="RB_Visible" runat="server" RepeatDirection="Horizontal">
	    		<asp:ListItem Text="Oui" Value="O" /><asp:ListItem Text="Non" Value="N" />
	    	</asp:RadioButtonList>
	    </div>
	</div>
	
	<div class="TableCell">
		<div>
			<span>Titre : </span>
			<asp:TextBox runat="server" ID="TXT_Titre" MaxLength="255" Width="50%"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Il manque le titre" Display="None" ControlToValidate="TXT_Titre"></asp:RequiredFieldValidator>
        </div>
        <div>
        	<span>Photo : </span>
        	<asp:Image runat="server" ID="IMG_Photo" /><asp:HiddenField runat="server" ID="HF_Photo" />
        	<telerik:RadAsyncUpload ID="FU_Photo" HideFileInput="true" Localization-Select="Sélectionner une photo"  MultipleFileSelection="Disabled" runat="server" OnClientFileUploaded="OnClientPhotoUploaded" AllowedFileExtensions="jpg,jpeg,gif,png,bmp" ></telerik:RadAsyncUpload>
        	<div style="display:none">
        		<asp:Button runat="server" ID="BT_Upload_Photo" Text="Mettre à jour" OnClick="BT_Upload_Photo_Click" CausesValidation="false" />
        		<script>function OnClientPhotoUploaded(sender, args) {var contentType = args.get_fileInfo().ContentType;var bt = document.getElementById('<%=BT_Upload_Photo.ClientID %>');bt.click();}</script>
        	</div>
        	<asp:Button runat="server" ID="BT_Effacer_Photo" Text="Supprimer la photo" OnClick="BT_Effacer_Photo_Click" CausesValidation="false" CssClass="btn btn-primary" />
        </div>
        <div>
        	<span>Texte : </span>
        	<asp:TextBox runat="server" ID="TXT_Texte" TextMode="MultiLine" Rows="12" Width="75%"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Le texte n'a pas été saisi" Display="None" ControlToValidate="TXT_Texte"></asp:RequiredFieldValidator>
        </div>
        <div>
	    	<span>Fichier : </span>
	    	<asp:HyperLink runat="server" ID="HL_Url" Target="_blank"></asp:HyperLink>
	    	<telerik:RadAsyncUpload ID="FU_Url" HideFileInput="true" DisablePlugins="true" Localization-Select="Sélectionner un fichier" MultipleFileSelection="Disabled" runat="server" OnClientFileUploaded="OnClientFileUploaded" ></telerik:RadAsyncUpload>
	    	<div style="display:none">
	    		<asp:Button runat="server" ID="BT_Upload_Fichier" Text="Envoyer" OnClick="BT_Upload_Fichier_Click" CausesValidation="false"  />
	    		<script>function OnClientFileUploaded(sender, args) {var contentType = args.get_fileInfo().ContentType; var bt = document.getElementById('<%=BT_Upload_Fichier.ClientID %>');bt.click();}</script>
	    	</div>
	    </div>
	    <div>
	    	<span>Nom visible du fichier : </span>
	    	<asp:TextBox runat="server" ID="TXT_Url_Texte"></asp:TextBox>
	    	<asp:Button runat="server" ID="BT_Effacer_Fichier" Text="Supprimer le fichier" OnClick="BT_Effacer_Fichier_Click"  CausesValidation="false" CssClass="btn btn-primary" />
	        <asp:Button runat="server" ID="BT_Creer_Vignette" Text="Créer l'image du fichier" OnClick="BT_Creer_Vignette_Click" CausesValidation="false" CssClass="btn btn-primary" />
        </div>
	</div>
</div>

<div class="txtCenter">
	<asp:ValidationSummary runat="server" DisplayMode="BulletList" HeaderText="Veuillez compléter le formulaire avant de valider..." ShowMessageBox="true" ShowSummary="false" />
	<asp:Button runat="server" ID="BT_Supprimer" Text="Supprimer" CausesValidation="false" OnClick="BT_Supprimer_Click" OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer cette nouvelle ?');" CssClass="btn btn-danger" />&nbsp;
	<asp:Button runat="server" ID="BT_Valider" Text="Valider" OnClick="BT_Valider_Click" CssClass="btn btn-primary" />&nbsp;<asp:Button runat="server" ID="BT_Annuler" Text="Retour" OnClick="BT_Annuler_Click" CausesValidation="false" CssClass="btn btn-default" />
</div>
</asp:Panel>


