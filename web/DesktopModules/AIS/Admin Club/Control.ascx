<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Club_Control" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Label ID="test" runat="server" />
<asp:Label runat="server" ID="lbl_noClub" Text="Choisissez un club " Visible="false" />
<asp:Panel runat="server" ID="P1" >
    <p><asp:Label runat="server"  Text="Nom : " Width="150px" ID="lblnom" /><asp:Label runat="server" ID="LBL_Nom" Text="Nom : " /></p>
    
    <asp:Panel ID="pnl_Club" runat="server" Visible="false">


        <p><asp:Label ID="lbl_nom2" Width="150px" runat="server"  Text="Nom * : " /><asp:TextBox runat="server" ID="tbx_nom" Width="400px" MaxLength="255"  /><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="" ControlToValidate="tbx_nom" Width="20px"></asp:RequiredFieldValidator></p>
        <p><asp:Label ID="lbl_adresse1" Width="150px" runat="server"  Text="Adresse * : " /><asp:TextBox runat="server" ID="tbx_adresse1" Width="400px" MaxLength="255"  /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="tbx_adresse1" Width="20px"></asp:RequiredFieldValidator></p>
        <p><asp:Label ID="lbl_adresse2" Width="150px" runat="server"  Text="Complément 1 : " /><asp:TextBox runat="server" ID="tbx_adresse2" Width="400px" MaxLength="255"  /></p>
        <p><asp:Label ID="lbl_adresse3" Width="150px" runat="server"  Text="Complément 2 : " /><asp:TextBox runat="server" ID="tbx_adresse3" Width="400px" MaxLength="255"  /></p>
        <p><asp:Label ID="lbl_cp" Width="150px" runat="server"  Text="CP * : " /><asp:TextBox runat="server" ID="tbx_cp" Width="400px" MaxLength="50"  /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" ControlToValidate="tbx_cp" Width="20px"></asp:RequiredFieldValidator></p>
        <p><asp:Label ID="lbl_ville" Width="150px" runat="server"  Text="Ville * : " /><asp:TextBox runat="server" ID="tbx_ville" Width="400px" MaxLength="255"  /><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="" ControlToValidate="tbx_ville" Width="20px"></asp:RequiredFieldValidator></p>
        <p><asp:Label ID="lbl_telephone" Width="150px" runat="server"  Text="Téléphone : " /><asp:TextBox runat="server" ID="tbx_telephone" Width="400px" MaxLength="50"  /></p>
        <p><asp:Label ID="lbl_fax" Width="150px" runat="server"  Text="Fax : " /><asp:TextBox runat="server" ID="tbx_fax" Width="400px" MaxLength="50"  /></p>
        <p><asp:Label ID="lbl_email" Width="150px" runat="server"  Text="Email : " /><asp:TextBox runat="server" ID="tbx_email" Width="400px" MaxLength="255"  /></p>
        <p><asp:Label ID="lbl_seo" Width="150px" runat="server"  Text="Seo : " /><asp:TextBox runat="server" ID="tbx_seo" Width="400px" MaxLength="255"  /></p>
        <p><asp:Label ID="lbl_url" Width="150px" runat="server"  Text="URL du site web : " /><asp:TextBox runat="server" ID="tbx_url" Width="400px" MaxLength="255"  /></p>
        <p><asp:Label ID="lbl_anciens_presidents" Width="150px" runat="server"  Text="Anciens présidents : " /><asp:TextBox runat="server" ID="tbx_anciens_presidents" TextMode="MultiLine" Rows="5" Width="400px" Wrap="true"  /></p>

        
    </asp:Panel>

    

    <p><asp:Label ID="Label1" runat="server"  Text="Texte de présentation du club : " /></p>
    <p><telerik:RadEditor runat="server" ID="TXT_Texte" ToolsFile="~/DesktopModules/AIS/Admin Club/XMLFile.xml" style="width:100%;" >                 
    </telerik:RadEditor></p>        

    <p><asp:Label ID="Label2" runat="server"  Text="Réunions : " /></p>
    <p><telerik:RadEditor runat="server" ID="TXT_Reunions" ToolsFile="~/DesktopModules/AIS/Admin Club/XMLFile.xml" style="width:100%;" >                 
    </telerik:RadEditor></p>

    <p><asp:Label ID="Label9" runat="server"  Text="URL du site web : " /><asp:TextBox runat="server" ID="TXT_Url" Width="400px" MaxLength="255"  /></p>

    <div>
        <asp:Label runat="server" ID="Label10" Text="Fanion : "  Width="150px" />
        <asp:Image runat="server" ID="IMG_Logo" />
        <asp:HiddenField runat="server" ID="HF_Logo" />
        <telerik:RadAsyncUpload ID="FU_Logo" HideFileInput="true" Localization-Select="Sélectionner un fanion"  MultipleFileSelection="Disabled" runat="server" OnClientFileUploaded="OnClientLogoUploaded" AllowedFileExtensions="jpg,jpeg,gif,png,bmp" ></telerik:RadAsyncUpload>
        
        <div style="display:none">
        	<asp:Button runat="server" ID="BT_Upload_Logo" CssClass="btn btn-primary" Text="Mettre à jour" OnClick="BT_Upload_Logo_Click" CausesValidation="false" />
        	<script>function OnClientLogoUploaded(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt2 = document.getElementById('<%=BT_Upload_Logo.ClientID %>'); bt2.click(); }</script>
        </div>
        <asp:Button runat="server" ID="BT_Effacer_Logo" CssClass="btn btn-danger" Text="Supprimer le fanion" OnClick="BT_Effacer_Logo_Click" CausesValidation="false" />
    </div>

    <asp:Panel ID="pnl_Reunion" runat="server" Visible="false">
        <p><asp:Label ID="Label3" Width="150px" runat="server"  Text="Adresse : " /><asp:TextBox runat="server" ID="TXT_Reunion_Adr1" Width="400px" MaxLength="255"  /></p>
        <p><asp:Label ID="Label4" Width="150px" runat="server"  Text="Complément : " /><asp:TextBox runat="server" ID="TXT_Reunion_Adr2" Width="400px" MaxLength="255"  /></p>
        <p><asp:Label ID="Label5" Width="150px" runat="server"  Text="CP : " /><asp:TextBox runat="server" ID="TXT_Reunion_CP" Width="400px" MaxLength="50"  /></p>
        <p><asp:Label ID="Label6" Width="150px" runat="server"  Text="Ville : " /><asp:TextBox runat="server" ID="TXT_Reunion_Ville" Width="400px" MaxLength="255"  /></p>
        <p><asp:Label ID="Label7" Width="150px"  runat="server"  Text="Latitude : " /><telerik:RadNumericTextBox Height="30px" runat="server" ID="TXT_Latitude" Width="415px" MaxLength="20" NumberFormat-DecimalSeparator="." NumberFormat-DecimalDigits="10"  /></p>
        <p><asp:Label ID="Label8" Width="150px" runat="server"  Text="Longitude : " /><telerik:RadNumericTextBox Height="30px" runat="server" ID="TXT_Longitude" Width="415px" MaxLength="20" NumberFormat-DecimalSeparator="." NumberFormat-DecimalDigits="10"  /></p>
    </asp:Panel>

    <asp:HiddenField ID="HF_Nb_Member" runat="server" />
    <asp:HiddenField ID="HF_Cric" runat="server" /><br />
    

    <p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="SingleParagraph"  HeaderText="Les champs nom, adresse, code postal et ville sont obligatoires!" ShowMessageBox="true" ShowSummary="false" />

        <asp:Button ID="BT_Valider" runat="server" CssClass="btn btn-primary"  Text="Valider" OnClientClick="javascript: return confirm('Valider les changements ?');" OnClick="BT_Valider_Click" CausesValidation="true" />
        <asp:Button ID="BT_Ajout" runat="server"  Text="Ajouter" CssClass="btn btn-primary" ToolTip="Ajouter un club rotaract"  OnClick="BT_Ajout_Click" CausesValidation="true" />
        <asp:Button ID="BT_Supprimer" runat="server" Text="Supprimer" CssClass="btn btn-danger" OnClientClick="javascript: return ConfirmDelete();" OnClick="BT_Supprimer_Click" CausesValidation="false" />
        <asp:Button ID="BT_Presentation" runat="server" Text="Personnaliser la page du club" OnClick="BT_Presentation_Click" CssClass="btn btn-default" CausesValidation="false" />
    </p>

    

    <script type="text/javascript">
        function ConfirmDelete() { return confirm("<%=HF_Nb_Member.Value%>");}
        function AfficheValider() { obj = document.getElementById("<%=BT_Valider.ClientID%>").style; obj.visibility = 'visible'; }
    </script>

</asp:Panel>