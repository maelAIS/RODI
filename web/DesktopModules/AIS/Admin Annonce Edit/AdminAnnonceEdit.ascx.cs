
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
//e) Provide Installation Information, but only if you would otherwise be required to provide such information under section 6 of the GNU GPL, and only to the extent that such information is necessary to install and execute a modified version of the Combined Work produced by recombining or relinking the Application with a modified version of the Linked Version. (If you use option 4d0, the Installation Information must accompany the Minimal Corresponding Source and Corresponding Application Code. If you use option 4d1, you must provide the Installation Information in the manner specified by section 6 of the GNU GPL for conveying Corresponding Source.)

//5. Combined Libraries.

//You may place library facilities that are a work based on the Library side by side in a single library together with other library facilities that are not Applications and are not covered by this License, and convey such a combined library under terms of your choice, if you do both of the following:
//a) Accompany the combined library with a copy of the same work based on the Library, uncombined with any other library facilities, conveyed under the terms of this License.
//b) Give prominent notice with the combined library that part of it is a work based on the Library, and explaining where to find the accompanying uncombined form of the same work.

//6. Revised Versions of the GNU Lesser General Public License.

//The Free Software Foundation may publish revised and/or new versions of the GNU Lesser General Public License from time to time. Such new versions will be similar in spirit to the present version, but may differ in detail to address new problems or concerns.
//Each version is given a distinguishing version number. If the Library as you received it specifies that a certain numbered version of the GNU Lesser General Public License "or any later version" applies to it, you have the option of following the terms and conditions either of that published version or of any later version published by the Free Software Foundation. If the Library as you received it does not specify a version number of the GNU Lesser General Public License, you may choose any version of the GNU Lesser General Public License ever published by the Free Software Foundation.
//If the Library as you received it specifies that a proxy can decide whether future versions of the GNU Lesser General Public License shall apply, that proxy's public statement of acceptance of any version is permanent authorization for you to choose that version for the Library.

#endregion Copyrights


using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;
using Telerik.Web.UI;
using System.Drawing;
using System.IO;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Membership;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;

public partial class DesktopModules_AIS_Admin_Annonce_Edit_AdminAnnonceEdit : PortalModuleBase
{
    int id_contenu = 0;    
    AIS.Content contenu;

    DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();
    int Annoncetabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModuleId)["Annoncetabid"], out t);
            return t;
        }
    }

    int Dontabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModuleId)["Dontabid"], out t);
            return t;
        }
    }

    int ProTabId
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModuleId)["Protabid"], out t);
            return t;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.IsInRole(Const.ROLE_MEMBERS) || UserInfo.IsSuperUser)
        {
            int.TryParse("" + Request.QueryString["id_contenu"], out id_contenu);
            if (id_contenu > 0)
            {
                contenu = DataMapping.GetContent_by_ID(id_contenu);
                if (contenu != null)
                {
                    if ((contenu.id > 0 && UserInfo.UserID == contenu.id_user) || UserInfo.IsSuperUser)// seul le super user et le propriétaire de la page peut accéder à cette page de modif
                    {

                        DirectoryInfo d = new DirectoryInfo(Server.MapPath(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/"));
                        if (!d.Exists)
                        {
                            d.Create();
                        }
                        TXT_Editor.ImageManager.UploadPaths = new string[] { PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/" };
                        TXT_Editor.DocumentManager.UploadPaths = new string[] { PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/" };

                        if (IsPostBack == false)
                        {
                             Binding_Panel1();                            
                        }//if (IsPostBack == false)
                    }//if (UserIdQuery > 0 && UserInfo.UserID == UserIdQuery) || UserInfo.IsSuperUser)
                    else
                    {
                        if (PortalSettings.HomeTabId > 0)
                        {
                            Response.Redirect(Globals.NavigateURL(PortalSettings.HomeTabId), true);
                        }
                        else
                        {
                            Response.Redirect(Globals.GetPortalDomainName(PortalSettings.PortalAlias.HTTPAlias, Request, true), true);
                        }
                    }
                }//if (contenu != null && contenu.id > 0)
                else
                {
                    if (PortalSettings.HomeTabId > 0)
                    {
                        Response.Redirect(Globals.NavigateURL(PortalSettings.HomeTabId), true);
                    }
                    else
                    {
                        Response.Redirect(Globals.GetPortalDomainName(PortalSettings.PortalAlias.HTTPAlias, Request, true), true);
                    }
                }
            }//if (id_contenu > 0)
            else if (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_MEMBERS))
            {
                if (IsPostBack == false && !UserInfo.IsSuperUser)
                {
                    Session["Insert"] = "o";
                    Binding_Panel2();
                }//if (IsPostBack == false)
                else if (UserInfo.IsSuperUser)
                {
                    Binding_Panel1();
                }
            }
            else
            {
                if (PortalSettings.HomeTabId > 0)
                {
                    Response.Redirect(Globals.NavigateURL(PortalSettings.HomeTabId), true);
                }
                else
                {
                    Response.Redirect(Globals.GetPortalDomainName(PortalSettings.PortalAlias.HTTPAlias, Request, true), true);
                }
            }
        }//if (UserInfo.IsInRole(Const.ROLE_MEMBRES) || UserInfo.IsSuperUser)
        else
        {
            if (PortalSettings.HomeTabId > 0)
            {
                Response.Redirect(Globals.NavigateURL(PortalSettings.HomeTabId), true);
            }
            else
            {
                Response.Redirect(Globals.GetPortalDomainName(PortalSettings.PortalAlias.HTTPAlias, Request, true), true);
            }
        }
    }

    protected void Binding_Panel1()
    {
        if (contenu != null)
        {            
            // Custum image manager
            string filename_Img = Functions.ClearFileName(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/");
            DirectoryInfo d = new DirectoryInfo(Server.MapPath(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/"));
            if (!d.Exists)
            {
                d.Create();
            }
            TXT_Editor.ImageManager.ViewPaths = new string[] { filename_Img };
            TXT_Editor.ImageManager.UploadPaths = new string[] { filename_Img };
            TXT_Editor.ImageManager.DeletePaths = new string[] { filename_Img };

            // Custum document manager
            string filename_Doc = Functions.ClearFileName(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/");            
            TXT_Editor.DocumentManager.ViewPaths = new string[] { filename_Doc };
            TXT_Editor.DocumentManager.UploadPaths = new string[] { filename_Doc };
            TXT_Editor.DocumentManager.DeletePaths = new string[] { filename_Doc };
            //size
            TXT_Editor.DocumentManager.MaxUploadFileSize = 4194304;
            TXT_Editor.ImageManager.MaxUploadFileSize = 1048576;

            Session["id_contenu"] = contenu.id;

            Session["publie"] = contenu.published;

            if (!string.IsNullOrEmpty(contenu.text))
            {
                TXT_Editor.Content = contenu.text;
            }          

            if (!string.IsNullOrEmpty(contenu.title))
            {
                if (contenu.title == "Nouvelle annonce")
                {
                    TBX_Titre.Text = "";
                    TBX_Titre.Focus();
                }
                else
                {
                    TBX_Titre.Text = contenu.title;
                }
            }

            if (!string.IsNullOrEmpty(contenu.announcementType))
            {
                if (contenu.announcementType.ToLower() == "offre")
                {
                    RBT_Offre.Checked = true;
                }
                else
                {
                    RBT_Demande.Checked = true;
                }
            } 

            IMG_Logo.ImageUrl = contenu.GetAnnoncePhoto();
            HF_Logo.Value = contenu.photo;
            BT_Effacer_Logo.Visible = contenu.photo != "";

            if (!string.IsNullOrEmpty(contenu.file))
            {                
                HL_Url.NavigateUrl = contenu.GetAnnonceFichier();
            }

            if (!string.IsNullOrEmpty(contenu.textFile))
            {
                HL_Url.Text = contenu.textFile;
                TXT_Url_Texte.Text = contenu.textFile;                
            }
        }
    }

    protected void Binding_Panel2()
    {
        contenu = new AIS.Content();
        contenu.published = "n";
        contenu.id_user = UserInfo.UserID;
        contenu.photo = "";
        contenu.text = "";
        contenu.title = "Nouvelle annonce";
        contenu.type = "Annonce";
        contenu.textFile = "";

       
        int id_c = DataMapping.Insert_Content(contenu);

        if (id_c > 0)
        {
            contenu.id = id_c;

            if (contenu != null)
            {
                // Custum image manager
                string filename_Img = Functions.ClearFileName(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/");
                DirectoryInfo d = new DirectoryInfo(Server.MapPath(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/"));
                if (!d.Exists)
                {
                    d.Create();
                }
                TXT_Editor.ImageManager.ViewPaths = new string[] { filename_Img };
                TXT_Editor.ImageManager.UploadPaths = new string[] { filename_Img };
                TXT_Editor.ImageManager.DeletePaths = new string[] { filename_Img };

                // Custum document manager
                string filename_Doc = Functions.ClearFileName(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/");
                TXT_Editor.DocumentManager.ViewPaths = new string[] { filename_Doc };
                TXT_Editor.DocumentManager.UploadPaths = new string[] { filename_Doc };
                TXT_Editor.DocumentManager.DeletePaths = new string[] { filename_Doc };
                //size
                TXT_Editor.DocumentManager.MaxUploadFileSize = 4194304;
                TXT_Editor.ImageManager.MaxUploadFileSize = 1048576;

                Session["id_contenu"] = contenu.id;

                Session["publie"] = contenu.published;

                if (!string.IsNullOrEmpty(contenu.text))
                {
                    TXT_Editor.Content = contenu.text;
                }

                if (!string.IsNullOrEmpty(contenu.title))
                {
                    TBX_Titre.Text = contenu.title;
                }

                if (!string.IsNullOrEmpty(contenu.announcementType))
                {
                    if (contenu.announcementType.ToLower() == "offre")
                    {
                        RBT_Offre.Checked = true;
                    }
                    else
                    {
                        RBT_Demande.Checked = true;
                    }
                }

                IMG_Logo.ImageUrl = contenu.GetAnnoncePhoto();
                HF_Logo.Value = contenu.photo;
                BT_Effacer_Logo.Visible = contenu.photo != "";

                if (!string.IsNullOrEmpty(contenu.file))
                {
                    HL_Url.NavigateUrl = contenu.GetAnnonceFichier();
                }

                if (!string.IsNullOrEmpty(contenu.textFile))
                {
                    HL_Url.Text = contenu.textFile;
                    TXT_Url_Texte.Text = contenu.textFile;
                }
            }
        }
        else
        {

        }
    }   

    protected void BT_Upload_Logo_Click(object sender, EventArgs e)
    {
        if (FU_Logo.UploadedFiles.Count > 0)
        {
            UploadedFile file = FU_Logo.UploadedFiles[0];
            string guid = Guid.NewGuid().ToString();
            string filename = Functions.ClearFileName("news_" + guid + ".jpg");

            Bitmap bmp = new Bitmap(file.InputStream);
            bmp = Functions.ThumbByWidth(bmp, Const.CONTENT_PHOTOS_WIDTH);
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            HF_Logo.Value = filename;

            Media media = new Media();
            media.content = ms.GetBuffer();
            media.content_size = media.content.Length;
            media.dt = DateTime.Now;
            media.w = bmp.Width;
            media.h = bmp.Height;
            media.name = filename;
            media.content_type = "image/jpeg";
            Session[HF_Logo.Value] = media;

            IMG_Logo.ImageUrl = Const.MEDIA_VIEW_URL + "?id=" + filename;
            BT_Effacer_Logo.Visible = true;
        }
    }
    protected void BT_Effacer_Logo_Click(object sender, EventArgs e)
    {
        BT_Effacer_Logo.Visible = false;
        Session[HF_Logo.Value] = null;
        HF_Logo.Value = "";
        IMG_Logo.ImageUrl = Const.MEMBERS_NOPHOTO_F;
    }
       
    protected void BT_Upload_Fichier_Click(object sender, EventArgs e)
    {
        if (FU_Url.UploadedFiles.Count > 0)
        {
            UploadedFile file = FU_Url.UploadedFiles[0];
            string guid =  Guid.NewGuid().ToString();
            string filename = Functions.ClearFileName("news_" + guid + file.GetExtension());
            TXT_Url_Texte.Text = file.FileName.Substring(0, file.FileName.Length - file.GetExtension().Length);
            HL_Url.Text = filename;
            MemoryStream ms = new MemoryStream();
            file.InputStream.CopyTo(ms, (int)file.InputStream.Length);
            Media media = new Media();
            media.content = ms.GetBuffer();
            media.content_size = media.content.Length;
            media.dt = DateTime.Now;
            media.w = 0;
            media.h = 0;
            media.name = filename;
            media.content_type = file.ContentType;
            Session[HL_Url.Text] = media;

            HL_Url.NavigateUrl = Const.MEDIA_DOWNLOAD_URL + "?id=" + filename;
            BT_Effacer_Fichier.Visible = true;
        }
    }
    protected void BT_Effacer_Fichier_Click(object sender, EventArgs e)
    {
        BT_Effacer_Fichier.Visible = false;
        Session[HL_Url.Text] = null;
        HL_Url.Text = "";
        HL_Url.NavigateUrl = "";
        TXT_Url_Texte.Text = "";
    }

    protected void BT_Valider_Click(object sender, EventArgs e)
    {
        int i = 0;
        int id_c = 0;
        try
        {            
            AIS.Content c = new AIS.Content();
            string id_contenu = "" + Session["id_contenu"];
            if (!string.IsNullOrEmpty(id_contenu))
            {                
                int.TryParse(id_contenu, out i);
                if (i > 0)
                {
                    c.id = i;
                }
            }

            c.published = "" + Session["publie"];
            c.id_user = UserInfo.UserID;
            c.photo = HF_Logo.Value;
            c.text = TXT_Editor.Content ;
            c.title = TBX_Titre.Text.Trim();
            c.type = "Annonce";
            c.textFile = TXT_Url_Texte.Text.Trim();

            if (RBT_Demande.Checked == true)
            {
                c.announcementType = "demande";
            }
            else
            {
                c.announcementType = "offre";
            }

            Session["id_contenu"] = null;

            id_c = DataMapping.Insert_Content(c);

            Session["Insert"] = null;
            Session["publie"] = null;

            if (id_c > 0)
            {
                if (Session[HF_Logo.Value] != null)
                {
                    string chemin = PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + id_c + "/" + HF_Logo.Value;
                    DirectoryInfo d = new DirectoryInfo(Server.MapPath(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + id_c + "/"));
                    if (!d.Exists)
                    {
                        d.Create();
                    }
                    File.WriteAllBytes(Server.MapPath(chemin), ((Media)Session[HF_Logo.Value]).content);

                    Session[HF_Logo.Value] = null;
                }

                if (Session[HL_Url.Text] != null)
                {
                    string chemin = PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + id_c + "/" + HL_Url.Text;
                    DirectoryInfo d = new DirectoryInfo(Server.MapPath(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + id_c + "/"));
                    if (!d.Exists)
                    {
                        d.Create();
                    }
                    File.WriteAllBytes(Server.MapPath(chemin), ((Media)Session[HL_Url.Text]).content);

                    Session[HL_Url.Text] = null;
                }            
            }
            else
            {
                throw new Exception("");
            }
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
            //retour à l'annonce
            Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(Annoncetabid), "id_contenu", "" + i));
        }

        if (id_c > 0)
        {
            if (DataMapping.Sub_Active_by_id_content(id_c, "Annonce") == true || UserInfo.IsSuperUser)
            {
                //retour à l'annonce
                Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(Annoncetabid), "id_contenu", "" + id_c));
            }
            else
            {
                string s = Functions.UrlAddParam(Globals.NavigateURL(Dontabid), "id_contenu", "" + id_c);
                Response.Redirect(s);
            }
        }
    }

    protected void BT_Annuler_Click(object sender, EventArgs e)
    {
        if (Session["Insert"] == "o")
        {
            if (Session["id_contenu"] != null)
            {
                //Le user a voulu créer une annonce mais le user n'a pas validé donc, il faut la supprimer
                int idcontenu = 0;
                int.TryParse(Session["id_contenu"].ToString(), out idcontenu);
                if (idcontenu > 0)
                {
                    if (DataMapping.Delete_Content(idcontenu, UserInfo.UserID) > 0)
                    {
                        Session["Insert"] = null;
                        Session["id_contenu"] = null;
                        Session[HF_Logo.Value] = null;
                        Session[HL_Url.Text] = null;
                        Session["publie"] = null;

                        //retour à l'espace pro
                        Response.Redirect(Globals.NavigateURL(ProTabId));
                    }
                }
            }
        }
        else
        {
            Session["Insert"] = null;
            Session["id_contenu"] = null;
            Session[HF_Logo.Value] = null;
            Session[HL_Url.Text] = null;
            Session["publie"] = null;

            //retour à l'annonce
            Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(Annoncetabid), "id_contenu", "" + id_contenu));
        }
    }
   
}