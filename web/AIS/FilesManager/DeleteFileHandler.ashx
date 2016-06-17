<%@ WebHandler Language="C#" Class="DeleteFileHandler" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public class DeleteFileHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        try
        {
            //deserialize the object
            FilesManagerCore objUser = Fonctions.Deserialize<FilesManagerCore>(context);

            //now we print out the value, we check if it is null or not
            if (objUser != null)
            {
                if (objUser.id == 0 && !string.IsNullOrEmpty(objUser.urlLink))
                {
                    string Serverpath = HttpContext.Current.Server.MapPath("~/" + objUser.urlLink);

                    if (File.Exists(Serverpath))
                    {
                        File.Delete(Serverpath);
                        context.Response.Write("Fichier supprimé!");
                    }
                }
            }
        }
        catch (Exception ee)
        {
            context.Response.Write(ee.Message);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}