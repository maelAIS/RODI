<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InstallerSettings.ascx.cs" Inherits="InstallerSettings" %>

<asp:Label ID="Label3" runat="server" Text="Path to Modules.xml :"></asp:Label>&nbsp;
<asp:TextBox ID="tbx_module" Text="C:\\inetpub\\wwwroot\\DNN\\DesktopModules\\AIS\\Installer\\Modules.xml" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label1" runat="server" Text="Path to Roles.xml :"></asp:Label>&nbsp;
<asp:TextBox ID="tbx_roles" Text="C:\\inetpub\\wwwroot\\DNN\\DesktopModules\\AIS\\ListeInterventions\\Roles.xml" runat="server"></asp:TextBox>

<asp:CheckBoxList ID="cbl_modules" runat="server" />
