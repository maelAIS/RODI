﻿
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

public partial class DesktopModules_AIS_Page_Member_Edit_PageMemberEdit : PortalModuleBase
{
    int UserIdQuery = 0;
    Member membre;
    Affectation affectation;
    AIS.Content contenu;

    DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();
    int Presentationtabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModuleId)["Presentationtabid"], out t);
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

    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.IsInRole(Const.ROLE_MEMBERS) || UserInfo.IsSuperUser)
        {
            int.TryParse("" + Request.QueryString["UserId"], out UserIdQuery);

            if (UserInfo.IsSuperUser && UserIdQuery <= 0)
            {
                UserIdQuery = UserInfo.UserID;
            }

            if ((UserIdQuery > 0 && UserInfo.UserID == UserIdQuery) || UserInfo.IsSuperUser)// seul le super user et le propriétaire de la page peut accéder à cette page de modif
            {
                if (IsPostBack == false)
                {
                    if (UserInfo.IsSuperUser)
                    {
                        Binding_Panel1();
                    }
                    else
                    {
                        membre = DataMapping.GetMemberByUserID(UserIdQuery);

                        if (membre != null && membre.id != null && membre.id > 0 && membre.nim > 0)
                        {
                            affectation = DataMapping.GetAffectation(membre.nim, DateTime.Now.Year);
                            contenu = DataMapping.GetContentPagePro(UserIdQuery);

                            Binding_Panel1();
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
                    }
                }
            }
            else //if (UserIdQuery > 0)
            {
                if(!Request.IsAuthenticated)
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
    }

    protected void Binding_Panel1()
    {
        string nom = "";
        if (membre != null && membre.id != null && membre.id > 0)
        {
            nom = nom + membre.name + "  " + membre.surname;
        }

        if (!string.IsNullOrEmpty(nom))
        {
            LBL_Nom_Prenom.Text = nom;
        }
        else
        {
            if (!UserInfo.IsSuperUser)
                LBL_Nom_Prenom.Visible = false;
        }



        if (membre != null && membre.id != null && membre.id > 0 && !string.IsNullOrEmpty(membre.industry))
        {
            LBL_Classification.Text = "" + membre.industry;
        }
        else
        {
            if (!UserInfo.IsSuperUser) 
                LBL_Classification.Visible = false;
        }

        if(membre != null && membre.id != null && membre.id > 0)
        {
            IMG_Photo.ImageUrl = membre.GetPhoto();
            //HF_Photo.Value = membre.photo;
            //BT_Effacer_Photo.Visible = membre.photo != "";
        }

        // Custum image manager
        string filename_Img = Functions.ClearFileName(PortalSettings.Current.HomeDirectory + Const.CONTENT_PRESENTATION_PREFIX + UserIdQuery + "/");
        DirectoryInfo d = new DirectoryInfo(Server.MapPath(PortalSettings.Current.HomeDirectory + Const.CONTENT_PRESENTATION_PREFIX + UserIdQuery + "/"));
        if (!d.Exists)
        {
            d.Create();
        }
        TXT_Editor.ImageManager.ViewPaths = new string[] { filename_Img };
        TXT_Editor.ImageManager.UploadPaths = new string[] { filename_Img };
        TXT_Editor.ImageManager.DeletePaths = new string[] { filename_Img };
        // Custum document manager
        string filename_Doc = Functions.ClearFileName(PortalSettings.Current.HomeDirectory + Const.CONTENT_PRESENTATION_PREFIX + UserIdQuery + "/");
        TXT_Editor.DocumentManager.ViewPaths = new string[] { filename_Doc };
        TXT_Editor.DocumentManager.UploadPaths = new string[] { filename_Doc };
        TXT_Editor.DocumentManager.DeletePaths = new string[] { filename_Doc };
        //size
        TXT_Editor.DocumentManager.MaxUploadFileSize = 4194304;
        TXT_Editor.ImageManager.MaxUploadFileSize = 1048576;

        if (affectation != null && !string.IsNullOrEmpty(affectation.function))
        {
            LBL_Fonction.Text = "" + affectation.function;
        }
        else
        {
            if (!UserInfo.IsSuperUser) 
                LBL_Fonction.Visible = false;
        }

        if (contenu != null)
        {
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

            if (!string.IsNullOrEmpty(contenu.company))
            {
                TBX_Societe.Text = contenu.company;
            } 

            IMG_Logo.ImageUrl = contenu.GetPresentationPhoto();
            HF_Logo.Value = contenu.photo;
            BT_Effacer_Logo.Visible = contenu.photo != "";

            if (!string.IsNullOrEmpty(contenu.url))
            {
                TBX_URL.Text = contenu.url;
            }
        }
    }   

    //protected void BT_Upload_Photo_Click(object sender, EventArgs e)
    //{
    //    if (FU_Photo.UploadedFiles.Count > 0)
    //    {
    //        UploadedFile file = FU_Photo.UploadedFiles[0];
    //        string filename = Functions.ClearFileName(membre.nom + ".jpg");

    //        Bitmap bmp = new Bitmap(file.InputStream);
    //        bmp = Functions.ThumbByWidth(bmp, Const.MEMBRES_PHOTOS_WIDTH);
    //        MemoryStream ms = new MemoryStream();
    //        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
    //        HF_Photo.Value = filename;

    //        Media media = new Media();
    //        media.content = ms.GetBuffer();
    //        media.content_size = media.content.Length;
    //        media.dt = DateTime.Now;
    //        media.w = bmp.Width;
    //        media.h = bmp.Height;
    //        media.name = filename;
    //        media.content_type = "image/jpeg";
    //        Session[HF_Photo.Value] = media;

    //        IMG_Photo.ImageUrl = Const.MEDIA_VIEW_URL + "?id=" + filename;
    //        BT_Effacer_Photo.Visible = true;
    //    }
    //}

    //protected void BT_Effacer_Photo_Click(object sender, EventArgs e)
    //{
    //    BT_Effacer_Photo.Visible = false;
    //    Session[HF_Photo.Value] = null;
    //    HF_Photo.Value = "";
    //    if (membre.civilite == "M")
    //        IMG_Photo.ImageUrl = Const.MEMBRES_NOPHOTO_H;
    //    else
    //        IMG_Photo.ImageUrl = Const.MEMBRES_NOPHOTO_F;
    //}

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

    protected void BT_Valider_Click(object sender, EventArgs e)
    {
        int id_c = 0;
        try
        {            
            AIS.Content c = new AIS.Content();
            string id_contenu = "" + Session["id_contenu"];
            if (!string.IsNullOrEmpty(id_contenu))
            {
                int i = 0;
                int.TryParse(id_contenu, out i);
                if (i > 0)
                {
                    c.id = i;
                }
            }
            
            c.id_user = UserInfo.UserID;
            c.photo = HF_Logo.Value;
            c.text = TXT_Editor.Content;
            c.title = TBX_Titre.Text.Trim();
            c.company = TBX_Societe.Text.Trim();
            c.type = "PagePro";
            c.url = TBX_URL.Text.Trim();

            string pub = "" + Session["publie"];
            if (pub.ToLower() == "o")
            {
                c.published = "o";
            }
            else
            {
                c.published = "n";
            }


            Session["publie"] = null;
            Session["id_contenu"] = null;

            id_c = DataMapping.Insert_Content(c);

            if (id_c > 0)
            {
                if (Session[HF_Logo.Value] != null)
                {
                    string chemin = PortalSettings.Current.HomeDirectory + Const.CONTENT_PRESENTATION_PREFIX + id_c + "/" + HF_Logo.Value;
                    DirectoryInfo d = new DirectoryInfo(Server.MapPath(PortalSettings.Current.HomeDirectory + Const.CONTENT_PRESENTATION_PREFIX + id_c + "/"));
                    if (!d.Exists)
                    {
                        d.Create();
                    }
                    File.WriteAllBytes(Server.MapPath(chemin), ((Media)Session[HF_Logo.Value]).content);

                    Session[HF_Logo.Value] = null;
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
            //retour à pagemembre
            Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(Presentationtabid), "UserId", "" + UserInfo.UserID));
        }

        if (id_c > 0)
        {
            if (DataMapping.Sub_Active(UserIdQuery, "PagePro") == true || UserInfo.IsSuperUser)
            {
                //retour à pagemembre
                Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(Presentationtabid), "UserId", "" + UserInfo.UserID));
            }
            else
            {
                Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(Dontabid), "id_contenu", "" + id_c));
            }
        }
    }

    protected void BT_Annuler_Click(object sender, EventArgs e)
    {
        Session["publie"] = null;
        Session["id_contenu"] = null;
        Session[HF_Logo.Value] = null;

        //retour à pagemembre
        Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(Presentationtabid), "UserId", "" + UserInfo.UserID));
    }
   
}