﻿<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Gestion Club.ascx.cs" Inherits="DesktopModules_AIS_Admin_Gestion_Club_Gestion_Club" %>
<script src="/AIS/TextEditor/ckeditor/ckeditor.js"></script>

<asp:Panel ID="pnl_display" runat="server">

    <asp:Button ID="btn_add" runat="server" CssClass="btn btn-primary right" Text="Ajouter un club rotaract" OnClick="btn_add_Click" />

    <asp:GridView ID="gvw_clubs" CssClass="table table-striped"  GridLines="None"  OnRowCommand="gvw_clubs_RowCommand" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Nom du club">
                <ItemTemplate>
                    <asp:Label ID="lbl_clubName" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbt_edit" runat="server" CommandArgument='<%# Bind("cric") %>' CssClass="btn btn-primary"><span class="fa fa-pencil"></span></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbt_delete" runat="server" CommandArgument='<%# Bind("cric") %>' CssClass="btn btn-danger"><span class="fa fa-trash-o"></span></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>

</asp:Panel>

<asp:Panel ID="pnl_edit" runat="server" Visible="false">
    
    <asp:HiddenField ID="hfd_cric" runat="server" />
    <h1><asp:Label ID="lbl_nomClub" runat="server"></asp:Label></h1>

    <asp:Panel ID="pnl_notRotaract" runat="server" CssClass="panel panel-danger">
        <div class="panel-heading">
            <p><strong>Certaines zones ne sont pas modifiables ici. Si vous voulez les modifier, rendez-vous sur le site du Rotarien</strong></p>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnl_rotaract" Visible="false" runat="server">
        <div class="row">
            <div class="col-sm-4">
                <strong>Nom :</strong>
            </div>
            <div class="col-sm-8">
                <asp:TextBox ID="tbx_clubRotaract" Width="500" runat="server"></asp:TextBox>
            </div>
        </div>
    </asp:Panel>
    <div class="row">
        <div class="col-sm-4">
            <strong>Adresse 1 :</strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_adr1" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Adresse 2 :</strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_adr2" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Adresse 3 :</strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_adr3" Width="500" runat="server"></asp:TextBox>
        </div>
    </div><div class="row">
        <div class="col-sm-4">
            <strong>Code postal : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_zip" Width="500" runat="server"></asp:TextBox>
        </div>
    </div><div class="row">
        <div class="col-sm-4">
            <strong>Ville : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_town" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Fanion : </strong>
        </div>
        <div class="col-sm-8">
            <asp:HiddenField ID="hfd_filename" runat="server" />
            <asp:Image ID="img_fanion" runat="server" />
            <asp:FileUpload ID="ful_img" runat="server" />
            <asp:Button ID="btn_img" runat="server" OnClick="btn_img_Click" Text="Modifier le fanion" CssClass="btn btn-primary" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Réunions : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_meetings" TextMode="MultiLine" Width="500" Height="300" runat="server"></asp:TextBox>
        </div>
        <script> CKEDITOR.replace('<%=tbx_meetings.ClientID%>', {
            uiColor: '#CCEAEE'
        });  </script>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Téléphone : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_tel" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Fax : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_fax" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Email : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_email" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Site web : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_web" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Texte de présentation : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_text" TextMode="MultiLine" Width="500" Height="300" runat="server"></asp:TextBox>
        </div>
        <script> CKEDITOR.replace('<%=tbx_text.ClientID%>', {
            uiColor: '#CCEAEE'
        });  </script>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Adresse de réunion 1 : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_meetAdr1" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Adresse de réunion 2 : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_meetAdr2" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Ville de réunion : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_meetTown" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Code postal de réunion : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_meetZip" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>

    <asp:Button ID="btn_addClub" runat="server" Text="Ajouter ou mettre à jour le club" CssClass="btn btn-primary" OnClick="btn_addClub_Click" />
    <asp:Button ID="btn_delete" runat="server"  OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer ce club ?');" Text="Supprimer le club" Visible="false" CssClass="btn btn-danger" OnClick="btn_delete_Click" />
    <asp:Button ID="btn_back" runat="server" Text="Retour" CssClass="btn btn-default" OnClick="btn_back_Click" />
    
    
</asp:Panel>