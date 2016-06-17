﻿<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Presidents View.ascx.cs" Inherits="DesktopModules_AIS_Presidents_View_Presidents_View" %>

<div class="panel panel-default panel-body" >
    <div class="row text-center">
        Année rotarienne : <asp:DropDownList ID="ddl_rotaryYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_rotaryYear_SelectedIndexChanged" ></asp:DropDownList>
    </div>
    <div class="pe-spacer size20"></div>

    <div class="row text-center">
   
        <asp:DataList ID="dataList_Members" runat="server" OnItemDataBound="dataList_Members_ItemDataBound" Width="100%" RepeatLayout="Flow" CssClass="MiniTrombi row" ItemStyle-CssClass="col-sm-4">
            <ItemTemplate>
                    <div class="panel panel-default">
		                <div class="panel-body">
	                        <asp:Image ID="Image1" runat="server" />
	                        <div>
	                        <asp:Label ID="lbl_Fonction" runat="server" />
	                        <p><strong><asp:Label ID="LBL_Nom" runat="server"></asp:Label></strong></p>
	                        <p><asp:Label ID="LBL_Club" runat="server"></asp:Label></p>
	                        <p><asp:HyperLink ID="HL_Contact" runat="server">Le contacter</asp:HyperLink></p>
	                        </div>
	                    </div>
                    </div>
                </ItemTemplate> 
        </asp:DataList>
    </div>
</div>