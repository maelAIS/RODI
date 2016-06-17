
#region Copyrights

// RODI - http://rodi.aisdev.net
// Copyright (c) 2012-2016
// by SAS AIS : http://www.aisdev.net
// supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730)
//
//GNU LESSER GENERAL PUBLIC LICENSE
//Version 3, 29 June 2007 Copyright (C) 2007
//Free Software Foundation, Inc. <http://fsf.org/> Everyone is permitted to copy and distribute verbatim copies of this license document, but changing it is not allowed.
//This version of the GNU Lesser General Public License incorporates the terms and conditions of version 3 of the GNU General Public License, supplemented by the additional permissions listed below.

//0. Additional Definitions.

//As used herein, "this License" refers to version 3 of the GNU Lesser General Public License, and the "GNU GPL" refers to version 3 of the GNU General Public License.
//"The Library" refers to a covered work governed by this License, other than an Application or a Combined Work as defined below.
//An "Application" is any work that makes use of an interface provided by the Library, but which is not otherwise based on the Library.Defining a subclass of a class defined by the Library is deemed a mode of using an interface provided by the Library.
//A "Combined Work" is a work produced by combining or linking an Application with the Library. The particular version of the Library with which the Combined Work was made is also called the "Linked Version".
//The "Minimal Corresponding Source" for a Combined Work means the Corresponding Source for the Combined Work, excluding any source code for portions of the Combined Work that, considered in isolation, are based on the Application, and not on the Linked Version.
//The "Corresponding Application Code" for a Combined Work means the object code and/or source code for the Application, including any data and utility programs needed for reproducing the Combined Work from the Application, but excluding the System Libraries of the Combined Work.

//1. Exception to Section 3 of the GNU GPL.

//You may convey a covered work under sections 3 and 4 of this License without being bound by section 3 of the GNU GPL.

//2. Conveying Modified Versions.

//If you modify a copy of the Library, and, in your modifications, a facility refers to a function or data to be supplied by an Application that uses the facility (other than as an argument passed when the facility is invoked), then you may convey a copy of the modified version:
//a) under this License, provided that you make a good faith effort to ensure that, in the event an Application does not supply the function or data, the facility still operates, and performs whatever part of its purpose remains meaningful, or
//b) under the GNU GPL, with none of the additional permissions of this License applicable to that copy.

//3. Object Code Incorporating Material from Library Header Files.

//The object code form of an Application may incorporate material from a header file that is part of the Library. You may convey such object code under terms of your choice, provided that, if the incorporated material is not limited to numerical parameters, data structure layouts and accessors, or small macros, inline functions and templates(ten or fewer lines in length), you do both of the following:
//a) Give prominent notice with each copy of the object code that the Library is used in it and that the Library and its use are covered by this License.
//b) Accompany the object code with a copy of the GNU GPL and this license document.

//4. Combined Works.

//You may convey a Combined Work under terms of your choice that, taken together, effectively do not restrict modification of the portions of the Library contained in the Combined Work and reverse engineering for debugging such modifications, if you also do each of the following:
//a) Give prominent notice with each copy of the Combined Work that the Library is used in it and that the Library and its use are covered by this License.
//b) Accompany the Combined Work with a copy of the GNU GPL and this license document.
//c) For a Combined Work that displays copyright notices during execution, include the copyright notice for the Library among these notices, as well as a reference directing the user to the copies of the GNU GPL and this license document.
//d) Do one of the following:
//0) Convey the Minimal Corresponding Source under the terms of this License, and the Corresponding Application Code in a form suitable for, and under terms that permit, the user to recombine or relink the Application with a modified version of the Linked Version to produce a modified Combined Work, in the manner specified by section 6 of the GNU GPL for conveying Corresponding Source.
//1) Use a suitable shared library mechanism for linking with the Library. A suitable mechanism is one that (a) uses at run time a copy of the Library already present on the user's computer system, and (b) will operate properly with a modified version of the Library that is interface-compatible with the Linked Version.
//e) Provide Installation Information, but only if you would otherwise be required to provide such information under section 6 of the GNU GPL, and only to the extent that such information is necessary to modules and execute a modified version of the Combined Work produced by recombining or relinking the Application with a modified version of the Linked Version. (If you use option 4d0, the Installation Information must accompany the Minimal Corresponding Source and Corresponding Application Code. If you use option 4d1, you must provide the Installation Information in the manner specified by section 6 of the GNU GPL for conveying Corresponding Source.)

