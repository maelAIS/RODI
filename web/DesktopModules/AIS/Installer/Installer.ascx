<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->


<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Installer.ascx.cs" Inherits="test" %>

<asp:Panel runat="server" ID="pnl_start">
    <asp:Label Text="Do you want to use the installation assistant or do you want to proceed to a manual installation? " runat="server"/>
    <asp:Button ID="btn_assistant" Text="Installation assistant" runat="server" OnClick="btn_assistant_Click" />
    <!--<asp:Button ID="btn_manual" Text="Manual installation" runat="server" OnClick="btn_manual_Click" />-->
</asp:Panel>


<asp:Panel ID="pnl_friendly" runat="server" Visible="false"></asp:Panel>
<asp:Panel ID="pnl_install" runat="server" Visible="false">

    <asp:Button ID="btn_install" runat="server" OnClick="btn_install_Click" Text="Install" />
    <asp:Button ID="btn_back" runat="server" OnClick="btn_back_Click" Text="Back" />
</asp:Panel>
<asp:Panel ID="pnl_install_missing_files" runat="server" Visible="false">
    <asp:Label runat="server" Text ="Some modules are missing in your site. Do you want to install them in your site or do you want to install only what is already in your site?"></asp:Label>
    <asp:Button Text="Install anyway" ID="btn_install_anyway" runat="server" OnClick="btn_install_anyway_Click" />
    <asp:Button Text="No, go back to Home Page" runat="server" ID="btn_home" OnClick="btn_home_Click" />
</asp:Panel>



<asp:Panel ID="pnl_manuel" runat="server" Visible="false">

    <asp:Panel runat="server" ID="pnl_demande" Visible ="false">
        <asp:Label Text="Add a tab for the module?" runat="server" />
        <asp:Label runat="server" ID="lbl_module" />
        <asp:Button runat="server" ID="btn_val" Text="Yes" OnClick="btn_val_Click"/>
        <asp:Button runat="server" ID="btn_refuser" Text="No" OnClick="btn_refuser_Click" />
        <br />
        <asp:Label ID="lbl_test" runat="server"/>
        <br />
        <asp:Label ID="lbl_test2" runat="server"/>
    </asp:Panel>


    <asp:Panel ID="pnl_ajoutPage" runat="server" Visible="false">
        <asp:Panel ID="pnl_newPage" runat="server">
            <asp:Label Text="Enter the name : " runat="server" />
            <asp:TextBox ID="tbx_nom" runat="server" />
            <asp:RequiredFieldValidator ID="rfv_tbx_nom" ValidationGroup="vlg_page" runat="server" ErrorMessage="You must enter a tab name" Display="None" ControlToValidate="tbx_nom"  />
            <asp:Button ID="btn_existingPage" runat="server" Text="Existing Page" OnClick="btn_existingPage_Click" />
        </asp:Panel>
        <asp:Panel ID="pnl_existingPage" runat="server" Visible="false">
            <asp:Label Text="Page name : " runat="server" />
            <asp:DropDownList ID="ddl_pages" runat="server" OnSelectedIndexChanged="ddl_pages_SelectedIndexChanged" />
            <asp:Button ID="btn_newPage" runat="server" OnClick="btn_newPage_Click" Text="New Page" />
            <br />
        </asp:Panel>
    
        <asp:Panel ID="pnl_permissions" runat="server" >
            <br />
            <asp:Label Text="Who can see the tab ?" runat="server" />
            <asp:CheckBoxList ID="cbl_roles1" runat="server" />
            <br />
            <asp:Label Text="Who can edit the tab ?" runat="server" /> 
            <asp:CheckBoxList ID="cbl_roles2" runat="server" />
            <br />
        
        
        </asp:Panel>

        <asp:ValidationSummary ValidationGroup="vlg_page" runat="server" DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false"  />
        <asp:Button ID="btn_valider" runat="server" Text="Validate"  OnClick="btn_valider_Click" CausesValidation="true" ValidationGroup="vlg_page" />
        <asp:Button ID="btn_annuler" runat="server" Text="Cancel" OnClick="btn_annuler_Click" />
    </asp:Panel>

    <asp:Panel ID="pnl_fin" runat="server" Visible="false">
        <asp:Label Text="Your pages have been created, just like you wanted" runat="server" />
    </asp:Panel>


</asp:Panel>

    

     


<asp:Label ID="superlabel" runat="server" />