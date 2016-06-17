<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Import Rotarien.ascx.cs" Inherits="DesktopModules_AIS_Admin_Import_Rotarien_Import_Rotarien" %>

<asp:Panel ID="pnl_grid" runat="server" >

    <asp:Label Text="Dernière mise à jour : " runat="server" />
    <asp:Label ID="lbl_derniereMaj" runat="server" /> 
    <br />
    <br />
    <p></p><asp:Label Text="Recherche : " runat="server" />
    <asp:TextBox ID="tbx_filtre" runat="server" />
    <asp:Button CssClass="btn btn-primary" ID="btn_filtre" runat="server" Text="Valider" OnClick="btn_filtre_Click" /></p>
    <br />
    <asp:HiddenField ID="hfd_nim" runat="server" />
    <asp:GridView ID="gvw_importRotarien" CssClass="table table-striped" OnRowCommand="gvw_importRotarien_RowCommand" AllowPaging="true" PageSize="50" OnPageIndexChanging="gvw_importRotarien_PageIndexChanging" runat="server" AutoGenerateColumns="false" AllowSorting="false" OnRowDataBound="gvw_importRotarien_RowDataBound">

        <Columns>

            <asp:TemplateField HeaderText="NIM">
                <ItemTemplate>
                    <asp:Label ID="lbl_nim" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Nom">
                <ItemTemplate>
                    <asp:Label ID="lbl_civilite" runat="server" />
                    <asp:Label ID="lbl_nom" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Prenom" >
                <ItemTemplate>
                    <asp:Label ID="lbl_prenom" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Statut" >
                <ItemTemplate>
                    <asp:Label ID="lbl_radie" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Dernière mise à jour">
                <ItemTemplate>
                    <asp:Label ID="lbl_dtMaj" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField >
                <ItemTemplate>
                    <asp:LinkButton ID="lbt_details" CommandArgument='<%#Eval ("nim") %>' runat="server" Text="Détails" OnClick="lbt_details_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        
        </Columns>
        <EmptyDataTemplate>Aucun membre correspondant</EmptyDataTemplate>
        
    </asp:GridView>
        


</asp:Panel>



<asp:Panel ID="pnl_membre" runat="server" Visible="false">
    <h2><asp:Label Text="Détails du membre" runat="server"></asp:Label></h2>
    <div class="DNNModuleContent ModAISMembreC">
            
           <p><span> <asp:Image Width="120" ID="img_membre" runat="server" /> </span> </p>
           
           <p><span> <asp:Label  Font-Size="12" Text="NIM : " runat="server" />
           <asp:Label  Font-Size="12" ID="lbl_nim" runat="server"/> </span> </p>
           <p><span><asp:Label Font-Size="12" Text="Titre :" runat="server" />
               <asp:Label Font-Size="12" ID="lbl_titre" runat="server" /></span></p>
           <p><span> <asp:Label  Font-Size="12" ID="lbl_membreHonneur" runat="server" />
            <asp:Label Font-Size="12"  ID="lbl_civilite" runat="server" />
            <asp:Label Font-Size="12" ID="lbl_prenom" runat="server" /> 
            <asp:Label Font-Size="12" ID="lbl_nom" runat="server" /></span> </p>
    </div> 
    <br />
    <div>
        <h3>Infos professionnelles</h3>
    
        <asp:Label ID="lbl_membreActif" runat="server" />
        <asp:Label ID="lbl_radie" runat="server" />
        <asp:Label Text="du club" runat="server" />
        <asp:Label ID="lbl_nomClub" runat="server" />
        <asp:Label ID="lbl_cric" runat="server" />
        <br />
        <asp:Label Text="Membre du District" runat="server" />
        <asp:Label ID="lbl_district_id" runat="server" />
        <br />
        <asp:Label Text="Adhésion en :" runat="server" />
        <asp:Label ID="lbl_anneeAdhesionRotary" runat="server" />
        <br />
        <asp:Label Text="Fonction/Métier :" runat="server" />
        <asp:Label ID="lbl_fonctionMetier" runat="server" />
        <asp:Label ID="lbl_brancheMetier" runat="server" />
        <br />
        <h4>Coordonnées professionnelles</h4>
        <asp:Label Text="Adresse : " runat="server" />
        <asp:Label ID="lbl_adresseProfessionnelle" runat="server" />
        <br />
        <asp:Label Text="Ville : " runat="server" />
        <asp:Label ID="lbl_villeProfessionnelle" runat="server" />
        <asp:Label ID="lbl_codePostalProfessionnel" runat="server" />
        <br />
        <asp:Label Text="Téléphone : " runat="server" />
        <asp:Label ID="lbl_telProfessionnel" runat="server" />
        &nbsp
        <asp:Label Text="Portable : " runat="server" />
        <asp:Label ID="lbl_portableProfessionnel" runat="server" />
        <br />
        <asp:Label Text="Fax : " runat="server" />
        <asp:Label ID="lbl_faxProfessionnel" runat="server" />
        <br />
        <asp:Label Text="Email : " runat="server" />
        <asp:Label ID="lbl_emailProfessionnel" runat="server" />
    </div>
    <div>
        <h3>Infos personnelles</h3>
        <asp:Label ID="lbl_retraite" runat="server" />
        <br />
        <asp:Label Text="Biographie :" runat="server" />
        <asp:Label ID="lbl_biographie" runat="server" />
        <br/>
        <asp:Label ID="nomjeunefille" Text="Nom de jeune fille :" runat="server" />
        <asp:Label ID="lbl_nomJeuneFille" runat="server" />
        <br />
        <asp:Label Text="Conjoint(e) :" runat="server" />
        <asp:Label ID="lbl_prenomConjoint" runat="server" />
        <br />
        <asp:Label Text="Né(e) en :" runat="server" />
        <asp:Label ID="lbl_anneeNaissance" runat="server" />
        <div>
            <h4>Coordonnées personnelles</h4>
            <asp:Label Text="Email :" runat="server" />
            <asp:Label ID="lbl_email" runat="server" />
            <br />
            <asp:Label Text="Adresse :" runat="server" />
            <asp:Label ID="lbl_adresse1" runat="server" />
            <asp:Label ID="lbl_adresse2" runat="server" />
            <asp:Label ID="lbl_adresse3" runat="server" />
            <br />
            <asp:Label Text="Pays :" runat="server" />
            <asp:Label ID="lbl_pays" runat="server" />
            <br />
            <asp:Label Text="Ville :" runat="server" />
            <asp:Label ID="lbl_ville" runat="server" />
            <asp:Label ID="lbl_codePostal" runat="server" />
            <br />
            <asp:Label Text="Téléphone :" runat="server" />
            <asp:Label ID="lbl_telephone" runat="server" />
            <br />
            <asp:Label Text="Fax :" runat="server" />
            <asp:Label ID="lbl_fax" runat="server" />
            <br />
            <asp:Label Text="GSM :" runat="server" />
            <asp:Label ID="lbl_gsm" runat="server" />

        </div>
        
        
        <asp:Label CssClass="right" ID="lbl_dateMaj_Base" runat="server" />
        
   </div>

    <asp:Button CssClass="btn btn-primary" Text="Retour" ID="btn_retour" runat="server" OnClick="btn_retour_Click" />
</asp:Panel>

