using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DesktopModules_AIS_Création_Courrier_Settings : ModuleSettingsBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            return;
        PortalSettings portalSettings = new PortalSettings();
        int portalId = portalSettings.PortalId;
        DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();

        tbx_role.Text = "" + objModules.GetModuleSettings(ModuleId)["role"];
        tbx_path.Text = "" + objModules.GetModuleSettings(ModuleId)["path"];
        tbx_style.Text = "" + objModules.GetModuleSettings(ModuleId)["style"];
        tbx_impress.Text = "" + objModules.GetModuleSettings(ModuleId)["impress"];
        tbx_redirect.Text = "" + objModules.GetModuleSettings(ModuleId)["redirect"];
    }

    public override void UpdateSettings()
    {
        base.UpdateSettings();

        
        DotNetNuke.Entities.Modules.ModuleController objModules4 = new DotNetNuke.Entities.Modules.ModuleController();

        objModules4.UpdateModuleSetting(ModuleId, "role", tbx_role.Text);
        objModules4.UpdateModuleSetting(ModuleId, "path", tbx_path.Text);
        objModules4.UpdateModuleSetting(ModuleId, "style", tbx_style.Text);
        objModules4.UpdateModuleSetting(ModuleId, "redirect", tbx_redirect.Text);

    }
}