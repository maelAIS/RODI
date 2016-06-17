﻿using AIS;
using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Definitions;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.Modules.Html;
using DotNetNuke.Security.Permissions;
using DotNetNuke.Security.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DesktopModules_AIS_Création_Courrier_CreationCourrier : PortalModuleBase
{

    DotNetNuke.Entities.Modules.ModuleController objModules2 = new DotNetNuke.Entities.Modules.ModuleController();
    
    String role
    {
        get
        {
            return ""+ objModules2.GetModuleSettings(ModuleId)["role"];
        }
    }
    String path
    {
        get
        {
            return "" + objModules2.GetModuleSettings(ModuleId)["path"];
        }
    }
    String style
    {
        get
        {
            return "" + objModules2.GetModuleSettings(ModuleId)["style"];
        }
    }
    String impress
    {
        get
        {
            return "" + objModules2.GetModuleSettings(ModuleId)["impress"];
        }
    }
    String redirect
    {
        get
        {
            return "" + objModules2.GetModuleSettings(ModuleId)["redirect"];
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindDDL();
            foreach (ListItem li in ddl_year.Items)
            {
                if (li.Value == "" + DateTime.Now.Year)
                    li.Selected = true;
            }
            ddl_month.SelectedIndex = DateTime.Now.Month - 1;

            //if(tbx_tagsIncluded.Text=="")
            //    tbx_tagsIncluded.Text = DateTime.Now.Month<10? "" + DateTime.Now.Year +"0"+ DateTime.Now.Month : "" + DateTime.Now.Year +  DateTime.Now.Month;
        }

    }

    protected void btn_creation_Click(object sender, EventArgs e)
    {
        try
        {
            String pageName = ddl_month.SelectedValue + " " + ddl_year.SelectedValue;
            String url = ddl_month.SelectedValue + "" + ddl_year.SelectedValue;
            RoleController rc = new RoleController();
            RoleInfo ri = rc.GetRoleByName(PortalId, role);

            List<TabPermissionInfo> permissions = new List<TabPermissionInfo>();
            foreach (PermissionInfo p in PermissionController.GetPermissionsByTab())
            {
                if (p.PermissionKey == "VIEW")
                {

                    TabPermissionInfo tpi = new TabPermissionInfo();
                    tpi.PermissionID = p.PermissionID;
                    tpi.PermissionKey = p.PermissionKey;
                    tpi.PermissionName = p.PermissionName;
                    tpi.AllowAccess = true; ;
                    tpi.RoleID = ri.RoleID;
                    permissions.Add(tpi);
                }
                if (p.PermissionKey == "EDIT")
                {

                    TabPermissionInfo tpi = new TabPermissionInfo();
                    tpi.PermissionID = p.PermissionID;
                    tpi.PermissionKey = p.PermissionKey;
                    tpi.PermissionName = p.PermissionName;
                    tpi.AllowAccess = true; ;
                    tpi.RoleID = ri.RoleID;
                    permissions.Add(tpi);
                }
                
            }
            
            if (!createPage(pageName, permissions, false, false, "Courrier du District"))
            {
                pnl_page.Visible = false;
                pnl_error.Visible = true;
                hlk_pageExists.NavigateUrl = redirect + url + ".aspx";
            }
            else if (!createPage(pageName + "_article", permissions, false, false, pageName))
            {
                pnl_page.Visible = false;
                pnl_error.Visible = true;
                hlk_pageExists.NavigateUrl = redirect + url + "_article.aspx";
            }
            else
            {
                TabController TC = new TabController();
                TabInfo tabPrincipale = TC.GetTabByName(pageName, PortalId);
                DesktopModuleController DMC = new DesktopModuleController();
                DesktopModuleInfo dmi = DMC.GetDesktopModuleByModuleName("AIS.NewsPanel");
                dmi.ContentTitle = "courrier du district - " + pageName;
                TabInfo tabArticle = TC.GetTabByName(pageName + "_article", PortalId);
                DesktopModuleInfo dmiArticle = DMC.GetDesktopModuleByModuleName("AIS.NewsArticle");

                Dictionary<String, String> settingsMiniNews = new Dictionary<string, string>();
                Dictionary<String, String> settings = new Dictionary<string, string>();
                Dictionary<String, String> settings1Tiers = new Dictionary<string, string>();
                settings.Add("tabid", pageName + "_article");
                settings1Tiers.Add("tabid", pageName + "_article");
                settings.Add("category", "courrierdistrict");
                settings1Tiers.Add("category", "courrierdistrict");
                settings.Add("tags_included", (ddl_month.SelectedIndex + 1 < 10 ? ddl_year.SelectedValue + "0" + (ddl_month.SelectedIndex + 1) : ddl_year.SelectedValue + (ddl_month.SelectedIndex + 1)));
                settings1Tiers.Add("tags_included", (ddl_month.SelectedIndex + 1 < 10 ? ddl_year.SelectedValue + "0" + (ddl_month.SelectedIndex + 1) : ddl_year.SelectedValue + (ddl_month.SelectedIndex + 1)));
                settingsMiniNews.Add("style", style);
                settings1Tiers.Add("style", style);
                settingsMiniNews.Add("path", path);
                settings.Add("path", path);
                settings1Tiers.Add("path", path);
                settingsMiniNews.Add("impress", impress);



                DesktopModuleInfo dmiHtml = DMC.GetDesktopModuleByName("HTML");
                if (dmiHtml == null)
                    throw new Exception("HTML ");

                dmiHtml.ContentTitle = "Edito";
                AddModuleToTab(tabPrincipale, dmi, paneName: "Zero2Tiers", settings: settings);
                AddModuleToTab(tabArticle, dmiArticle, paneName: "Zero2Tiers", settings: settingsMiniNews);
                AddModuleToTab(tabArticle, dmi, paneName: "Zero1Tiers", settings: settings1Tiers);
                AddModuleToTab(tabPrincipale, dmiHtml, paneName: "Zero1Tiers");


                pnl_success.Visible = true;
                pnl_page.Visible = false;
                String[] splits = pageName.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                pageName = splits[0] + splits[1];
                Response.Redirect(redirect + pageName + ".aspx");

            }


        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
    }

    private void BindDDL()
    {
        ddl_month.Items.Clear();
        ddl_year.Items.Clear();

        ddl_year.Items.Add("" + (DateTime.Now.Year - 1));
        ddl_year.Items.Add("" + (DateTime.Now.Year));
        ddl_year.Items.Add("" + (DateTime.Now.Year + 1));

        ddl_month.Items.Add("Janvier");
        ddl_month.Items.Add("Février");
        ddl_month.Items.Add("Mars");
        ddl_month.Items.Add("Avril");
        ddl_month.Items.Add("Mai");
        ddl_month.Items.Add("Juin");
        ddl_month.Items.Add("Juillet");
        ddl_month.Items.Add("Août");
        ddl_month.Items.Add("Septembre");
        ddl_month.Items.Add("Octobre");
        ddl_month.Items.Add("Novembre");
        ddl_month.Items.Add("Décembre");

    }

    private bool createPage(String tabName, List<TabPermissionInfo> permissions, bool visible, bool superTab, string parent)
    {
        PortalSettings portalSettings = new PortalSettings();
        int portalId = portalSettings.PortalId;
        TabController TC = new TabController();
        TabInfo ti = new TabInfo();
        ti.TabName = tabName;
        ti.PortalID = portalId;
        ti.Title = "Courrier du District "+ tabName;
        if (TC.GetTabByName(parent, portalId) != null)
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
        try
        {
            TC.AddTab(ti);
        } 
        catch(Exception ee)
        {
            if(TC!=null && ti!=null && ti.TabName!=null && TC.GetTabByName(ti.TabName, portalId)!=null && TC.GetTabByName(ti.TabName, portalId).IsDeleted)
            {
                lbl_pageExists.Visible = false;
                lbl_pageInBin.Visible = true;
                hlk_pageExists.Visible = false;
            }
            return false;
            
                
        }
        return true;

    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect(Globals.NavigateURL());
    }

    private void AddModuleToTab(TabInfo ti, DesktopModuleInfo dmi, string title = "", string paneName = "ContentPane", Dictionary<String, String> settings = null)
    {
        if (title == "")
            title = dmi.ContentTitle;
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

        if (desktopModuleInfo != null && ti != null)
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
                if (settings != null)
                {
                    foreach (KeyValuePair<String, String> kvp in settings)
                    {
                        if (kvp.Key.Contains("tabid"))
                        {
                            TabController tc = new TabController();
                            int id = tc.GetTabByName(kvp.Value, portalId).TabID;
                            moduleInfo.ModuleSettings.Add(kvp.Key, id);
                            moduleController.UpdateModuleSetting(moduleInfo.ModuleID, kvp.Key, "" + id);
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
    
}