using AIS;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DesktopModules_AIS_Admin_Exports_Exports : PortalModuleBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        panel.Visible = UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT);
    }

    protected void btn_exportPres_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        conn.Open();

        SqlCommand sql = new SqlCommand("select c.cric, c.name as 'nom club',a.[function] as 'fonction',a.name as 'prenom nom',(select top 1 email from ais_members where nim = a.nim) as email,(select top 1 [gsm] from ais_members where nim = a.nim) as gsm from ais_clubs c,ais_rya a where c.cric=a.cric and a.rotary_year=@rotary_year  and c.type_club='rotary' and a.[function]='Président' order by  c.name", conn);
        sql.Parameters.AddWithValue("@rotary_year", Functions.GetRotaryYear() + 1);
        SqlDataAdapter da = new SqlDataAdapter(sql);
        DataSet ds = new DataSet();
        da.Fill(ds);
        List<DataTable> tables = new List<DataTable>();
        foreach(DataTable table in ds.Tables)
        {
            tables.Add(table);
        }
        
        
        Media media = DataMapping.ExportDataTablesToXLS(tables, "Liste des présidents élus année " + (Functions.GetRotaryYear() + 1) +"-"+ (Functions.GetRotaryYear() + 2) + ".xls", Aspose.Cells.SaveFormat.Excel97To2003);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    protected void btn_exportBureau_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        conn.Open();

        SqlCommand sql = new SqlCommand("SELECT c.name as 'Club', a.name as 'Membre', a.[function] as 'Fonction' FROM ais_clubs c, ais_rya a WHERE c.cric = a.cric AND a.rotary_year = @rotary_year ORDER BY c.name", conn);
        sql.Parameters.AddWithValue("@rotary_year", Functions.GetRotaryYear() + 1);
        SqlDataAdapter da = new SqlDataAdapter(sql);
        DataSet ds = new DataSet();
        da.Fill(ds);
        List<DataTable> tables = new List<DataTable>();
        foreach (DataTable table in ds.Tables)
        {
            tables.Add(table);
        }


        Media media = DataMapping.ExportDataTablesToXLS(tables, "Bureau année " + (Functions.GetRotaryYear() + 1) +"-"+ (Functions.GetRotaryYear() + 2) + ".xls", Aspose.Cells.SaveFormat.Excel97To2003);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    protected void btn_exportClubsSansBureau_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        conn.Open();

        SqlCommand sql = new SqlCommand("select cric, name as 'Nom du club' ,adress_1 as 'Adresse 1' ,adress_2 as 'Adresse 2',adress_3 as 'Adresse 3' ,zip as 'Code postal' ,town as 'Ville' , email as 'Email',web as 'Web' from ais_clubs where type_club='rotary' and cric not in (select distinct [cric] FROM[rodi.dnn].[dbo].[ais_rya] where rotary_year = @rotary_year)", conn);
        sql.Parameters.AddWithValue("@rotary_year", Functions.GetRotaryYear() + 1);
        SqlDataAdapter da = new SqlDataAdapter(sql);
        DataSet ds = new DataSet();
        da.Fill(ds);
        List<DataTable> tables = new List<DataTable>();
        foreach (DataTable table in ds.Tables)
        {
            tables.Add(table);
        }


        Media media = DataMapping.ExportDataTablesToXLS(tables, "Liste des clubs qui n'ont pas déclaré de bureau.xls", Aspose.Cells.SaveFormat.Excel97To2003);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }
}