//5. Combined Libraries.

//You may place library facilities that are a work based on the Library side by side in a single library together with other library facilities that are not Applications and are not covered by this License, and convey such a combined library under terms of your choice, if you do both of the following:
//a) Accompany the combined library with a copy of the same work based on the Library, uncombined with any other library facilities, conveyed under the terms of this License.
//b) Give prominent notice with the combined library that part of it is a work based on the Library, and explaining where to find the accompanying uncombined form of the same work.

//6. Revised Versions of the GNU Lesser General Public License.

//The Free Software Foundation may publish revised and/or new versions of the GNU Lesser General Public License from time to time. Such new versions will be similar in spirit to the present version, but may differ in detail to address new problems or concerns.
//Each version is given a distinguishing version number. If the Library as you received it specifies that a certain numbered version of the GNU Lesser General Public License "or any later version" applies to it, you have the option of following the terms and conditions either of that published version or of any later version published by the Free Software Foundation. If the Library as you received it does not specify a version number of the GNU Lesser General Public License, you may choose any version of the GNU Lesser General Public License ever published by the Free Software Foundation.
//If the Library as you received it specifies that a proxy can decide whether future versions of the GNU Lesser General Public License shall apply, that proxy's public statement of acceptance of any version is permanent authorization for you to choose that version for the Library.

#endregion Copyrights

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.Security.Permissions;
using DotNetNuke.Entities.Modules.Definitions;
using System.Collections;
using DotNetNuke.Security.Roles;
using DotNetNuke.Entities.Users;
using AIS;

public partial class test : PortalModuleBase
{
    List<DesktopModuleInfo> list = new List<DesktopModuleInfo>();
    static int position=0;


    DotNetNuke.Entities.Modules.ModuleController objModules2 = new DotNetNuke.Entities.Modules.ModuleController();

    String Modules
    {
        get
        {
            String t = "" + objModules2.GetModuleSettings(ModuleId)["modules"];
            return t;
        }
    }

    String Roles
    {
        get
        {
            String t = "" + objModules2.GetModuleSettings(ModuleId)["roles"];
            return t;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            PortalSettings portalSettings = new PortalSettings();
            int portalId = portalSettings.PortalId;
            //Getting the controls we will use
            

            //If the list is empty, we fill it
            if (list.Count==0)
            {
                fillList();
            }
            if(!IsPostBack)
            {
                CreateRoles();
                BindCheckBoxList();
                if (position < list.Count)
                {
                    pnl_demande.Visible = true;
                    Label module = (Label)FindControl("lbl_module");
                    module.Text = list.ElementAt(position).FriendlyName;
                }
                if (list.Count == 0)
                {
                    pnl_demande.Visible = false;
                    pnl_fin.Visible = true;
                }
                else
                {
                    pnl_demande.Visible = true;
                    position = 0;
                    Label module = (Label)FindControl("lbl_module");
                    module.Text = list.ElementAt(position).FriendlyName;
                }
            }
        }
        catch(Exception exc)
        {
           // superlabel.Text += exc.Message;//"Error, see the event log for more informations";
        }
    }

    #region Button events
    protected void btn_valider_Click(object sender, EventArgs e)
    {
        try
        {
            //Checking if the addition was successful
            if (AddModuleToPage(list.ElementAt(position).FriendlyName))
            {
                superlabel.Text = "";
                pnl_ajoutPage.Visible = false;
                fillList();
                if (position < list.Count)
                {
                    
                    lbl_module.Text = list.ElementAt(position).FriendlyName;
                    pnl_demande.Visible = true;
                }
                else
                    pnl_fin.Visible = true;
            }
            else
                superlabel.Text += "An error occured during the tab creation. Maybe it already exists in the bin. Please, make sure to restore it or delete it permanently";
        }

        catch(Exception exception)
        {
           // superlabel.Text += "An error occured during the tab creation. Maybe it already exists in the bin. Please, make sure to restore it or delete it permanently";
        }
    }

    protected void btn_val_Click(object sender, EventArgs e)
    {
        pnl_ajoutPage.Visible = true;
        pnl_demande.Visible = false;
    }

    protected void btn_refuser_Click(object sender, EventArgs e)
    {
        position++;
        if (position < list.Count)
        {
            Label module = (Label)FindControl("lbl_module");
            module.Text = list.ElementAt(position).FriendlyName;
        }
        else
        {
            pnl_demande.Visible = false;
            pnl_fin.Visible = true;


        }

    }

