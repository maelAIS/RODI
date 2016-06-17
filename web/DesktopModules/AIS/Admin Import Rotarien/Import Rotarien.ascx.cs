
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

public partial class DesktopModules_AIS_Admin_Import_Rotarien_Import_Rotarien : PortalModuleBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RefreshGrid();
    }


    public void RefreshGrid()
    {
        List<Member> membres = DataMapping.GetListRotaryImport("");
        string dateMaj = "" + membres[0].base_dtupdate;
        string [] splits = dateMaj.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        lbl_derniereMaj.Text = splits[0];

        membres = DataMapping.GetListRotaryImport("", gvw_importRotarien.PageIndex, gvw_importRotarien.PageSize);

        if (tbx_filtre.Text != "")
        {
            membres = DataMapping.GetListRotaryImport("nim like '" + tbx_filtre.Text + "' OR surname like '%" + tbx_filtre.Text + "%' OR name like '%" + tbx_filtre.Text + "%'");
        }

        gvw_importRotarien.DataSource = membres;
        gvw_importRotarien.DataBind();
    }




    protected void lbt_details_Click(object sender, EventArgs e)
    {
        pnl_grid.Visible = false;
        pnl_membre.Visible = true;

        
        
    }

    protected void gvw_importRotarien_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType==DataControlRowType.DataRow)
        {
            Member membre = (Member)e.Row.DataItem;


            Label lblNim = (Label)e.Row.FindControl("lbl_nim");
            Label lblNom = (Label)e.Row.FindControl("lbl_nom");
            Label lblPrenom = (Label)e.Row.FindControl("lbl_prenom");
            Label lblRadie = (Label)e.Row.FindControl("lbl_radie");
            Label lblCivilite = (Label)e.Row.FindControl("lbl_civilite");
            Label lblDateMaj = (Label)e.Row.FindControl("lbl_dtMaj");

            string dateMaj =""+ membre.base_dtupdate;
            string [] splits = dateMaj.Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries); 

            lblNim.Text = "" + membre.nim;
            lblNom.Text = membre.surname;
            lblPrenom.Text = membre.name;
            if (membre.removed == "O")
                lblRadie.Text = "Radié(e)";
            else
                lblRadie.Text = "Non radié(e)";
            lblCivilite.Text = membre.civility;
            lblDateMaj.Text = splits[0];
        }
        

    }
   

    protected void btn_filtre_Click(object sender, EventArgs e)
    {
        RefreshGrid();
    }
    
    
    protected void gvw_importRotarien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (gvw_importRotarien.PageIndex == e.NewPageIndex)
        {
            e.Cancel = true;
            return;
        }
        gvw_importRotarien.PageIndex = e.NewPageIndex;
        RefreshGrid();   
    }


    protected void gvw_importRotarien_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            hfd_nim.Value = e.CommandArgument.ToString();

            Member membre = DataMapping.GetListRotaryImport("nim =" + hfd_nim.Value)[0];

            if (membre.removed != "O")
                img_membre.ImageUrl = DataMapping.GetMemberByNim(membre.nim).GetPhoto();
            else
                img_membre.ImageUrl = Const.MEMBERS_NOPHOTO_H;


            lbl_membreHonneur.Text = (membre.honorary_member == "O" ? "(Member d'honneur" : "");
            lbl_adresse1.Text = (membre.adress_1 == "" ? "N.C." : membre.adress_1);
            lbl_adresse2.Text = (membre.adress_2 == "" ? "" : membre.adress_2);
            lbl_adresse3.Text = (membre.adress_3 == "" ? "" : membre.adress_3);
            lbl_adresseProfessionnelle.Text = (membre.professionnal_adress == "" ? "N.C." : membre.professionnal_adress);
            if (membre.year_membership_rotary.ToString() != "")
            {
               
                lbl_anneeAdhesionRotary.Text = ""+membre.year_membership_rotary.Value.Year;
            }
            else
                lbl_anneeAdhesionRotary.Text = "N.C.";
            if (membre.birth_year.ToString() != "")
            {

                lbl_anneeNaissance.Text = "" + membre.birth_year.Value.Year;
            }
            else
                lbl_anneeNaissance.Text = "N.C.";

            lbl_biographie.Text = (membre.biography == "" ? "N.C." : membre.biography);
            lbl_brancheMetier.Text = (membre.industry == "" ? "" : "(" + membre.industry + ")");
            lbl_civilite.Text = membre.civility;
            lbl_codePostal.Text = (membre.zip_code == "" ? "" : "(" + membre.zip_code + ")");
            lbl_codePostalProfessionnel.Text = (membre.professionnal_zip_code.ToString() == "" ? "" : "(" + membre.professionnal_zip_code + ")");
            lbl_cric.Text = "(" + membre.cric + ")";
            lbl_dateMaj_Base.Text = "" + membre.base_dtupdate;
            lbl_email.Text = (membre.email == "" ? "N.C." : membre.email);
            lbl_emailProfessionnel.Text = (membre.professionnal_email == "" ? "N.C." : membre.professionnal_email);
            lbl_fax.Text = (membre.fax == "" ? "N.C." : membre.fax);
            lbl_faxProfessionnel.Text = (membre.professionnal_fax == "" ? "N.C." : membre.professionnal_fax);
            lbl_fonctionMetier.Text = (membre.job == "" ? "N.C." : membre.job);
            lbl_gsm.Text = (membre.gsm == "" ? "N.C." : membre.gsm);
            lbl_membreActif.Text = (membre.active_member == "O" ? "Member Actif" : "Member non Actif");
            lbl_nom.Text = membre.surname;
            lbl_nim.Text = membre.nim.ToString();
            lbl_nomClub.Text = membre.club_name;
            lbl_nomJeuneFille.Text = (membre.maiden_name == "" ? "N.C." : membre.maiden_name);
            lbl_pays.Text = (membre.country == "" ? "N.C." : membre.country);
            lbl_portableProfessionnel.Text = (membre.professionnal_mobile == "" ? "N.C." : membre.professionnal_mobile);
            lbl_prenom.Text = membre.name;
            lbl_prenomConjoint.Text = (membre.spouse_name == "" ? "N.C." : membre.spouse_name);
            lbl_radie.Text = (membre.removed == "O" ? "Radié" : "");
            lbl_retraite.Text = (membre.retired == "O" ? "Member retraité" : "");
            lbl_telephone.Text = (membre.telephone == "" ? "N.C." : membre.telephone);
            lbl_telProfessionnel.Text = (membre.professionnal_tel == "" ? "N.C." : membre.professionnal_tel);
            lbl_titre.Text = (membre.title == "" ? "Pas de titre" : membre.title);
            lbl_ville.Text = (membre.town == "" ? "N.C." : membre.town);
            lbl_villeProfessionnelle.Text = (membre.professionnal_town == "" ? "N.C." : membre.professionnal_town);
            lbl_district_id.Text = "" + membre.district_id;

            if (!membre.IsWoman())
            {
                lbl_nomJeuneFille.Visible = false;
                nomjeunefille.Visible = false;
            }
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected void btn_retour_Click(object sender, EventArgs e)
    {
        pnl_grid.Visible = true;
        pnl_membre.Visible = false;
        RefreshGrid();
    }
   
}