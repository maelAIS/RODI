<%@ WebHandler Language="C#" Class="GetFilesHandler" %>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;


    public class GetFilesHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (!string.IsNullOrEmpty(context.Request.Params["rep"]))
                {
                    string typeFilter = "" + context.Request.Params["typeFilter"];
                    string[] typeString = typeFilter.ToLower().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    string extFilter = "" + context.Request.Params["extFilter"];
                    string[] extString = extFilter.ToLower().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    string folder = "" + context.Request.Params["rep"];
                    string Serverpath = HttpContext.Current.Server.MapPath("~/" + folder);
                    if (!Directory.Exists(Serverpath))
                    {
                        Directory.CreateDirectory(Serverpath);
                    }

                    List<FilesManagerCore> ListFiles = new List<FilesManagerCore>();

                    DirectoryInfo di = new DirectoryInfo(Serverpath);
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        FilesManagerCore fmc = new FilesManagerCore();
                        fmc.name = "" + fi.Name.Replace(fi.Extension, "");
                        fmc.ext = "" + fi.Extension;
                        fmc.mime = "" + Fonctions.GetMimeType(fi.Extension);
                        fmc.size = fi.Length;
                        fmc.path = "" + folder;
                        fmc.urlLink = "" + folder + "/" + fi.Name;

                        //Gestion des filtrages de fichiers suivant les extensions ou le type
                        if (extString != null && extString.Count() > 0)
                        {
                            string[] resultsExt = Array.FindAll(extString, s => s.Equals(fmc.ext.Replace(".", "")));

                            if (resultsExt != null && resultsExt.Count() > 0)
                            {
                                ListFiles.Add(fmc);
                            }
                        }
                        else if (typeString != null && typeString.Count() > 0)
                        {
                            string[] resultsType = Array.FindAll(typeString, s => s.StartsWith(fmc.mime.Substring(0, fmc.mime.IndexOf('/'))));

                            if (resultsType != null && resultsType.Count() > 0)
                            {
                                ListFiles.Add(fmc);
                            }
                        }
                        else
                        {
                            ListFiles.Add(fmc);
                        }


                    }


                    //set the content type, you can either return plain text, html text, or json or other type    
                    context.Response.ContentType = "text/json";
                    var json = new JavaScriptSerializer().Serialize(ListFiles);
                    context.Response.Write(json);
                    //}
                    //}
                }
                else
                {
                    context.Response.Write("Le répertoire n'est pas défini!");
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