    protected void btn_annuler_Click(object sender, EventArgs e)
    {
        superlabel.Text = "";
        pnl_ajoutPage.Visible = false;
        pnl_demande.Visible = true;


    }

    protected void btn_existingPage_Click(object sender, EventArgs e)
    {
        pnl_newPage.Visible = false;
        pnl_existingPage.Visible = true;
        BindDDL();
        tbx_nom.Text = ddl_pages.SelectedValue;
        pnl_permissions.Visible = false;
    }

    protected void btn_newPage_Click(object sender, EventArgs e)
    {
        pnl_newPage.Visible = true;
        pnl_existingPage.Visible = false;
        pnl_permissions.Visible = true;
    }
    #endregion Button events

    #region Binds

    protected void BindCheckBoxList()
    {
        PortalSettings portalSettings = new PortalSettings();
        int portalId = portalSettings.PortalId;

        RoleController rc = new RoleController();

        foreach (RoleInfo ri in rc.GetRoles(portalId))
        {
            cbl_roles1.Items.Add(ri.RoleName);
            cbl_roles2.Items.Add(ri.RoleName);
        }
    }

    protected void BindDDL()
    {
        PortalSettings portalSettings = new PortalSettings();
        int portalId = portalSettings.PortalId;
        TabController tabController = new TabController();

        List<string> src = new List<string>();
        foreach (TabInfo ti in tabController.GetTabsByPortal(portalId).Values)
        {
            if (!ti.IsDeleted)
                src.Add(ti.TabName);
        }

        ddl_pages.DataSource = src;
        ddl_pages.DataBind();
    }

    #endregion Binds

    #region Roles
    /// <summary>
    /// Here we create the roles written in the xml file
    /// </summary>
    protected void CreateRoles()
    {
        try
        {
            PortalSettings portalSettings = new PortalSettings();
            int portalId = portalSettings.PortalId;
            RoleController rc = new RoleController();

            System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(Server.MapPath("DesktopModules/AIS/Installer/Modules.xml")/*"C:\\inetpub\\wwwroot\\DNN\\DesktopModules\\AIS\\ListeInterventions\\Roles.xml"*/);
            while (reader.Read())
            {
                reader.MoveToContent();
                if(reader.Name=="role")
                {
                    RoleInfo ri = new RoleInfo();
                    ri.PortalID = portalId;
                    ri.AutoAssignment = false;
                    ri.Status = RoleStatus.Approved;
                    if (reader.HasAttributes)
                    {
                        if (reader.GetAttribute("name") != "")
                            ri.RoleName = reader.GetAttribute("name");
                        if (reader.GetAttribute("groupID") != "")
                            ri.RoleGroupID = int.Parse(reader.GetAttribute("groupID"));
                        if (reader.GetAttribute("public") != "")
                            ri.IsPublic = bool.Parse(reader.GetAttribute("public"));
                    }
                    //Don't add existing roles
                    if (!RoleExists(ri))
                        rc.AddRole(ri);
                        
                }
            }
            

        }
        catch (Exception exc)
        {
            //superlabel.Text += "An error occured, please see the event log or contact an administrator for more informations";
        }
    }

    /// <summary>
    /// Checking if the role exists
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public bool RoleExists(RoleInfo role)
    {
        PortalSettings portalSettings = new PortalSettings();
        int portalId = portalSettings.PortalId;
        RoleController rc = new RoleController();
        foreach(RoleInfo ri in rc.GetRoles(portalId))
        {
            if (ri.RoleGroupID == role.RoleGroupID && ri.RoleName == role.RoleName)
                return true;
        }
        return false;
    }
    #endregion Roles


    #region Manual
    /// <summary>
    /// Check if the module has been activated somewhere
    /// </summary>
    /// <param name="dmi"></param>
    /// <returns></returns>
    public bool IsInPage(DesktopModuleInfo dmi)
    {
        PortalSettings portalSettings = new PortalSettings();
        int portalId = portalSettings.PortalId;
        TabController TC = new TabController();
        
        foreach(TabInfo ti in TC.GetTabsByPortal(portalId).Values)
        {
            //We don't look for deleted pages
            if(!ti.IsDeleted)
            {
                foreach (ModuleInfo mi in ti.ChildModules.Values)
                {
                    if (mi.FriendlyName == dmi.FriendlyName && mi.DesktopModuleID == dmi.DesktopModuleID && !mi.IsDeleted /*The module is not activated if it is deleted*/)
                    {
                        return true;
                    }

                }
            }
            
        }
        return false;
        
        

    }

