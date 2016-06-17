﻿<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Maj_AAR_Control" %>


<asp:Button ID="BT_Maj" runat="server" Text="Créer les users" OnClick="BT_Maj_Click" Visible="false" CssClass="btn btn-primary"/>
<asp:Button ID="BT_Refresh_AAR" runat="server" Text="Mettre à jour les affectations" OnClick="BT_Refresh_AAR_Click" CssClass="btn btn-primary" />&nbsp;<asp:Button ID="BT_CreateUsersManquants" runat="server" Text="Créer les utilisateurs manquants" OnClick="BT_CreateUsersManquants_Click" CssClass="btn btn-primary" />
<asp:Button ID="BT_CorrigerSEOClubs" runat="server" Text="Corriger SEO Clubs" OnClick="BT_CorrigerSEOClubs_Click" CssClass="btn btn-primary"></asp:Button>

<br />
<br />

<asp:Panel ID="pnl_error" Visible="false" runat="server" CssClass="panel panel-danger">
    <div class="panel-heading"><p>Une erreur est survenue lors de l'opération!</p></div>
</asp:Panel>
<asp:Panel ID="pnl_success" runat="server" CssClass="panel panel-success" Visible="false">
    <div class="panel-heading"><p>L'opération s'est bien effectuée</p></div>
</asp:Panel>


<asp:Literal ID="TXT_Result" runat="server"></asp:Literal>
