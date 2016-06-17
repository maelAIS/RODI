<%@ WebHandler Language="C#" Class="UploadFileHandler" %>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

public class UploadFileHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        try
        {
            if (!string.IsNullOrEmpty(context.Request.Params["rep"]))
            {
                string folder = "" + context.Request.Params["rep"];

                string Serverpath = HttpContext.Current.Server.MapPath("~/" + folder);

                if (context.Request.Files.Count > 0)
                {

                    if (!Directory.Exists(Serverpath))
                    {
                        Directory.CreateDirectory(Serverpath);
                    }

                    HttpFileCollection files = context.Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];

                        string fileName = "";

                        //In case of IE
                        if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
                        {
                            string[] filesArray = file.FileName.Split(new char[] {
                                '\\'
                            });
                            fileName = filesArray[filesArray.Length - 1];
                        }
                        else // In case of other browsers
                        {
                            fileName = file.FileName;
                        }

                        string FileNameOk = Fonctions.Check_File_Name_Valid(fileName);

                        string fname = Serverpath + @"\" + FileNameOk;

                        if (File.Exists(fname))
                        {
                            context.Response.Write("Fichier ayant le même nom existant! ");
                            File.Delete(fname);
                            context.Response.Write("Fichier supprimé! ");
                        }

                        file.SaveAs(fname);
                        context.Response.Write("Fichier sauvegardé! ");
                    }

                    #region réponse server
                    //context.Response.AddHeader("Vary", "Accept");
                    //try
                    //{
                    //    if (context.Request["HTTP_ACCEPT"].Contains("application/json"))
                    //        context.Response.ContentType = "application/json";
                    //    else
                    //        context.Response.ContentType = "text/plain";
                    //}
                    //catch
                    //{
                    //    context.Response.ContentType = "text/plain";
                    //}


                    #endregion
                }
            }
            else
            {
                context.Response.Write("Pas de répertoire défini!");
            }
        }
        catch (Exception ee)
        {
            context.Response.Write("ERREUR!");
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