    /// <summary>
    /// Add the module to a page
    /// </summary>
    /// <param name="friendlyNameModule"></param>
    /// <returns></returns>
    protected bool AddModuleToPage(String friendlyNameModule)
    {

        TextBox tbx = (TextBox)FindControl("tbx_nom");
        PortalSettings portalSettings = new PortalSettings();
        int portalId = portalSettings.PortalId;

        //Creating page
        TabController tabController = new TabController();

        TabInfo tab = null;
        //Checking if the page already exists
        if (!tabController.GetTabsByPortal(portalId).Values.Contains(tabController.GetTabByName(tbx.Text, portalId)))
        {
            tab = new TabInfo();
            tab.PortalID = portalId;
            tab.TabName = tbx.Text;
            tab.Title = tbx.Text;
            tab.Description = tbx.Text;
            tab.KeyWords = tbx.Text;
            tab.IsVisible = true;
            tab.DisableLink = false;
            tab.IsDeleted = false;
            tab.Url = "";
            tab.IsSuperTab = true;

            AddPermissionsOnTab(tab);
            int tabId = tabController.AddTab(tab, false);
            tbx.Text = "";
            
        }
        else if (!tabController.GetTabByName(tbx.Text, portalId).IsDeleted)
        {
            tab = tabController.GetTabByName(tbx.Text, portalId);
        }
        else
        {
            return false;
        }
        
        DesktopModuleInfo desktopModuleInfo = null;
        foreach (KeyValuePair<int, DesktopModuleInfo> kvp in DesktopModuleController.GetDesktopModules(portalId))
        {
            DesktopModuleInfo mod = kvp.Value;
            if (mod != null)
                if ((mod.FriendlyName == friendlyNameModule || mod.ModuleName == friendlyNameModule) && (mod.FriendlyName != "AIS_Installer" || mod.ModuleName != "AIS.Installer"))
                {
                    desktopModuleInfo = mod;
                }
        }
        
        if (desktopModuleInfo != null && tab!=null)
        {
            foreach (ModuleDefinitionInfo moduleDefinitionInfo in ModuleDefinitionController.GetModuleDefinitionsByDesktopModuleID(desktopModuleInfo.DesktopModuleID).Values)
            {
                ModuleInfo moduleInfo = new ModuleInfo();
                moduleInfo.PortalID = portalId;
                moduleInfo.TabID = tab.TabID;
                moduleInfo.ModuleOrder = 1;
                moduleInfo.ModuleTitle = desktopModuleInfo.FriendlyName;
                moduleInfo.PaneName = "ContentPane";
                moduleInfo.ModuleDefID = moduleDefinitionInfo.ModuleDefID;
                moduleInfo.CacheTime = moduleDefinitionInfo.DefaultCacheTime;
                moduleInfo.InheritViewPermissions = true;
                moduleInfo.AllTabs = false;
                ModuleController moduleController = new ModuleController();
                int moduleId = moduleController.AddModule(moduleInfo);
            }
        }
        //Clearing cache
        DotNetNuke.Common.Utilities.DataCache.ClearModuleCache(tab.TabID);
        DotNetNuke.Common.Utilities.DataCache.ClearTabsCache(PortalId);
        DotNetNuke.Common.Utilities.DataCache.ClearPortalCache(PortalId, false);

        return true;
    }

