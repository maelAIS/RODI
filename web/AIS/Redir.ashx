<%@ WebHandler Language="C#" Class="Redir" %>

using System;
using System.Web;
using System.Data.SqlClient;

public class Redir : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        int id = 0;
        int.TryParse(""+context.Request.QueryString["id"],out id);
        string url = "" + context.Request.QueryString["url"];

        if (id != 0)
        {
            SqlConnection conn = new SqlConnection(DotNetNuke.Common.Utilities.Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("UPDATE ais_newsletters_out SET [read]='O' WHERE id=@id", conn);
                sql.Parameters.AddWithValue("id", id);
                sql.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                conn.Close();
            }
        }
        
        context.Response.Redirect(url,true);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}