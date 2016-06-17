<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Schedule.ascx.cs" Inherits="DesktopModules_AIS_Schedule" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<asp:GridView ID="GridView1" runat="server" CssClass="table table-striped"  
    AllowSorting="True"  GridLines="None" AllowPaging="True" PageSize="50" 
    OnPageIndexChanging="GridView1_PageIndexChanging" 
    AutoGenerateColumns="False" OnSorting="GridView1_Sorting"  >
    <Columns>
        <asp:BoundField DataField="start" HeaderText="Date" SortExpression="start"  DataFormatString="{0:d}"/>
        <asp:BoundField DataField="topic" HeaderText="Evènement" SortExpression="topic"  />
        <asp:BoundField DataField="description" HeaderText="Description"  />
    </Columns>    
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>

<asp:HiddenField ID="tri" Value="start" runat="server"/>
<asp:HiddenField ID="sens" Value="ASC" runat="server"/>