    /// <summary>
    /// Add the selected permissions on the tab
    /// </summary>
    /// <param name="ti"></param>
    protected void AddPermissionsOnTab(TabInfo ti)
    {
        PortalSettings portalSettings = new PortalSettings();
        int portalId = portalSettings.PortalId;
        RoleController rc = new RoleController();

        List<RoleInfo> roleView = new List<RoleInfo>();
        List<RoleInfo> roleEdit = new List<RoleInfo>();
        

        foreach (ListItem li in cbl_roles1.Items)
        {
            if(li.Selected)
            {
                RoleInfo leRole = rc.GetRoleByName(portalId, li.Text);
                roleView.Add(leRole);
            }
        }

        foreach (ListItem li in cbl_roles2.Items)
        {
            if (li.Selected)
            {
                roleEdit.Add(rc.GetRoleByName(portalId, li.Text));
            }
        }


        foreach (RoleInfo ri in roleView)
        {
            foreach (PermissionInfo p in PermissionController.GetPermissionsByTab())
            {
                if (p.PermissionKey == "VIEW")
                {

                    TabPermissionInfo tpi = new TabPermissionInfo();
                    tpi.PermissionID = p.PermissionID;
                    tpi.PermissionKey = p.PermissionKey;
                    tpi.PermissionName = p.PermissionName;
                    tpi.AllowAccess = true;
                    tpi.RoleID = ri.RoleID;
                    ti.TabPermissions.Add(tpi);

                }

            }
        }            
        foreach(RoleInfo ri in roleEdit)
        {
            foreach (PermissionInfo p in PermissionController.GetPermissionsByTab())
            {
                if (p.PermissionKey == "EDIT")
                {

                    TabPermissionInfo tpi = new TabPermissionInfo();
                    tpi.PermissionID = p.PermissionID;
                    tpi.PermissionKey = p.PermissionKey;
                    tpi.PermissionName = p.PermissionName;
                    tpi.AllowAccess = true;
                    tpi.RoleID = ri.RoleID;
                    ti.TabPermissions.Add(tpi);

                }

            }
        }
            
    }

    protected void ddl_pages_SelectedIndexChanged(object sender, EventArgs e)
    {
        tbx_nom.Text = ddl_pages.SelectedValue;
    }

    protected void fillList()
    {
        list = new List<DesktopModuleInfo>();
        DesktopModuleController dmc = new DesktopModuleController();
        System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(Server.MapPath("DesktopModules/AIS/Installer/Modules.xml") /*Modules"C:\\inetpub\\wwwroot\\DNN\\DesktopModules\\AIS\\Installer\\Modules.xml"*/);
        while (reader.Read())
        {
            reader.MoveToContent();
            if (reader.Name == "module")
            {
                if (reader.HasAttributes)
                {
                    DesktopModuleInfo dmi = dmc.GetDesktopModuleByName(reader.GetAttribute("friendlyName"));
                    //We check if the module is already activated. If it is, there's no need to reinstall it
                    if(dmi!=null)
                    {
                        if (!IsInPage(dmi))
                            list.Add(dmi);
                    }
                }

            }
        }
    }
    #endregion Manual

    private void createPage(String tabName, List<TabPermissionInfo> permissions, bool visible, bool superTab, string parent)
    {
        PortalSettings portalSettings = new PortalSettings();
        int portalId = portalSettings.PortalId;
        TabController TC = new TabController();
        TabInfo ti = new TabInfo();
        ti.TabName = tabName;
        ti.PortalID = portalId;
        ti.Title = tabName;
        if (TC.GetTabByName(parent, portalId)!=null)
            ti.ParentId = TC.GetTabByName(parent, portalId).TabID;
        ti.Description = tabName;
        ti.KeyWords = tabName;
        ti.IsVisible = visible;
        ti.DisableLink = false;
        ti.IsDeleted = false;
        ti.Url = "";
        ti.IsSuperTab = superTab;
        foreach (TabPermissionInfo p in permissions)
        {
            ti.TabPermissions.Add(p);
        }
        TC.AddTab(ti);
       
    }

    private void AddModuleToTab(TabInfo ti, DesktopModuleInfo dmi, string title="", string paneName="ContentPane", Dictionary<String,String>settings = null)
    {
        PortalSettings ps = new PortalSettings();
        int portalId = ps.PortalId;
        DesktopModuleInfo desktopModuleInfo = null;
        foreach (KeyValuePair<int, DesktopModuleInfo> kvp in DesktopModuleController.GetDesktopModules(portalId))
        {
            DesktopModuleInfo mod = kvp.Value;
            if (mod != null)
                if ((mod.FriendlyName == dmi.FriendlyName || mod.ModuleName == dmi.FriendlyName))
                {
                    desktopModuleInfo = mod;
                }
        }
        
        if (desktopModuleInfo != null && ti!=null)
        {
            foreach (ModuleDefinitionInfo moduleDefinitionInfo in ModuleDefinitionController.GetModuleDefinitionsByDesktopModuleID(desktopModuleInfo.DesktopModuleID).Values)
            {
                ModuleInfo moduleInfo = new ModuleInfo();
                moduleInfo.PortalID = portalId;
                moduleInfo.TabID = ti.TabID;
                moduleInfo.ModuleOrder = 1;
                moduleInfo.ModuleTitle = title;
                moduleInfo.PaneName = paneName;
                moduleInfo.ModuleDefID = moduleDefinitionInfo.ModuleDefID;
                moduleInfo.CacheTime = moduleDefinitionInfo.DefaultCacheTime;
                moduleInfo.InheritViewPermissions = true;
                moduleInfo.AllTabs = false;
                ModuleController moduleController = new ModuleController();
                if(settings!=null)
                {
                    foreach(KeyValuePair<String, String> kvp in settings)
                    {
                        if(kvp.Key.Contains("tabid"))
                        {
                            TabController tc = new TabController();
                            int id= tc.GetTabByName(kvp.Value, portalId).TabID;
                            moduleInfo.ModuleSettings.Add(kvp.Key, id);
                            moduleController.UpdateModuleSetting(moduleInfo.ModuleID, kvp.Key, ""+id);
                        }
                        else
                        {
                            moduleInfo.ModuleSettings.Add(kvp.Key, kvp.Value);
                            moduleController.UpdateModuleSetting(moduleInfo.ModuleID, kvp.Key, kvp.Value);
                        }
                        
                    }
                }
                int moduleId = moduleController.AddModule(moduleInfo);
            }
        }
    }

