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

public partial class DesktopModules_AIS_Admin_Members_Liste : PortalModuleBase
{
    DotNetNuke.Entities.Modules.ModuleController objModules2 = new DotNetNuke.Entities.Modules.ModuleController();
    int presentationtabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules2.GetModuleSettings(ModuleId)["presentationtabid"], out t);
            return t;
        }
    }

    string mode
    {
        get
        {
            return "" + objModules2.GetModuleSettings(ModuleId)["mode"];
            
        }
    }

    /// <summary>
    /// Affiche la liste des membres selon les droits de l'utilisateur
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        
        bool estunadg = DataMapping.isADG();

        if ("" + Functions.CurrentCric != HF_Cric.Value)
        {
            HF_Cric.Value = "" + Functions.CurrentCric;
            GridView1.PageIndex = 0;
            Panel1.Visible = true;
            Panel2.Visible = false;
            pnl_Rotaract.Visible = false;
            pnl_Bouton.Visible = false;
            
        }
        RefreshGrid();

        BT_Upload_Photo.Visible = (UserInfo.IsSuperUser || estunadg || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT)) ;
        BT_Effacer_Photo.Visible = ((UserInfo.IsSuperUser || estunadg || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB)));
        RB_Autoriser_Publication.Enabled = (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || estunadg || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT));
        BT_Export_CSV.Visible = (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT)) || ((UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || estunadg) /*&& Functions.CurrentCric != 0*/);
        BT_Export_XLS.Visible = (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT)) || ((UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || estunadg) /*&& Functions.CurrentCric != 0*/);
        BT_Valider.Visible = (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || estunadg || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT));
        BT_Carte_Member_Recto.Visible = UserInfo.IsSuperUser ||( Functions.CurrentCric != 0 && ( UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || estunadg || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT)));
        BT_Carte_Member_Verso.Visible = UserInfo.IsSuperUser || (Functions.CurrentCric != 0 && (UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || estunadg || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT)));
        BT_Carte_Member_Recto_DOC.Visible = UserInfo.IsSuperUser || (Functions.CurrentCric != 0 && (UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || estunadg || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT)));
        BT_Carte_Member_Verso_DOC.Visible = UserInfo.IsSuperUser || (Functions.CurrentCric != 0 && (UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || estunadg || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT)));
        BT_Carte_Member_Recto_Docx.Visible = UserInfo.IsSuperUser || (Functions.CurrentCric != 0 && (UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || estunadg || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT)));
        BT_Carte_Member_Verso_Docx.Visible = UserInfo.IsSuperUser || (Functions.CurrentCric != 0 && (UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || estunadg || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT)));


        if (Functions.CurrentCric != 0 &&  (UserInfo.IsInRole(Const.ROLE_ADMIN_ROTARACT) || UserInfo.IsSuperUser))
        {
            BT_Upload_Photo2.Visible = true;
            BT_Effacer_Photo2.Visible = true;
            RB_Autoriser_Publication.Visible = true;
            BT_Valider.Visible = true;

            BT_Export_CSV.Visible = true;
            BT_Export_XLS.Visible = true;            
            BT_Carte_Member_Recto.Visible = true;
            BT_Carte_Member_Verso.Visible = true;
            BT_Carte_Member_Recto_DOC.Visible = true;
            BT_Carte_Member_Verso_DOC.Visible = true;
            BT_Carte_Member_Recto_Docx.Visible = true;
            BT_Carte_Member_Verso_Docx.Visible = true;

        }

        if (!string.IsNullOrEmpty(HF_Cric.Value) && HF_Cric.Value != "0")
        {
            Club c = DataMapping.GetClub(int.Parse(HF_Cric.Value));
            
            if ((UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || estunadg || UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT)) && c.club_type == Const.Club_Rotaract)
            {
                btn_Ajout.Visible = true;                
            }
            else
            {
                btn_Ajout.Visible = false;
            }
        }
        else
        {
            btn_Ajout.Visible = false;
        }

        if(!string.IsNullOrEmpty(hf_Ajout.Value) && hf_Ajout.Value == "o")
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            pnl_Rotaract.Visible = true;
            pnl_Bouton.Visible = true;
            BT_VCF.Visible = false;
            BT_CreateDNNUser.Visible = false;
            BT_Supprimer.Visible = false;
            BT_Valider.Visible = false;
            BT_Ajouter.Visible = true;
        }

        if (!string.IsNullOrEmpty(hf_Supp.Value) && hf_Supp.Value == "o")
        {
            Panel1.Visible = false;
            pnl_Bouton.Visible = true;
            BT_Ajouter.Visible = false;
            Panel2.Visible = false;
            pnl_Rotaract.Visible = true;
            BT_Supprimer.Visible = true;
            rbtl_radie.Enabled = true;
        }

        if(mode=="club" && Functions.CurrentCric==0)
        {
            lbl_noClubSelected.Visible = true;
            Panel1.Visible = false; 
        }
        else
        {
            lbl_noClubSelected.Visible = false;
            Panel1.Visible = true;
            
        }
        if (mode == "district")
            pnl_exports.Visible = false;
        else
            pnl_exports.Visible = true;
        


    }

    /// <summary>
    /// Applique la commande sélectionnée sur le GridView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Sort":
                
                break;
            case "detail":
                try
                {
                    GridView gv = sender as GridView;
                    int index = (gv.PageIndex * gv.PageSize) + Convert.ToInt32(e.CommandArgument);
                    List<Member> membres = gv.DataSource as List<Member>;

                    Member membre = membres[index];
                    HF_id.Value = "" + membre.id;

                    RotarienBinding(membre);
                    RotaractBinding(membre);
                    Club c = DataMapping.GetClub(membre.cric);
                    hf_type_club.Value = c.club_type;

                    Panel1.Visible = false;
                    pnl_Bouton.Visible = true;
                    BT_Ajouter.Visible = false;
                    UserInfo ui = UserController.GetUserById(Globals.GetPortalSettings().PortalId, membre.userid);
                    
                    if (membre.nim == 0 && !ui.IsInRole(Const.ROLE_ADMIN_ROTARACT))
                    {
                        FU_Photo.Visible = false;
                        BT_Upload_Photo.Visible = false;
                    }
                    else
                    {
                        FU_Photo.Visible = true;
                        BT_Upload_Photo.Visible = true;
                    }

                    if ((UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || DataMapping.isADG() || UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT)) && c.club_type == Const.Club_Rotaract)
                    {
                        Panel2.Visible = false;
                        pnl_Rotaract.Visible = true;
                        BT_Supprimer.Visible = true;
                        hf_Supp.Value = "o";
                        rbtl_radie.Enabled = true;
                    }
                    else if ((membre.userid == UserInfo.UserID || UserInfo.IsSuperUser) && c.club_type == Const.Club_Rotaract) //Cas où le membre loggué va sur sa fiche et que c'est un ROTARACT
                    {
                        Panel2.Visible = false;
                        pnl_Rotaract.Visible = true;
                        BT_Supprimer.Visible = false;
                        BT_Valider.Visible = true;
                        RB_Autoriser_Publication.Visible = true;
                        rbtl_radie.Enabled = false;
                    }
                    else
                    {
                        Panel2.Visible = true;
                        pnl_Rotaract.Visible = false;
                        BT_Supprimer.Visible = false;
                    }


                    BT_CreateDNNUser.Visible = (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT));
                    btn_suppMember.Visible = UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT);
                    
                }
                catch( Exception ee)
                {
                    Functions.Error(ee);
                }

                break;
        }
    }
    
    /// <summary>
    /// Permet le tri du GridView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        tri.Value = ""+e.SortExpression;
        sens.Value= sens.Value=="ASC"?sens.Value="DESC":sens.Value="ASC";
        RefreshGrid();
    }

    /// <summary>
    /// Permet de changer de page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (GridView1.PageIndex == e.NewPageIndex)
        {
            e.Cancel = true;
            return;
        }
        GridView1.PageIndex = e.NewPageIndex;
        RefreshGrid();        
    }

    /// <summary>
    /// Si le membre possède une présentation, crée un hyperlien qui y amène
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem == null)
            return;        

        HyperLink hlk = (HyperLink)e.Row.FindControl("HLK_Presentation");
        if (((Member)e.Row.DataItem).presentation == true)
        {
            e.Row.Font.Bold = true;
            hlk.NavigateUrl = Functions.UrlAddParam(Globals.NavigateURL(presentationtabid), "UserId", "" + ((Member)e.Row.DataItem).userid);
        }
        else
        {
            hlk.Visible = false;
        }
    }

    /// <summary>
    /// Rafraichit le GridView en fonction du tri défini par le HiddenField tri. Dans le cas d'une présentation, on trie les membres qui ont une présentation
    /// </summary>
    void RefreshGrid()
    {
        try
        {
            List<Member> membres = new List<Member>();
            if (mode == "club")
            {
                if (!DataMapping.isADG() || Functions.CurrentCric != 0)
                {

                    if (tri.Value != "presentation")
                    {
                        membres = DataMapping.ListMembers(cric: Functions.CurrentCric, sort: tri.Value + " " + sens.Value, index: GridView1.PageIndex, max: GridView1.PageSize, criterion: TXT_Critere.Text);
                    }
                    else
                    {
                        membres = DataMapping.ListMembers(cric: Functions.CurrentCric, sort: "name ASC", index: GridView1.PageIndex, max: GridView1.PageSize, criterion: TXT_Critere.Text);

                    }



                    List<int> lesPresentations = DataMapping.Get_List_Presentation_Active();

                    if (lesPresentations != null && membres != null)
                    {
                        foreach (int i in lesPresentations)
                        {
                            Member lemembre = membres.Find(m => m.userid == i);
                            if (lemembre != null)
                            {
                                lemembre.presentation = true;
                            }
                        }
                    }

                    lbl_TousADG.Visible = false;
                    GridView1.Visible = true;
                    Label1.Visible = true;
                    TXT_Critere.Visible = true;
                    LBL_Nb.Visible = true;
                }


                else
                {

                    lbl_TousADG.Visible = true;
                    GridView1.Visible = false;
                    Label1.Visible = false;
                    TXT_Critere.Visible = false;
                    LBL_Nb.Visible = false;

                    #region commentaire

                    //List<Domaine> listeDom = DataMapping.GetListeDomaine("ADG", "");
                    //foreach (Domaine dom in listeDom)
                    //{
                    //    if (UserInfo.IsInRole(dom.sous_domaine))
                    //    {
                    //        foreach (Club club in DataMapping.ListeClubs())
                    //        {
                    //            if (club.cric == int.Parse(dom.valeur))
                    //            {
                    //                foreach (Member membre in DataMapping.ListMembers(cric: int.Parse(dom.valeur), index: GridView1.PageIndex, max: GridView1.PageSize, criterion: TXT_Critere.Text))
                    //                {
                    //                    if (membre == null)
                    //                        throw new Exception("Member null");
                    //                    int j = 0;
                    //                    if (membres.Count == 0)
                    //                        membres.Add(membre);
                    //                    else
                    //                    {
                    //                        if (tri.Value == "nim" && sens.Value == "ASC")
                    //                        {
                    //                            for (int i = 0; i < membres.Count; i++)
                    //                            {
                    //                                if (membre.nim >= membres[i].nim)
                    //                                {
                    //                                    membres.Insert(i, membre);
                    //                                    j = i;
                    //                                    break;
                    //                                }
                    //                            }
                    //                            if (j == 0)
                    //                                membres.Add(membre);
                    //                        }
                    //                        else if (tri.Value == "nim" && sens.Value == "DESC")
                    //                        {
                    //                            for (int i = 0; i < membres.Count; i++)
                    //                            {
                    //                                if (membre.nim <= membres[i].nim)
                    //                                {
                    //                                    membres.Insert(i, membre);
                    //                                    j = i;
                    //                                    break;
                    //                                }
                    //                            }
                    //                            if (j == 0)
                    //                                membres.Add(membre);
                    //                        }
                    //                        else if (tri.Value == "nom" && sens.Value == "ASC")
                    //                        {
                    //                            for (int i = 0; i < membres.Count; i++)
                    //                            {
                    //                                if (membre.nom.ToUpper().CompareTo(membres[i].nom.ToUpper()) == -1)
                    //                                {
                    //                                    membres.Insert(i, membre);
                    //                                    j = i;
                    //                                    break;
                    //                                }
                    //                            }
                    //                            if (j == 0)
                    //                                membres.Add(membre);
                    //                        }
                    //                        else if (tri.Value == "nom" && sens.Value == "DESC")
                    //                        {
                    //                            for (int i = 0; i < membres.Count; i++)
                    //                            {
                    //                                if (membre.nom.ToUpper().CompareTo(membres[i].nom.ToUpper()) != -1)
                    //                                {
                    //                                    membres.Insert(i, membre);
                    //                                    j = i;
                    //                                    break;
                    //                                }
                    //                            }
                    //                            if (j == 0)
                    //                                membres.Add(membre);
                    //                        }
                    //                        else if (tri.Value == "prenom" && sens.Value == "ASC")
                    //                        {
                    //                            for (int i = 0; i < membres.Count; i++)
                    //                            {
                    //                                if (membre.prenom.ToUpper().CompareTo(membres[i].prenom.ToUpper()) == -1)
                    //                                {
                    //                                    membres.Insert(i, membre);
                    //                                    j = i;
                    //                                    break;
                    //                                }
                    //                            }
                    //                            if (j == 0)
                    //                                membres.Add(membre);
                    //                        }
                    //                        else if (tri.Value == "prenom" && sens.Value == "DESC")
                    //                        {
                    //                            for (int i = 0; i < membres.Count; i++)
                    //                            {
                    //                                if (membre.prenom.ToUpper().CompareTo(membres[i].prenom.ToUpper()) != -1)
                    //                                {
                    //                                    membres.Insert(i, membre);
                    //                                    j = i;
                    //                                    break;
                    //                                }
                    //                            }
                    //                            if (j == 0)
                    //                                membres.Add(membre);
                    //                        }
                    //                        else if (tri.Value == "email" && sens.Value == "ASC")
                    //                        {
                    //                            for (int i = 0; i < membres.Count; i++)
                    //                            {
                    //                                if (membre.email.ToUpper().CompareTo(membres[i].email.ToUpper()) == -1)
                    //                                {
                    //                                    membres.Insert(i, membre);
                    //                                    j = i;
                    //                                    break;
                    //                                }
                    //                            }
                    //                            if (j == 0)
                    //                                membres.Add(membre);
                    //                        }
                    //                        else if (tri.Value == "email" && sens.Value == "DESC")
                    //                        {
                    //                            for (int i = 0; i < membres.Count; i++)
                    //                            {
                    //                                if (membre.email.ToUpper().CompareTo(membres[i].email.ToUpper()) != -1)
                    //                                {
                    //                                    membres.Insert(i, membre);
                    //                                    j = i;
                    //                                    break;
                    //                                }
                    //                            }
                    //                            if (j == 0)
                    //                                membres.Add(membre);
                    //                        }
                    //                        else if (tri.Value == "nom_club" && sens.Value == "ASC")
                    //                        {
                    //                            for (int i = 0; i < membres.Count; i++)
                    //                            {
                    //                                if (membre.club_name.ToUpper().CompareTo(membres[i].club_name.ToUpper()) == -1)
                    //                                {
                    //                                    membres.Insert(i, membre);
                    //                                    j = i;
                    //                                    break;
                    //                                }
                    //                            }
                    //                            if (j == 0)
                    //                                membres.Add(membre);
                    //                        }
                    //                        else if (tri.Value == "nom_club" && sens.Value == "DESC")
                    //                        {
                    //                            for (int i = 0; i < membres.Count; i++)
                    //                            {
                    //                                if (membre.club_name.ToUpper().CompareTo(membres[i].club_name.ToUpper()) != -1)
                    //                                {
                    //                                    membres.Insert(i, membre);
                    //                                    j = i;
                    //                                    break;
                    //                                }
                    //                            }
                    //                            if (j == 0)
                    //                                membres.Add(membre);
                    //                        }
                    //                        else if(tri.Value== "presentation")
                    //                        {
                    //                            for (int i = 0; i < membres.Count; i++)
                    //                            {
                    //                                if (membre.nom.ToUpper().CompareTo(membres[i].nom.ToUpper()) == -1)
                    //                                {
                    //                                    membres.Insert(i, membre);
                    //                                    j = i;
                    //                                    break;
                    //                                }
                    //                            }
                    //                            if (j == 0)
                    //                                membres.Add(membre);
                    //                        }

                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //}

                    //List<int> lesPresentations = DataMapping.Get_List_Presentation_Actif();

                    //if (lesPresentations != null && membres != null)
                    //{
                    //    foreach (int i in lesPresentations)
                    //    {
                    //        Member lemembre = membres.Find(m => m.userid == i);
                    //        if (lemembre != null)
                    //        {
                    //            lemembre.presentation = true;
                    //        }
                    //    }
                    //}
                    #endregion commentaire
                }







                
            }
            else
            {
                membres = DataMapping.ListMembers(criterion: TXT_Critere.Text);
            }

            
            
            GridView1.DataSource = membres;
            GridView1.DataBind();
            string s = membres.Count > 1 ? "s" : "";
            LBL_Nb.Text = membres.Count + " membre" + s;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }


    /// <summary>
    /// Récupère le nom du club
    /// </summary>
    /// <returns></returns>
    string GetNomClub()
    {
        if (Functions.CurrentClub != null)
            return "du club "+Functions.CurrentClub.name;
        return "";
    }

    /// <summary>
    /// Permet d'exporter le GridView en fichier Excel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Export_XLS_Click(object sender, EventArgs e)
    {
        List<Member> membres = DataMapping.ListMembers(cric: Functions.CurrentCric, sort: "surname asc", max: int.MaxValue,criterion:TXT_Critere.Text);
        GridViewExport.DataSource = membres;
        GridViewExport.DataBind();

        Media media = DataMapping.ExportDataGridToXLS(GridViewExport, "Liste des membres"+GetNomClub()+".xls", Aspose.Cells.SaveFormat.Excel97To2003);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    /// <summary>
    /// Permet d'exporter le GridView en CSV
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Export_CSV_Click(object sender, EventArgs e)
    {
        List<Member> membres = DataMapping.ListMembers(cric: Functions.CurrentCric, sort: "name asc", max: int.MaxValue, criterion: TXT_Critere.Text);
        GridViewExport.DataSource = membres;
        GridViewExport.DataBind();

        Media media = DataMapping.ExportDataGridToXLS(GridViewExport, "Liste des membres" + GetNomClub() + ".csv", Aspose.Cells.SaveFormat.CSV);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    /// <summary>
    /// Lors du clic, ramène au panel de départ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Annuler_Click(object sender, EventArgs e)
    {
        RefreshGrid();
        Panel1.Visible = true;
        Panel2.Visible = false;
        pnl_Rotaract.Visible = false;
        pnl_Bouton.Visible = false;
        hf_Ajout.Value = "";
        hf_Supp.Value = "";
        hf_Cric_Rotaract.Value = "";

    }

    protected void BT_Valider_Click(object sender, EventArgs e)
    {

        PhotoMember pm = DataMapping.GetPhotoMember(DataMapping.GetMember(int.Parse(HF_id.Value)).nim);
        if (pm == null)
        {
            pm = new PhotoMember();
        }

        pm.nim = DataMapping.GetMember(int.Parse(HF_id.Value)).nim;
        pm.photo = HF_Photo.Value;
        if (RB_Autoriser_Publication.SelectedValue == Const.YES)
        {
            pm.visible = Const.YES;
            if (pm.photo == "")
            {
                Member m = DataMapping.GetMemberByNim(pm.nim);
            }

        }
        else
        {
            pm.visible = Const.NO;
        }
        //pm.photo = DataMapping.GetMember(int.Parse(HF_id.Value)).photo;
        //pm.visible = DataMapping.GetMember(int.Parse(HF_id.Value)).visible;



        if (!DataMapping.InsertPhotoMember(pm))
            test.Text = "ID : " + pm.id + " NIM : " + pm.nim + " PHOTO : " + pm.photo + " VISIBLE " + pm.visible;


        if (hf_type_club.Value != null && hf_type_club.Value == Const.Club_Rotaract)
        {
            Member m = Get_Rotaract();
            if(m != null)
            {
                m.base_dtupdate = DateTime.Now;
                if (!DataMapping.UpdateMember(m))
                {
                    return;
                }

                if (Session[HF_Photo2.Value] != null)
                {
                    File.WriteAllBytes(Server.MapPath(PortalSettings.HomeDirectory + Const.MEMBERS_PHOTOS_PREFIX + HF_Photo2.Value), ((Media)Session[HF_Photo2.Value]).content);
                    Session[HF_Photo2.Value] = null;
                }
            }
        }
        else
        {
            //if (!DataMapping.UpdateMember(int.Parse(HF_id.Value), HF_Photo.Value, RB_Autoriser_Publication.SelectedValue == Const.YES))
            //{
            //    return;
            //}
            

            if (Session[HF_Photo.Value] != null)
            {
                File.WriteAllBytes(Server.MapPath(PortalSettings.HomeDirectory + Const.MEMBERS_PHOTOS_PREFIX + HF_Photo.Value), ((Media)Session[HF_Photo.Value]).content);
                Session[HF_Photo.Value] = null;
            }
        }

        RefreshGrid();
        Panel1.Visible = true;
        Panel2.Visible = false;
        pnl_Rotaract.Visible = false;
        pnl_Bouton.Visible = false;
        hf_Cric_Rotaract.Value = "";
    }

    #region ROTARIEN
    protected void RotarienBinding(Member membre)
    {
        try
        {
            LBL_NIM.Text = "" + membre.nim;
            LBL_Nom.Text = membre.name + " " + membre.surname;
            //LBL_Civilite.Text = membre.civility;

            LBL_Fonction_Metier.Text = membre.job;
            LBL_Branche_Activite.Text = membre.industry;

            LBL_Member_Honneur.Text = membre.honorary_member == Const.YES ? "Member d'honneur" : "";
            string compl = membre.honorary_member == "" ? "&nbsp;|&nbsp;" : "";
            if (membre.civility == "M")
                LBL_Retraite.Text = membre.retired == Const.YES ? "&nbsp;| Retraité" + compl : "&nbsp;| En activité" + compl;
            else
                LBL_Retraite.Text = membre.retired == Const.YES ? "&nbsp;| Retraitée" + compl : "&nbsp;| En activité" + compl;
            LBL_DT_Entree_Rotary.Text = membre.year_membership_rotary != null ? "" + ((DateTime)membre.year_membership_rotary).Year : "inconnue";
            LBL_DT_Naissance.Text = membre.birth_year != null ? "" + ((DateTime)membre.birth_year).Year + " (" + ((int)((DateTime.Now - (DateTime)membre.birth_year).TotalDays / 365.25)) + " ans)" : "inconnue";

            IMG_Photo.ImageUrl = membre.GetPhoto();
            HF_Photo.Value = membre.photo;
            BT_Effacer_Photo.Visible = membre.photo != "";

            PhotoMember pm = DataMapping.GetPhotoMember(membre.nim);

            if (pm.visible != null && pm.visible == Const.YES)
            {
                RB_Autoriser_Publication.SelectedValue = Const.YES;
            }
            else if (pm == null)
            {
                RB_Autoriser_Publication.SelectedValue = Const.YES;
            }
            else if(pm.visible == Const.NO) 
            {
                RB_Autoriser_Publication.SelectedValue = Const.NO;
            }
            

            LBL_Adresse.Text = membre.adress_1;
            if (membre.adress_2 != "")
                LBL_Adresse.Text += "<br/>" + membre.adress_2;
            if (membre.adress_3 != "")
                LBL_Adresse.Text += "<br/>" + membre.adress_3;
            LBL_Adresse.Text += "<br/>" + membre.zip_code + " " + membre.town;
            LBL_Email.Text = membre.email;
            LBL_Emailt.Visible = membre.email != "";
            LBL_Tel.Text = membre.telephone;
            LBL_Telt.Visible = membre.telephone != "";
            LBL_Gsm.Text = membre.gsm;
            LBL_GSMt.Visible = membre.gsm != "";
            LBL_Fax.Text = membre.fax;
            LBL_Faxt.Visible = membre.fax != "";

            Panel_Coord_Pro.Visible = (membre.professionnal_adress + membre.professionnal_zip_code + membre.professionnal_town + membre.professionnal_tel + membre.professionnal_fax + membre.professionnal_mobile).Trim() != "";
            LBL_Adresse_Pro.Text = membre.professionnal_adress;
            LBL_Adresse_Pro.Text += "<br/>" + membre.professionnal_zip_code + " " + membre.professionnal_town;
            LBL_Email_Pro.Text = membre.professionnal_email;
            LBL_Email_Prot.Visible = membre.professionnal_email != "";
            LBL_Tel_Pro.Text = membre.professionnal_tel;
            LBL_Tel_Prot.Visible = membre.professionnal_tel != "";
            LBL_FAX_Pro.Text = membre.professionnal_fax;
            LBL_Fax_Prot.Visible = membre.professionnal_fax != "";
            LBL_GSM_Pro.Text = membre.professionnal_mobile;
            LBL_GSM_Prot.Visible = membre.professionnal_mobile != "";
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }
    protected void BT_Upload_Photo_Click(object sender, EventArgs e)
    {
        if (FU_Photo.UploadedFiles.Count > 0)
        {
            UploadedFile file = FU_Photo.UploadedFiles[0];
            string filename = Functions.ClearFileName(LBL_Nom.Text+".jpg");

            Bitmap bmp = new Bitmap(file.InputStream);
            bmp = Functions.ThumbByWidth(bmp, Const.MEMBERS_PHOTOS_WIDTH);
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            HF_Photo.Value = filename;
            
            Media media = new Media();
            media.content = ms.GetBuffer();
            media.content_size = media.content.Length;
            media.dt = DateTime.Now;
            media.w = bmp.Width;
            media.h = bmp.Height;
            media.name = filename;
            media.content_type = "image/jpeg";
            Session[HF_Photo.Value] = media;
            
            IMG_Photo.ImageUrl = Const.MEDIA_VIEW_URL+"?id="+filename;
            BT_Effacer_Photo.Visible = true;
        }
    }
    protected void BT_Effacer_Photo_Click(object sender, EventArgs e)
    {
        BT_Effacer_Photo.Visible = false;
        Session[HF_Photo.Value] = null;
        HF_Photo.Value = "";
        if (LBL_Civilite.Text == "M")
            IMG_Photo.ImageUrl = Const.MEMBERS_NOPHOTO_H;
        else
            IMG_Photo.ImageUrl = Const.MEMBERS_NOPHOTO_F;
    }
    #endregion ROTARIEN

    #region ROTARACT
    protected void BT_Effacer_Photo2_Click(object sender, EventArgs e)
    {
        BT_Effacer_Photo2.Visible = false;
        Session[HF_Photo2.Value] = null;
        HF_Photo2.Value = "";
        if (LBL_Civilite.Text == "M")
            IMG_Photo2.ImageUrl = Const.MEMBERS_NOPHOTO_H;
        else
            IMG_Photo2.ImageUrl = Const.MEMBERS_NOPHOTO_F;
    }

    protected void BT_Upload_Photo2_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(tbx_nom.Text))
        {
            if (FU_Photo2.UploadedFiles.Count > 0)
            {
                UploadedFile file = FU_Photo2.UploadedFiles[0];
                string filename = Functions.ClearFileName(tbx_nom.Text + ".jpg");

                Bitmap bmp = new Bitmap(file.InputStream);
                bmp = Functions.ThumbByWidth(bmp, Const.MEMBERS_PHOTOS_WIDTH);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                HF_Photo2.Value = filename;

                Media media = new Media();
                media.content = ms.GetBuffer();
                media.content_size = media.content.Length;
                media.dt = DateTime.Now;
                media.w = bmp.Width;
                media.h = bmp.Height;
                media.name = filename;
                media.content_type = "image/jpeg";
                Session[HF_Photo2.Value] = media;

                IMG_Photo2.ImageUrl = Const.MEDIA_VIEW_URL + "?id=" + filename;
                BT_Effacer_Photo2.Visible = true;
            }
        }
        else
        {
            BT_Effacer_Photo2.Visible = false;
            Response.Write("<script LANGUAGE='JavaScript' >alert('Vous devez saisir le nom du membre avant!');</script>");            
        }
    }

    protected void RotaractBinding(Member membre)
    {
        try
        {
            hf_Cric_Rotaract.Value = "" + membre.cric;
            IMG_Photo2.ImageUrl = membre.GetPhoto();
            HF_Photo2.Value = membre.photo;
            BT_Effacer_Photo2.Visible = membre.photo != "";

            if (membre.civility == "M")
            {
                rbtl_civilite.SelectedValue = "M";
            }
            else
            {
                rbtl_civilite.SelectedValue = "Mme";
            }

            tbx_titre.Text = "" + membre.title;
            tbx_nom.Text = "" + membre.surname;
            tbx_prenom.Text = "" + membre.name;
            if (membre.birth_year != null)
            {
                dpk_ann_Naiss.SelectedDate = membre.birth_year;
            }
            tbx_nom_JF.Text = "" + membre.maiden_name;
            tbx_prenom_Conjoint.Text = "" + membre.maiden_name;
            tbx_bio.Text = "" + membre.biography;

            tbx_adresse1.Text = "" + membre.adress_1;
            tbx_adresse2.Text = "" + membre.adress_2;
            tbx_adresse3.Text = "" + membre.adress_3;
            tbx_cp.Text = "" + membre.zip_code;
            tbx_ville.Text = "" + membre.town;
            tbx_pays.Text = "" + membre.country;
            tbx_email.Text = "" + membre.email;
            tbx_telephone.Text = "" + membre.telephone;
            tbx_fax.Text = "" + membre.fax;
            tbx_gsm.Text = "" + membre.gsm;

            tbx_fct_metier.Text = "" + membre.job;
            tbx_branche.Text = "" + membre.industry;
            if (membre.retired == Const.YES)
            {
                rbtl_retraite.SelectedValue = "O";
            }
            else
            {
                rbtl_retraite.SelectedValue = "N";
            }

            tbx_adresse_pro.Text    = "" + membre.professionnal_adress;
            tbx_cp_pro.Text         = "" + membre.professionnal_zip_code;
            tbx_ville_pro.Text      = "" + membre.professionnal_town;
            tbx_email_pro.Text      = "" + membre.professionnal_email;
            tbx_tel_pro.Text        = "" +  membre.professionnal_tel;
            tbx_fax_pro.Text        = "" +  membre.professionnal_fax;
            tbx_gsm_pro.Text        = "" +  membre.professionnal_mobile;

            lbl_district3.Text = "" + membre.district_id;
            lbl_club3.Text = "" + membre.club_name;
            if (membre.honorary_member == Const.YES)
            {
                rbtl_membre_H.SelectedValue = "O";
            }
            else
            {
                rbtl_membre_H.SelectedValue = "N";
            }

            if (membre.active_member == Const.YES)
            {
                rbtl_membre_A.SelectedValue = "O";
            }
            else
            {
                rbtl_membre_A.SelectedValue = "N";
            }

            if (membre.year_membership_rotary != null)
            {
                dpk_ann__adh_Rot.SelectedDate = membre.year_membership_rotary;
            }

            if (membre.removed == Const.YES)
            {
                rbtl_radie.SelectedValue = "O";
            }
            else
            {
                rbtl_radie.SelectedValue = "N";
            }
                      

            if (RB_Autoriser_Publication.SelectedValue == Const.YES)
            {
                membre.visible = Const.YES;
            }
            else
            {
                membre.visible = Const.NO;
            }

        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected Member Get_Rotaract()
    {
        try
        {
            Member membre = new Member();

            if (!string.IsNullOrEmpty(HF_id.Value))
            {
                membre.id = int.Parse(HF_id.Value);
            }

            if (!string.IsNullOrEmpty(LBL_NIM.Text))
            {
                membre.nim = int.Parse(LBL_NIM.Text);
            }

            if (!string.IsNullOrEmpty(HF_Cric.Value) && HF_Cric.Value != "0")
            {
                membre.cric = int.Parse(HF_Cric.Value);
            }
            else if(!string.IsNullOrEmpty(hf_Cric_Rotaract.Value))
            {
                membre.cric = int.Parse(hf_Cric_Rotaract.Value);
            }

            membre.photo = "" + HF_Photo2.Value;
            
            membre.civility = rbtl_civilite.SelectedValue;

            membre.title = "" + tbx_titre.Text;
            membre.surname = "" + tbx_nom.Text;
            membre.name = "" + tbx_prenom.Text;
            if(dpk_ann_Naiss.SelectedDate != null && dpk_ann_Naiss.SelectedDate > DateTime.MinValue)
            {
                membre.birth_year = dpk_ann_Naiss.SelectedDate;
            }
            membre.maiden_name = "" + tbx_nom_JF.Text;
            membre.spouse_name = "" + tbx_prenom_Conjoint.Text;
            membre.biography = "" + tbx_bio.Text;
            membre.adress_1 = "" + tbx_adresse1.Text;
            membre.adress_2 = "" + tbx_adresse2.Text;
            membre.adress_3 = "" + tbx_adresse3.Text;
            membre.zip_code = "" + tbx_cp.Text;
            membre.town = "" + tbx_ville.Text;
            membre.country = "" + tbx_pays.Text;
            membre.email = "" + tbx_email.Text;
            membre.telephone = "" + tbx_telephone.Text;
            membre.fax = "" +   tbx_fax.Text;
            membre.gsm = "" + tbx_gsm.Text;
            membre.job = "" + tbx_fct_metier.Text;
            membre.industry = "" + tbx_branche.Text;
            membre.retired = rbtl_retraite.SelectedValue;
            membre.professionnal_adress     = "" + tbx_adresse_pro.Text;
            membre.professionnal_zip_code   = "" + tbx_cp_pro.Text     ;
            membre.professionnal_town         = "" + tbx_ville_pro.Text  ;
            membre.professionnal_email         = "" + tbx_email_pro.Text  ;
            membre.professionnal_tel           = "" + tbx_tel_pro.Text    ;
            membre.professionnal_fax           = "" + tbx_fax_pro.Text    ;
            membre.professionnal_mobile      = "" + tbx_gsm_pro.Text    ;
            membre.district_id = int.Parse(lbl_district3.Text);
            membre.club_name = "" + lbl_club3.Text;
            membre.honorary_member = rbtl_membre_H.SelectedValue;
            membre.active_member = "" + rbtl_membre_A.SelectedValue;
            if (dpk_ann__adh_Rot.SelectedDate != null && dpk_ann__adh_Rot.SelectedDate > DateTime.MinValue)
            {
                membre.year_membership_rotary = dpk_ann__adh_Rot.SelectedDate;
            }
            membre.visible = RB_Autoriser_Publication.SelectedValue;
            membre.removed = rbtl_radie.SelectedValue;

            membre.base_dtupdate = DateTime.Now;

            return membre;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            return null;
        }
    }

    protected void BT_Supprimer_Click(object sender, EventArgs e)
    {
        try
        {
            if (!DataMapping.DeleteMember(int.Parse(HF_id.Value)))
            {
                return;
            }

            RefreshGrid();
            Panel1.Visible = true;
            Panel2.Visible = false;
            pnl_Rotaract.Visible = false;
            pnl_Bouton.Visible = false;
            CleartextBoxes(pnl_Rotaract);
            hf_Ajout.Value = "";
            hf_Supp.Value = "";
            hf_Cric_Rotaract.Value = "";
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected void btn_Ajout_Click(object sender, EventArgs e)
    {
        try
        {
            if (UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || DataMapping.isADG() || UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT))
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                pnl_Rotaract.Visible = true;
                pnl_Bouton.Visible = true;

                CleartextBoxes(pnl_Rotaract);
                

                BT_VCF.Visible = false;                
                BT_CreateDNNUser.Visible = false;
                BT_Supprimer.Visible = false;
                BT_Valider.Visible = false;
                BT_Ajouter.Visible = true;
                hf_Ajout.Value = "o";
            }
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected void BT_Ajouter_Click(object sender, EventArgs e)
    {
        try
        {
            Member m = Get_Rotaract();
            if(m != null)
            {
                if (!DataMapping.InsertMember(m))
                {
                    return;
                }

                if (Session[HF_Photo2.Value] != null)
                {
                    File.WriteAllBytes(Server.MapPath(PortalSettings.HomeDirectory + Const.MEMBERS_PHOTOS_PREFIX + HF_Photo2.Value), ((Media)Session[HF_Photo2.Value]).content);
                    Session[HF_Photo2.Value] = null;
                }

                CleartextBoxes(pnl_Rotaract);
                hf_Ajout.Value = "";
                hf_Supp.Value = "";
                hf_Cric_Rotaract.Value = "";
            }

            RefreshGrid();
            Panel1.Visible = true;
            Panel2.Visible = false;
            pnl_Rotaract.Visible = false;
            pnl_Bouton.Visible = false;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    public void CleartextBoxes(Control parent)
    {
        BT_Effacer_Photo2.Visible = false;
        IMG_Photo2.ImageUrl = Const.MEMBERS_NOPHOTO_F;
        rbtl_civilite.SelectedValue = "M";
        rbtl_retraite.SelectedValue = "N";
        rbtl_membre_H.SelectedValue = "N";
        rbtl_membre_A.SelectedValue = "O";
        rbtl_radie.SelectedValue = "N";
        RB_Autoriser_Publication.SelectedValue = "O";
        rbtl_radie.Enabled = true;
        lbl_district3.Text = "" + Const.DISTRICT_ID;
        lbl_club3.Text = Functions.CurrentClub.name;        
        dpk_ann_Naiss.SelectedDate = null;
        HF_Photo2.Value = "";
        dpk_ann__adh_Rot.SelectedDate = null;

        foreach (Control c in parent.Controls)
        {
            if ((c.GetType() == typeof(TextBox)))
            {

                ((TextBox)(c)).Text = "";
            }
            
            //else if ((c.GetType() == typeof(RadioButton)))
            //{

            //    ((RadioButton)(c)).Checked = false;
            //}

            if (c.HasControls())
            {
                CleartextBoxes(c);
            }
        }
    } 
    #endregion ROTARACT

    /// <summary>
    /// Lors du changement du critère, rafrachit le GridView et passe l'index à 0
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TXT_Critere_TextChanged(object sender, EventArgs e)
    {
        GridView1.PageIndex = 0;
        RefreshGrid();
    }

    /// <summary>
    /// Permet de télécharger le recto de la carte des membres d'un club sous forme d'un PDF
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Carte_Member_Recto_Click(object sender, EventArgs e)
    {
        List<Member> membres = DataMapping.ListMembers(cric: Functions.CurrentCric, sort: "name asc", max: int.MaxValue, criterion: TXT_Critere.Text);
        List<Affectation> affectations = DataMapping.ListAffectationRY(Functions.CurrentCric, Functions.GetRotaryYear());
        Media media = DataMapping.ProductionDocument(Const.MEMBERS_CARTES_RECTO_MODELE, membres, affectations, "Cartes des membres " + GetNomClub() + ".recto.pdf");
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    /// <summary>
    /// Permet de télécharger le verso de la carte des membres d'un club sous forme d'un PDF
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Carte_Member_Verso_Click(object sender, EventArgs e)
    {
        List<Member> membres = DataMapping.ListMembers(cric: Functions.CurrentCric, sort: "name asc", max: int.MaxValue, criterion: TXT_Critere.Text);
        List<Affectation> affectations = DataMapping.ListAffectationRY(Functions.CurrentCric, Functions.GetRotaryYear());
        Media media = DataMapping.ProductionDocument(Const.MEMBERS_CARTES_VERSO_MODELE, membres, affectations, "Cartes des membres " + GetNomClub() + ".verso.pdf");
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    /// <summary>
    /// Permet de télécharger le recto de la carte des membres d'un club sous forme d'un fichier Word
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Carte_Member_Recto_DOC_Click(object sender, EventArgs e)
    {
        List<Member> membres = DataMapping.ListMembers(cric: Functions.CurrentCric, sort: "name asc", max: int.MaxValue, criterion: TXT_Critere.Text);
        List<Affectation> affectations = DataMapping.ListAffectationRY(Functions.CurrentCric, Functions.GetRotaryYear());
        Media media = DataMapping.ProductionDocument(Const.MEMBERS_CARTES_RECTO_MODELE, membres, affectations, "Cartes des membres " + GetNomClub() + ".recto.doc", typemime: "application/msword");
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    /// <summary>
    /// Permet de télécharger le verso de la carte des membres d'un club sous forme d'un fichier Word
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Carte_Member_Verso_DOC_Click(object sender, EventArgs e)
    {
        List<Member> membres = DataMapping.ListMembers(cric: Functions.CurrentCric, sort: "name asc", max: int.MaxValue, criterion: TXT_Critere.Text);
        List<Affectation> affectations = DataMapping.ListAffectationRY(Functions.CurrentCric, Functions.GetRotaryYear());
        Media media = DataMapping.ProductionDocument(Const.MEMBERS_CARTES_VERSO_MODELE, membres, affectations, "Cartes des membres " + GetNomClub() + ".verso.doc", typemime: "application/msword");
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    /// <summary>
    /// Permet de télécharger le recto de la carte des membres d'un club sous forme d'un fichier Word (.docx)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Carte_Member_Recto_DOCX_Click(object sender, EventArgs e)
    {
        List<Member> membres = DataMapping.ListMembers(cric: Functions.CurrentCric, sort: "name asc", max: int.MaxValue, criterion: TXT_Critere.Text);
        List<Affectation> affectations = DataMapping.ListAffectationRY(Functions.CurrentCric, Functions.GetRotaryYear());
        Media media = DataMapping.ProductionDocument(Const.MEMBERS_CARTES_RECTO_MODELE, membres, affectations, "Cartes des membres " + GetNomClub() + ".recto.docx", typemime: "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    /// <summary>
    /// Permet de télécharger le verso de la carte des membres d'un club sous forme d'un fichier Word (.docx)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Carte_Member_Verso_DOCX_Click(object sender, EventArgs e)
    {
        List<Member> membres = DataMapping.ListMembers(cric: Functions.CurrentCric, sort: "name asc", max: int.MaxValue, criterion: TXT_Critere.Text);
        List<Affectation> affectations = DataMapping.ListAffectationRY(Functions.CurrentCric, Functions.GetRotaryYear());
        Media media = DataMapping.ProductionDocument(Const.MEMBERS_CARTES_VERSO_MODELE, membres, affectations, "Cartes des membres " + GetNomClub() + ".verso.docx", typemime: "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    /// <summary>
    /// Permet de créer un User DNN et cache le bouton en fonction de la réussite de l'opération
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_CreateDNNUser_Click(object sender, EventArgs e)
    {
        BT_CreateDNNUser.Visible = !DataMapping.UpdateOrCreateUser(int.Parse(HF_id.Value),LBL_Email.Text);
    }

    /// <summary>
    /// Change le format du texte (enlève les accents et remplaces les sauts de lignes par des ';')
    /// </summary>
    /// <param name="ch"></param>
    /// <returns></returns>
    public string FormatText(string ch)
    {
        return ch.Replace("<br/>", ";").Replace(Environment.NewLine, ";").Replace("é", "e").Replace("è", "e").Replace("à", "a").Replace("ù", "u");;
    }


    protected void BT_VCF_Click(object sender, EventArgs e)
    {
        int nim = 0;
        int.TryParse(LBL_NIM.Text,out nim);
        Member membre = DataMapping.GetMemberByNim(nim);
        if (membre == null)
            return;
        string vcard = "BEGIN:VCARD" + Environment.NewLine + 
            "VERSION:3.0" + Environment.NewLine + 
            "KIND:individual" + Environment.NewLine + "FN:" + LBL_Nom.Text + Environment.NewLine +
            "PHOTO;VALUE=URL:http://www.rotary1730.org" + IMG_Photo.ImageUrl + Environment.NewLine +
            "ADR;TYPE=PREF,HOME:;;" + FormatText(LBL_Adresse.Text) + Environment.NewLine +
            "LABEL;TYPE=HOME:" + FormatText(LBL_Adresse_Pro.Text) + Environment.NewLine +
            "ADR;TYPE=WORK:;;" + FormatText(LBL_Adresse_Pro.Text) + Environment.NewLine +
            "LABEL;TYPE=WORK:" + FormatText(LBL_Adresse_Pro.Text) + Environment.NewLine +
            "TEL;TYPE=HOME,VOICE:" + LBL_Tel.Text + Environment.NewLine +
            "TEL;TYPE=HOME,VOICE:" + LBL_Gsm.Text + Environment.NewLine +
            "TEL;TYPE=WORK,VOICE:" + LBL_Tel_Pro.Text + Environment.NewLine +
            "TEL;TYPE=WORK,VOICE:" + LBL_GSM_Pro.Text + Environment.NewLine +
            "EMAIL;TYPE=PREF,INTERNET:" + LBL_Email.Text + Environment.NewLine +
            "ORG:RC " + membre.club_name + Environment.NewLine + 
            "END:VCARD";
        
        Media media = new Media();
        media.name = LBL_Nom.Text + ".vcf";
        media.content_type = "text/x-vcard";
        //media.name = LBL_Nom.Text + ".txt";
        //media.content_type = "text/plain";
        media.dt = DateTime.Now;
        media.content = Functions.StringToBytes(vcard);
        media.content_size = media.content.Length;

        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }
}