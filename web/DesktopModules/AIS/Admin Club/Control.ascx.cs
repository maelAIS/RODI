
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


using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;
using DotNetNuke.Entities.Modules;
using Telerik.Web.UI;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Membership;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;

public partial class DesktopModules_AIS_Admin_Club_Control : PortalModuleBase
{
    public string messSupp = "Voulez-vous vraiment supprimer ce club";

    DotNetNuke.Entities.Modules.ModuleController objModules2 = new DotNetNuke.Entities.Modules.ModuleController();
    
    /// <summary>
    ///
    /// </summary>
    int tabid_EspMemb
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules2.GetModuleSettings(ModuleId)["EspMembtabid"], out t);
            return t;
        }
    }

    /// <summary>
    /// Lors du chargement de la page, synchronise les controles avec les données
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //if (IsPostBack)
            //{
                HF_Nb_Member.Value = messSupp;
                if (Functions.CurrentCric == 0)
                    lbl_noClub.Visible = true;
                else
                    lbl_noClub.Visible = false;
                if (Request.QueryString["ref"] == null || Request.QueryString["ref"] != "new")
                {
                    if (HF_Cric.Value != Functions.CurrentCric + "")
                    {
                        //HF_Cric.Value = "" + 6560;
                        HF_Cric.Value = "" + Functions.CurrentCric;

                        Club club = DataMapping.GetClub(Functions.CurrentCric);
                        //Club club = DataMapping.GetClub(6560);
                        if (club != null)
                        {
                            LBL_Nom.Text = club.name;

                            tbx_nom.Text = club.name;

                            TXT_Reunions.Content = club.meetings;
                            TXT_Texte.Content = club.text;
                            TXT_Url.Text = club.web;

                            TXT_Latitude.Text = club.latitude;
                            TXT_Longitude.Text = club.longitude;
                            TXT_Reunion_Adr1.Text = club.meeting_adr1;
                            TXT_Reunion_Adr2.Text = club.meeting_adr2;
                            TXT_Reunion_CP.Text = club.meeting_zip;
                            TXT_Reunion_Ville.Text = club.meeting_town;

                            tbx_adresse1.Text = club.adress_1;
                            tbx_adresse2.Text = club.adress_2;
                            tbx_adresse3.Text = club.adress_3;
                            tbx_cp.Text = club.zip;
                            tbx_ville.Text = club.town;
                            tbx_telephone.Text = club.telephone;
                            tbx_fax.Text = club.fax;
                            tbx_email.Text = club.email;
                            tbx_seo.Text = club.seo;
                            tbx_url.Text = club.web;
                            tbx_anciens_presidents.Text = club.former_presidents;

                            if (club.pennant != "")
                            {
                                IMG_Logo.ImageUrl = club.GetPennant();
                            }
                            else
                            {
                                IMG_Logo.ImageUrl = Const.MEMBERS_NOPHOTO_F;
                            }
                            HF_Logo.Value = club.pennant;
                            BT_Effacer_Logo.Visible = club.pennant != "";

                            //BT_Valider.Style.Add("visibility", "hidden");
                            //TXT_Texte.Attributes.Add("onchange", "javascript: AfficheValider();");
                            //TXT_Reunions.Attributes.Add("onchange", "javascript: AfficheValider();");
                            //TXT_Longitude.Attributes.Add("onchange", "javascript: AfficheValider();");
                            //TXT_Latitude.Attributes.Add("onchange", "javascript: AfficheValider();");
                            //TXT_Reunion_Adr1.Attributes.Add("onchange", "javascript: AfficheValider();");
                            //TXT_Reunion_Adr2.Attributes.Add("onchange", "javascript: AfficheValider();");
                            //TXT_Reunion_CP.Attributes.Add("onchange", "javascript: AfficheValider();");
                            //TXT_Reunion_Ville.Attributes.Add("onchange", "javascript: AfficheValider();");
                            //TXT_Url.Attributes.Add("onchange", "javascript: AfficheValider();");

                            if (club.club_type == Const.Club_Rotaract && (UserInfo.IsInRole(Const.ROLE_ADMIN_ROTARACT) || UserInfo.IsSuperUser))
                            {
                                pnl_Club.Visible = true;
                                pnl_Reunion.Visible = true;
                                Label9.Visible = false;
                                TXT_Url.Visible = false;
                                lblnom.Visible = false;
                                LBL_Nom.Visible = false;
                                BT_Ajout.Visible = false;

                                int cric = 0;
                                int.TryParse(HF_Cric.Value, out cric);
                                if (cric != 0)
                                {
                                    List<Member> ListeM = DataMapping.ListMembers(cric: cric);
                                    if (ListeM != null)
                                    {
                                        if (ListeM.Count == 1)
                                        {
                                            HF_Nb_Member.Value = HF_Nb_Member.Value + "? Attention, le membre de ce club sera supprimé!";
                                        }
                                        else if (ListeM.Count > 1)
                                        {
                                            HF_Nb_Member.Value = HF_Nb_Member.Value + "? Attention, les " + ListeM.Count() + " membres de ce club seront supprimés!";
                                        }
                                        else
                                        {
                                            HF_Nb_Member.Value = HF_Nb_Member.Value + " (aucun membre dans ce club)?";
                                        }
                                    }
                                    else
                                    {
                                        HF_Nb_Member.Value = HF_Nb_Member.Value + " (aucun membre dans ce club)?";
                                    }

                                    BT_Supprimer.Visible = true;
                                    //    BT_Supprimer.Enabled = true;
                                    //}
                                    //else
                                    //{                                    
                                    //    BT_Supprimer.Visible = true;
                                    //    BT_Supprimer.Enabled = false;
                                    //    if (ListeM.Count == 1)
                                    //    {
                                    //        BT_Supprimer.ToolTip = "Impossible de supprimer le club car il y a " + ListeM.Count + " membre rattaché au club !";
                                    //    }
                                    //    else if (ListeM.Count > 1)
                                    //    {
                                    //        BT_Supprimer.ToolTip = "Impossible de supprimer le club car il y a " + ListeM.Count + " membres rattachés au club !";
                                    //    }
                                    //}
                                    //}
                                    //else
                                    //{
                                    //    BT_Supprimer.Visible = false;
                                    //}
                                }
                                else
                                {
                                    pnl_Club.Visible = false;
                                    pnl_Reunion.Visible = false;
                                    Label9.Visible = true;
                                    TXT_Url.Visible = true;
                                    lblnom.Visible = true;
                                    LBL_Nom.Visible = true;
                                    BT_Supprimer.Visible = false;
                                    BT_Ajout.Visible = false;
                                }
                            }
                            else
                            {
                                BT_Supprimer.Visible = false;
                                BT_Ajout.Visible = false;
                            }
                        }
                        P1.Visible = HF_Cric.Value != "0";
                    }
                    
                }
                else //Ajout club ROTARACT
                {
                    if (UserInfo.IsInRole(Const.ROLE_ADMIN_ROTARACT) || UserInfo.IsSuperUser)
                    {
                        pnl_Club.Visible = true;
                        pnl_Reunion.Visible = true;
                        Label9.Visible = false;
                        TXT_Url.Visible = false;
                        lblnom.Visible = false;
                        LBL_Nom.Visible = false;
                        BT_Supprimer.Visible = false;
                        BT_Valider.Visible = false;
                        BT_Ajout.Visible = true;

                        BT_Effacer_Logo.Visible = false;
                        IMG_Logo.ImageUrl = Const.MEMBERS_NOPHOTO_H;
                    }
                }
            //}
            if (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT))
                BT_Presentation.Visible = true;
            else
                BT_Presentation.Visible = false;

        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    /// <summary>
    /// Permet à l'utilisateur d'uploader un logo
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Upload_Logo_Click(object sender, EventArgs e)
    {
        try
        {
            if (FU_Logo.UploadedFiles.Count > 0)
            {
                UploadedFile file = FU_Logo.UploadedFiles[0];

                string filename = "";
                bool erreur = false;
                if (Request.QueryString["ref"] == null || Request.QueryString["ref"] != "new")
                {
                    filename = Functions.ClearFileName("fanion_" + HF_Cric.Value + ".jpg");
                }
                else
                {
                    if (!string.IsNullOrEmpty(tbx_nom.Text))
                    {
                        filename = Functions.ClearFileName("fanion_" + tbx_nom.Text.ToLower().Trim() + ".jpg");
                    }
                    else
                    {
                        erreur = true;
                        
                    }
                }

                if (erreur == false)
                {
                    Bitmap bmp = new Bitmap(file.InputStream);
                    bmp = Functions.ThumbByWidth(bmp, Const.PENNANT_PHOTOS_WIDTH);
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
                else
                {
                    BT_Effacer_Logo.Visible = false;
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Vous devez saisir le nom du club avant!');</script>");
                }
            }
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }
    
    /// <summary>
    /// Permet à l'utilisateur de supprimer un logo
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Effacer_Logo_Click(object sender, EventArgs e)
    {
        try
        {
            BT_Effacer_Logo.Visible = false;
            Session[HF_Logo.Value] = null;
            HF_Logo.Value = "";
            IMG_Logo.ImageUrl = Const.MEMBERS_NOPHOTO_F;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    /// <summary>
    /// Permet à l'utilisateur d'enregistrer les modifications apportées
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Valider_Click(object sender, EventArgs e)
    {
        try
        {
            int cric = 0;
            int.TryParse(HF_Cric.Value, out cric);
            if (cric != 0)
            {
                Club club = DataMapping.GetClub(cric);
                //Club club = DataMapping.GetClub(6560);
                if (club != null)
                {
                    club.meetings = TXT_Reunions.Content;
                    club.text = TXT_Texte.Content;
                    club.web = TXT_Url.Text.Trim();

                    if (club.club_type == Const.Club_Rotaract)
                    {
                        club.name = tbx_nom.Text ;

                        club.meeting_adr1 = TXT_Reunion_Adr1.Text;
                        club.meeting_adr2 = TXT_Reunion_Adr2.Text;
                        club.meeting_zip = TXT_Reunion_CP.Text;
                        club.meeting_town = TXT_Reunion_Ville.Text;
                        club.longitude = TXT_Longitude.Text;
                        club.latitude = TXT_Latitude.Text;

                        club.adress_1 = tbx_adresse1.Text;
                        club.adress_2 = tbx_adresse2.Text;
                        club.adress_3 = tbx_adresse3.Text;
                        club.zip = tbx_cp.Text;
                        club.town = tbx_ville.Text;
                        club.telephone = tbx_telephone.Text;
                        club.fax = tbx_fax.Text;
                        club.email = tbx_email.Text;
                        club.seo = tbx_seo.Text;
                        club.web = tbx_url.Text.Trim();
                        club.former_presidents = tbx_anciens_presidents.Text;

                        club.pennant = HF_Logo.Value;
                    }

                    if (DataMapping.UpdateClub(club))
                    {
                        // BT_Valider.Style.Add("visibility", "hidden");
                        if (club.club_type == Const.Club_Rotaract)
                        {
                            if (Session[HF_Logo.Value] != null)
                            {
                                string chemin = PortalSettings.Current.HomeDirectory + Const.CLUBS_PREFIX + Const.PENNANT_PREFIX + HF_Logo.Value;
                                DirectoryInfo d = new DirectoryInfo(Server.MapPath(PortalSettings.Current.HomeDirectory + Const.CLUBS_PREFIX + Const.PENNANT_PREFIX));
                                if (!d.Exists)
                                {
                                    d.Create();
                                }
                                File.WriteAllBytes(Server.MapPath(chemin), ((Media)Session[HF_Logo.Value]).content);

                                Session[HF_Logo.Value] = null;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Update du club cric : " + cric + " impossible!");
                    }
                }
            }
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
    }
    
    /// <summary>
    /// Permet de supprimer le club
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Supprimer_Click(object sender, EventArgs e)
    {
        try
        {
            int cric = 0;
            int.TryParse(HF_Cric.Value, out cric);
            if (cric != 0)
            {
                if (DataMapping.DeleteClub(cric))
                {
                    HF_Cric.Value = "0";
                    Response.Redirect(Globals.NavigateURL(tabid_EspMemb));
                }
            }
            else
            {
                throw new Exception("Supression du club cric : " + cric + " impossible!");
            }
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }
    
    /// <summary>
    /// Permet d'ajouter un nouveau club
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Ajout_Click(object sender, EventArgs e)
    {
        try
        {
            Club club = new Club();

            club.meetings = "" + TXT_Reunions.Content;
            club.text = "" + TXT_Texte.Content;
            club.name = "" + tbx_nom.Text ;

            club.meeting_adr1 = "" + TXT_Reunion_Adr1.Text;
            club.meeting_adr2 = "" + TXT_Reunion_Adr2.Text;
            club.meeting_zip = "" + TXT_Reunion_CP.Text;
            club.meeting_town = "" + TXT_Reunion_Ville.Text;
            club.longitude = "" + TXT_Longitude.Text;
            club.latitude = "" + TXT_Latitude.Text;

            club.adress_1 = "" + tbx_adresse1.Text;
            club.adress_2 = "" + tbx_adresse2.Text;
            club.adress_3 = "" + tbx_adresse3.Text;
            club.zip = "" + tbx_cp.Text;
            club.town = "" + tbx_ville.Text;
            club.telephone = "" + tbx_telephone.Text;
            club.fax = "" + tbx_fax.Text;
            club.email = "" + tbx_email.Text;
            club.seo = "" + tbx_seo.Text;
            club.web = "" + tbx_url.Text.Trim();
            club.former_presidents = "" + tbx_anciens_presidents.Text;            

            if (!string.IsNullOrEmpty(HF_Logo.Value))
            {
                club.pennant = HF_Logo.Value;
            }

            club.district_id = Const.DISTRICT_ID;
            club.club_type = Const.Club_Rotaract;

            int NewCric = DataMapping.InsertClub(club);
            if (NewCric > 0)
            {
                HF_Cric.Value = "" + NewCric;

                if (Session[HF_Logo.Value] != null)
                {
                    string chemin = PortalSettings.Current.HomeDirectory + Const.CLUBS_PREFIX + Const.PENNANT_PREFIX + HF_Logo.Value;
                    DirectoryInfo d = new DirectoryInfo(Server.MapPath(PortalSettings.Current.HomeDirectory + Const.CLUBS_PREFIX + Const.PENNANT_PREFIX));
                    if (!d.Exists)
                    {
                        d.Create();
                    }
                    File.WriteAllBytes(Server.MapPath(chemin), ((Media)Session[HF_Logo.Value]).content);

                    Session[HF_Logo.Value] = null;
                }
                Response.Redirect(Globals.NavigateURL(tabid_EspMemb));
            }
            else
            {
                throw new Exception("Insert du club impossible!");
            }

        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected void BT_Presentation_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/" + Functions.CurrentClub.seo + "/");
    }
}