    private String checkPage(TabInfo tab, DesktopModuleInfo module)
    {
        PortalSettings portalSettings = new PortalSettings();
        int portalId = portalSettings.PortalId;
        TabController TC = new TabController();
        foreach (TabInfo ti in TC.GetTabsByPortal(portalId).Values)
        {
            if (ti.TabName == tab.TabName)
            {
                if (ti.IsDeleted)
                    return "Bin";
                
                    foreach (ModuleInfo mi in ti.ChildModules.Values)
                    {
                        if ((mi.FriendlyName == module.FriendlyName) && !mi.IsDeleted)
                        {
                            return "OK";
                        }
                    }
                    return module.FriendlyName;
            }
        }

        return "Page";

    }

    protected void btn_assistant_Click(object sender, EventArgs e)
    {
        try
        {
            PortalSettings ps = new PortalSettings();
            int portalId = ps.PortalId;
            pnl_friendly.Visible = true;
            pnl_install.Visible = true;
            pnl_start.Visible = false;
            TabController TC = new TabController();
            string check = "";
            System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(Server.MapPath("DesktopModules/AIS/Installer/Modules.xml")/*"C:\\inetpub\\wwwroot\\DNN\\DesktopModules\\AIS\\Installer\\Modules.xml"*/);
            bool install = false;
            while(reader.Read())
            {
                Label lbl = new Label();
                Literal line = new Literal();
                line.Text = "<br />";
                if(reader.Name=="tab" && reader.HasAttributes)
                {
                    TabInfo ti = TC.GetTabByName(reader.GetAttribute("name"),portalId);
                    if(ti==null)
                    {
                        
                        lbl.Text = "Tab " + reader.GetAttribute("name") + " does not exist";
                        lbl.ForeColor = System.Drawing.Color.Red;
                        pnl_friendly.Controls.Add(lbl);
                        pnl_friendly.Controls.Add(line);
                        install = true;
                        
                    }
                    else if(ti.IsDeleted)
                    {
                        lbl.Text = "Tab " + ti.TabName + " is in the bin : please restore it or delete it permanently";
                        lbl.ForeColor = System.Drawing.Color.Red;
                        pnl_friendly.Controls.Add(lbl);
                        pnl_friendly.Controls.Add(line);
                    }
                }
                if(reader.Name=="module" && reader.HasAttributes)
                {
                    
                    if(DesktopModuleController.GetDesktopModuleByFriendlyName(reader.GetAttribute("friendlyName"))!=null)
                    {
                        DesktopModuleInfo dmi = DesktopModuleController.GetDesktopModuleByFriendlyName(reader.GetAttribute("friendlyName"));
                        
                        
                        TabInfo ti = new TabInfo();
                        ti.TabName = reader.GetAttribute("tab");


                        switch (checkPage(ti, DesktopModuleController.GetDesktopModuleByFriendlyName(reader.GetAttribute("friendlyName"))))
                        {
                            case "OK":
                                if(check!=ti.TabName)
                                {
                                    lbl.Text = "Module " + dmi.FriendlyName + " is already implemented in tab "+ti.TabName;
                                    lbl.ForeColor = System.Drawing.Color.Green;
                                    pnl_friendly.Controls.Add(lbl);
                                    pnl_friendly.Controls.Add(line);
                                    check = ti.TabName;
                                }
                                break;

                            case "Page" :
                               
                                break;

                            case "Bin" :
                                
                                break;

                            default :
                                lbl.Text = "Module " + dmi.FriendlyName + " does not exist in tab "+ ti.TabName;
                                lbl.ForeColor = System.Drawing.Color.Red;
                                pnl_friendly.Controls.Add(lbl);
                                pnl_friendly.Controls.Add(line);
                                install = true;
                                break;

                        }
                    }
                    else
                    {
                        lbl.Text = "Module " + reader.GetAttribute("friendlyName") + " does not exist in site";
                        lbl.ForeColor = System.Drawing.Color.Red;
                        pnl_friendly.Controls.Add(lbl);
                        pnl_friendly.Controls.Add(line);
                    }

                }
            }
            btn_install.Visible = install;
        }
        catch(Exception exc)
        {
            superlabel.Text += exc.Message;
        }
        
    }

