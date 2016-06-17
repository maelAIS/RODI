<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Order_Paiement_Control" %>
<asp:HiddenField runat="server" ID="HF_id" />
<div>
	<asp:Label runat="server" Text="Règlement de la commande n°"></asp:Label>
	<asp:Label ID="TXT_id" runat="server" Text="..."></asp:Label>
	<asp:Label ID="Label5" runat="server" Text=" du "></asp:Label>
	<asp:Label ID="TXT_dt" runat="server" Text="..."></asp:Label>
	<asp:Label ID="Label2" runat="server" Text="d'un montant de "></asp:Label>
	<asp:Label ID="TXT_montant" runat="server" Text="..."></asp:Label>
	<asp:Label ID="Label3" runat="server" Text="pour le club de "></asp:Label>
	<asp:Label ID="TXT_club" runat="server" Text="..."></asp:Label><br />
	<asp:Label ID="Label4" runat="server" Text="Détail de la commande : "></asp:Label>
	<asp:HyperLink ID="HL_Detail" runat="server" Target="_blank" Text="Télécharger"></asp:HyperLink>
</div>

<asp:Panel runat="server" Visible="true" ID="p_default">
	<asp:Label ID="Label1" runat="server" Text="Choisissez le moyen de paiement :"></asp:Label>
	<asp:RadioButtonList ID="RB_Moyen_Paiement" runat="server" OnSelectedIndexChanged="RB_Moyen_Paiement_SelectedIndexChanged" AutoPostBack="true">
	    <asp:ListItem Text="Chèque" Value="cheque"></asp:ListItem>
	    <asp:ListItem Text="Virement" Value="virement"></asp:ListItem>
	</asp:RadioButtonList>
</asp:Panel>

<asp:Panel runat="server" ID="P_valider" Visible="false">
    <asp:Button ID="BT_Valider" runat="server" Text="Valider le paiement" OnClick="BT_Valider_Click" />
</asp:Panel>

<asp:Panel runat="server" ID="P_virement_ok" Visible="false">
    Le trésorier du district validera le paiement à réception du virement.<br />
    N&#39;oubliez pas d&#39;indiquer le n° de commande dans le libellé du virement.<br />
    <br />Les coordonnées bancaires sont dans le document de détail de la commande.
</asp:Panel>

<asp:Panel runat="server" ID="P_cheque_ok" Visible="false">
    Le trésorier du district validera le paiement à réception du chèque.<br />
    N&#39;oubliez pas d&#39;indiquer le n° de commande au dos du chèque.<br />
    <br />L'ordre et l'adresse à laquelle il faut expédier le chèque est indiqué dans le document de détail de la commande.
</asp:Panel>

<asp:Panel runat="server" ID="P_cb_ok" Visible="false">    
    <asp:Literal runat="server" ID="TXT_mercanet"></asp:Literal>
</asp:Panel>