    //private void install(TabInfo ti, List<DesktopModuleInfo>listModules)
    //{
    //    Label lbl = new Label();
    //    Literal line = new Literal();
    //    line.Text = "<br />";
    //    switch(checkPage(ti, listModules))
    //    {
    //        case "Page" :
                
    //            lbl.Text = "Tab " + ti.TabName + " is not implemented";
    //            foreach(DesktopModuleInfo dmi in listModules)
    //            {
    //                if (DesktopModuleController.GetDesktopModuleByFriendlyName(checkPage(ti, listModules)) == null)
    //                    lbl.Text += " and the module " + dmi.FriendlyName + " is not installed on your site";
    //            }
    //            lbl.ForeColor = System.Drawing.Color.Red;
    //            pnl_friendly.Controls.Add(lbl);
    //            pnl_friendly.Controls.Add(line);
    //            break;
    //        case "Bin" :
    //            lbl.Text = "Tab " + ti.TabName + " is in the bin : please restore it or delete it permanently";
    //            lbl.ForeColor = System.Drawing.Color.Red;
    //            pnl_friendly.Controls.Add(lbl);
    //            pnl_friendly.Controls.Add(line);
    //            break;
    //        case "OK" :
    //            lbl.Text = "Tab " + ti.TabName + " is already implemented";
    //            lbl.ForeColor = System.Drawing.Color.Green;
    //            pnl_friendly.Controls.Add(lbl);
    //            pnl_friendly.Controls.Add(line);
    //            break;
    //        default :
    //            lbl.Text = "Module " + checkPage(ti, listModules) + " is not implemented in tab "+ti.TabName;
    //            if (DesktopModuleController.GetDesktopModuleByFriendlyName(checkPage(ti, listModules)) == null)
    //                lbl.Text += " : it is not even installed in your site!";
    //            lbl.ForeColor = System.Drawing.Color.Red;
    //            pnl_friendly.Controls.Add(lbl);
    //            pnl_friendly.Controls.Add(line);
    //            break;
                
    //    }        
    //}

    protected void btn_manual_Click(object sender, EventArgs e)
    {
        pnl_manuel.Visible = true;
        pnl_start.Visible = false;
    }

    protected void btn_install_Click(object sender, EventArgs e)
    {
        
        bool go = true;
        System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(Server.MapPath("DesktopModules/AIS/Installer/Modules.xml"));
        while (reader.Read())
        {
            if(reader.Name=="module" && reader.HasAttributes)
            {
                if(DesktopModuleController.GetDesktopModuleByFriendlyName(reader.GetAttribute("friendlyName"))==null)
                {
                    go = false;
                    break;
                }
            }
        }
        if(go)
            procede();
        else
        {
            pnl_friendly.Visible = false;
            pnl_install.Visible = false;
            pnl_install_missing_files.Visible = true;
        }

    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        pnl_start.Visible = true;
        pnl_friendly.Visible = false;
        pnl_install.Visible = false;
    }

    private List<TabPermissionInfo> getListPermissionsTab(string tabName)
    {
        PortalSettings ps = new PortalSettings();
        int portalId = ps.PortalId;
        RoleController rc = new RoleController();
        List<TabPermissionInfo> permissions = new List<TabPermissionInfo>();
        System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(Server.MapPath("DesktopModules/AIS/Installer/Modules.xml")/*"C:\\inetpub\\wwwroot\\DNN\\DesktopModules\\AIS\\Installer\\Modules.xml"*/);
        while(reader.Read())
        {

            if(reader.Name=="permission" && reader.HasAttributes && reader.GetAttribute("tab")==tabName)
            {
                RoleInfo ri = rc.GetRoleByName(portalId, reader.GetAttribute("role"));
                foreach (PermissionInfo p in PermissionController.GetPermissionsByTab())
                {
                    if (p.PermissionKey == "VIEW")
                    {

                        TabPermissionInfo tpi = new TabPermissionInfo();
                        tpi.PermissionID = p.PermissionID;
                        tpi.PermissionKey = p.PermissionKey;
                        tpi.PermissionName = p.PermissionName;
                        tpi.AllowAccess = bool.Parse(reader.GetAttribute("View")); ;
                        tpi.RoleID = ri.RoleID;
                        permissions.Add(tpi);
                    }
                    if (p.PermissionKey == "EDIT")
                    {

                        TabPermissionInfo tpi = new TabPermissionInfo();
                        tpi.PermissionID = p.PermissionID;
                        tpi.PermissionKey = p.PermissionKey;
                        tpi.PermissionName = p.PermissionName;
                        tpi.AllowAccess = bool.Parse(reader.GetAttribute("Edit")); ;
                        tpi.RoleID = ri.RoleID;
                        permissions.Add(tpi);
                    }

                }
                 
            }
        }
        return permissions;
    }

    private void procede()
    {
        PortalSettings ps = new PortalSettings();
        int portalId = ps.PortalId;
        TabController tc = new TabController();
        DesktopModuleController DMC = new DesktopModuleController();
        //string check = "";
        Dictionary<String, String> settings = null;
        TabController TC = new TabController();
        System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(Server.MapPath("DesktopModules/AIS/Installer/Modules.xml"));
        while (reader.Read())
        {
            if(reader.Name=="tab" && reader.HasAttributes)
            {
                TabInfo ti = TC.GetTabByName(reader.GetAttribute("name"),portalId);
                if (ti == null)
                {
                    if (reader.GetAttribute("parent") != null && reader.GetAttribute("parent") != "")
                    {
                        createPage(reader.GetAttribute("name"), getListPermissionsTab(reader.GetAttribute("name")), bool.Parse(reader.GetAttribute("visible")), bool.Parse(reader.GetAttribute("superTab")), reader.GetAttribute("parent"));
                    }
                    else
                    {
                        createPage(reader.GetAttribute("name"), getListPermissionsTab(reader.GetAttribute("name")), bool.Parse(reader.GetAttribute("visible")), bool.Parse(reader.GetAttribute("superTab")), "");
                    }
                    if
                    (reader.GetAttribute("dependency") != null && reader.GetAttribute("dependency") != "")
                    {
                        TC.DeleteTab(TC.GetTabByName(reader.GetAttribute("dependency"), portalId).TabID, portalId);
                        procede();
                        reader.Close();
                    }
                }
            }
            if (reader.Name == "module" && reader.HasAttributes)
            {
                if (DesktopModuleController.GetDesktopModuleByFriendlyName(reader.GetAttribute("friendlyName")) != null)
                {
                    DesktopModuleInfo dmi = DesktopModuleController.GetDesktopModuleByFriendlyName(reader.GetAttribute("friendlyName"));
                    if(reader.AttributeCount>2)
                    {
                        settings = new Dictionary<string, string>();
                        for(int i=2; i<reader.AttributeCount; i=i+2)
                        {
                            settings.Add(reader.GetAttribute(i), reader.GetAttribute(i+1));
                        }
                    }
                    Label lbl = new Label();
                    Literal line = new Literal();
                    line.Text = "<br />";
                    TabInfo ti = new TabInfo();
                    ti.TabName = reader.GetAttribute("tab");
                    switch (checkPage(ti, DesktopModuleController.GetDesktopModuleByFriendlyName(reader.GetAttribute("friendlyName"))))
                    {
                        
                        case "OK":
                           break;

                        case "Page":
                            
                            break;

                        case "Bin":
                            break;

                        default:
                            AddModuleToTab(tc.GetTabByName(ti.TabName, portalId), dmi, settings: settings);
                            break;

                    }
                }
            }
        }
        pnl_install.Visible = false;
        pnl_install_missing_files.Visible = false;
        pnl_manuel.Visible = true;
        pnl_fin.Visible = true;
    }

    protected void btn_install_anyway_Click(object sender, EventArgs e)
    {
        procede();
        
    }
    protected void btn_home_Click(object sender, EventArgs e)
    {
        
    }
}