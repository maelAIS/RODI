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
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using AIS;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Services.Mail;
using Newtonsoft.Json;

/// <summary>
/// Description résumée de Mobile
/// </summary>
/// 

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
// [System.Web.Script.Services.ScriptService]
public class Mobile : System.Web.Services.WebService {

    public Mobile () {

        //Supprimez les marques de commentaire dans la ligne suivante si vous utilisez des composants conçus 
        //InitializeComponent(); 
    }

    private string GetBaseUrl()
    {
        Uri uri = new Uri(DotNetNuke.Common.Globals.NavigateURL());
        return uri.ToString().Replace(uri.PathAndQuery, "") + "/";
    }

    private string urlNews = "LesNouvelles/Clubs.aspx";
    private string os = "Android";

    private string getIP()
    {
        return HttpContext.Current.Request.UserHostAddress;
    }

    private float getDuree(DateTime start)
    {
        TimeSpan ticks = DateTime.Now - start;
        return (float)ticks.TotalMilliseconds;
    }

    [WebMethod]
    public string HelloWorld(string username, string password, string device, string version, string fonction)
    {
        return "Hello World " + GetBaseUrl();
    }

    [WebMethod]
    public string ConnectFromAndroid(string username, string password, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        string token = "0";
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return token;
        }
        SqlConnection conn = new SqlConnection(DotNetNuke.Common.Utilities.Config.GetConnectionString());

        try
        {
            UserInfo user = UserController.GetUserByName(Globals.GetPortalSettings().PortalId, username);
            if (user != null)
            {
                MembershipUser objUser = Membership.GetUser(user.Username);
                if (objUser != null)
                {
                    string strPassword = objUser.GetPassword();
                    if (!string.IsNullOrEmpty(strPassword))
                    {
                        string defaultPassMD5 = Functions.CalculateMD5Hash(Functions.StringToBytes(strPassword));

                        if (!string.IsNullOrEmpty(defaultPassMD5))
                        {
                            if (password.ToLower() == defaultPassMD5.ToLower())
                            {
                                token = "1";
                                //break;
                            }
                        }
                        else
                        {
                            throw new Exception("defaultPassMD5 NULL ou  vide pour le username " + username);
                        }
                    }
                    else
                    {
                        throw new Exception("strPassword NULL ou  vide pour le username " + username);
                    }
                }
                else
                {
                    throw new Exception("objUser NULL pour le username " + username);
                }
            }
            else
            {
                throw new Exception("user NULL pour le username " + username);
            }
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            comment = ee.ToString();
            code = "erreur";
        }
        finally
        {
            conn.Close();
            conn.Dispose();


            if (token == "1")
            {
                comment = "Identification réussie";
            }
            else
            {
                if (comment == "")
                {
                    comment = "Identification refusée";
                }
            }

            DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, username);
        }

        return token;
    }

    [WebMethod]
    public Membre memberToMembre(Member m)
    {
        Membre membre = new Membre();

        membre.id = m.id;
        membre.nim = m.nim;
        membre.membre_honneur = m.honorary_member;
        membre.nom = m.surname;
        membre.prenom = m.name;
        membre.cric = m.cric;
        membre.membre_actif = m.active_member;
        membre.civilite = m.civility;
        membre.nom_jeune_fille = m.maiden_name;
        membre.prenom_conjoint = m.spouse_name;
        membre.titre = m.title;
        membre.annee_naissance = m.birth_year;
        membre.annee_adhesion_rotary = m.year_membership_rotary;
        membre.email = m.email;
        membre.adresse_1 = m.adress_1;
        membre.adresse_2 = m.adress_2;
        membre.adresse_3 = m.adress_3;
        membre.code_postal = m.zip_code;
        membre.ville = m.town;
        membre.telephone = m.telephone;
        membre.fax = m.fax;
        membre.gsm = m.gsm;
        membre.pays = m.country;
        membre.fonction_metier = m.job;
        membre.branche_activite = m.industry;
        membre.biographie = m.biography;
        membre.date_majbase = m.base_dtupdate;
        membre.adresse_professionnelle = m.professionnal_adress;
        membre.code_postal_professionnel = m.professionnal_zip_code;
        membre.ville_professionnel = m.professionnal_town;
        membre.tel_professionnel = m.professionnal_tel;
        membre.fax_professionnel = m.professionnal_fax;
        membre.portable_professionnel = m.professionnal_mobile;
        membre.email_professionnel = m.professionnal_email;
        membre.retraite = m.retired;
        membre.radie = m.removed;
        membre.district_id = m.district_id;
        membre.nom_club = m.club_name;
        membre.userid = m.userid;
        membre.photo = m.photo;
        membre.visible = m.visible;
        membre.presentation = m.presentation;
        membre.fonction_rotarienne = m.fonction_rotarienne;

        return membre;
    }

    [WebMethod]
    public Nouvelle newsToNouvelle(News news)
    {
        Nouvelle nouvelle = new Nouvelle();
        nouvelle.id = news.id;
        nouvelle.cric = news.cric;
        nouvelle.dt = news.dt;
        nouvelle.titre = news.title;
        nouvelle.texte = news.text;
        nouvelle.url_texte = news.url_text;
        nouvelle.photo = news.photo;
        nouvelle.categorie = news.category;
        nouvelle.tag1 = news.tag1;
        nouvelle.tag2 = news.tag2;
        nouvelle.nom_club = news.club_name;
        nouvelle.visible = news.visible;
        nouvelle.PhotoString64 = news.PhotoString64;
        nouvelle.urlNouvelle = news.urlNews;
        nouvelle.type_club = news.club_type;

        return nouvelle;
    }

    [WebMethod]
    public string GetListMembers(int cric, string critere, string top, string tri, int index, int max, bool onlyvisible, string username, string password, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        List<Member> lm = new List<Member>();
        List<Membre> ln = new List<Membre>();
        try
        {
            string token = ConnectFromAndroid(username, password, device, version, fonction);

            bool court = true;
            if (token == "1")
            {
                court = false;
            }

            lm = DataMapping.ListMembers(cric, critere, top, tri, index, max, onlyvisible, court);

            DateTime now = DateTime.Now;
            int year = 0;
            int.TryParse(now.ToString("yyyy"), out year);

            foreach (Member m in lm)
            {
                m.photo = HttpContext.Current.Server.MapPath(m.GetPhoto());

                if (year > 0)
                {
                    Affectation aff = DataMapping.GetAffectation(m.nim, year);
                    if (aff != null && !string.IsNullOrEmpty(aff.function))
                    {
                        m.fonction_rotarienne = aff.function;
                    }
                }
                ln.Add(memberToMembre(m));
            }
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();

            Functions.Error(ee);
        }

        string output = JsonConvert.SerializeObject(ln, Formatting.Indented);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, username);
        return output;
    }

    [WebMethod]
    public string GetListMembersV2(int cric, string critere, string top, string tri, int index, int max, bool onlyvisible, string username, string password, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        List<Member> lm = new List<Member>();
        List<Membre> ln = new List<Membre>();
        try
        {
            string token = ConnectFromAndroid(username, password, device, version, fonction);

            bool court = true;
            if (token == "1")
            {
                court = false;
            }

            lm = DataMapping.ListMembers(cric, critere, top, tri, index, max, onlyvisible, court);

            DateTime now = DateTime.Now;
            int year = 0;
            int.TryParse(now.ToString("yyyy"), out year);

            foreach (Member m in lm)
            {
                m.photo = HttpContext.Current.Server.MapPath(m.GetPhoto());

                Content c = DataMapping.GetContentPagePro(m.userid);
                if (c != null)
                {
                    m.presentation = true;
                }
                else
                {
                    m.presentation = false;
                }

                if (year > 0)
                {
                    Affectation aff = DataMapping.GetAffectation(m.nim, year);
                    if (aff != null && !string.IsNullOrEmpty(aff.function))
                    {
                        m.fonction_rotarienne = aff.function;
                    }
                }

                ln.Add(memberToMembre(m));
            }
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();

            Functions.Error(ee);
        }

        string output = JsonConvert.SerializeObject(ln, Formatting.Indented);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, username);
        return output;
    }


    [WebMethod]
    public string ListMembersPresentation(int cric, string critere, string top, string tri, int index, int max, bool onlyvisible, string username, string password, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        List<Member> lm = new List<Member>();
        List<Membre> ln = new List<Membre>();
        try
        {
            string token = ConnectFromAndroid(username, password, device, version, fonction);

            bool court = true;
            if (token == "1")
            {
                court = false;
            }

            lm = DataMapping.ListMembersPresentation(cric, critere, top, tri, index, max, onlyvisible, court);
            foreach (Member m in lm)
            {
                m.photo = HttpContext.Current.Server.MapPath(m.GetPhoto());
                m.presentation = true;
                ln.Add(memberToMembre(m));
            }
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();
            Functions.Error(ee);
        }

        string output = JsonConvert.SerializeObject(ln, Formatting.Indented);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, username);

        return output;
    }

    [WebMethod]
    public string GetPhotoMember(string filepath, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        MemoryStream ms = new MemoryStream();
        try
        {
            FileInfo f = new FileInfo(filepath);
            if (f.Exists)
            {
                Image img = Image.FromFile(filepath);
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();
            Functions.Error(ee);
        }
        string jsonString = Convert.ToBase64String(ms.ToArray());
        string output = JsonConvert.SerializeObject(jsonString);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, "");

        return output;
    }

    [WebMethod]
    public string ListClub(string dept, string top, string tri, int index, int max, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        List<Club> lm = new List<Club>();

        try
        {
            lm = DataMapping.ListClubs(dept, top, tri, index, max);
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();
            Functions.Error(ee);
        }

        string output = JsonConvert.SerializeObject(lm, Formatting.Indented);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, "");

        return output;
    }

    [WebMethod]
    public string GetClub(int cric, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        Club lm = new Club();

        try
        {
            lm = DataMapping.GetClub(cric);

        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();
            Functions.Error(ee);
        }

        string output = JsonConvert.SerializeObject(lm, Formatting.Indented);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, "");

        return output;
    }

    [WebMethod]
    public string ListNews(int cric, string categorie, string tags_inclus, string tags_excluded, string top, string tri, int index, int max, bool onlyvisible, string date, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        List<News> lm = new List<News>();
        List<Nouvelle> ln = new List<Nouvelle>();
        try
        {
            lm = AIS.DataMapping.ListNewsMobile(cric, categorie, tags_inclus, tags_excluded, top, tri, index, max, onlyvisible, date);
            foreach (News m in lm)
            {
                m.photo = HttpContext.Current.Server.MapPath(m.GetPhoto());
                //m.url = HttpContext.Current.Server.MapPath(m.GetUrl());
                m.PhotoString64 = GetPhotoNew(m.photo, device, version, fonction);

                string url = "" + m.GetUrl();
                if (!string.IsNullOrEmpty(url))
                {
                    m.url = GetBaseUrl() + HttpContext.Current.Server.UrlPathEncode(m.GetUrl());
                    //m.url = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority  + HttpContext.Current.Server.UrlPathEncode(m.GetUrl());
                }

                m.urlNews = GetBaseUrl() + urlNews + "?newsid=" + m.id + "&cric=" + m.cric;
                
            }

            foreach (News m in lm)
            {
                ln.Add(newsToNouvelle(m));
            }
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();
            Functions.Error(ee);
        }

        string output = JsonConvert.SerializeObject(ln, Formatting.Indented);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, "");

        return output;
    }


    [WebMethod]
    public string ListNewsV2(string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        List<News> lm = new List<News>();
        List<Nouvelle> ln = new List<Nouvelle>();
        try
        {
            List<News> temp = new List<News>();

            List<News> newsDistrict = (from n in AIS.DataMapping.ListNews(onlyvisible: true, category: "District", tags_excluded: "Bulletin") orderby n.dt ascending where n.dt.CompareTo(DateTime.Now.AddDays(-1)) > 0 select n).ToList<News>();
            List<News> newsClubs = (from n in AIS.DataMapping.ListNews(onlyvisible: true, category: "Clubs", tags_excluded: "Bulletin") orderby n.dt ascending where n.dt.CompareTo(DateTime.Now.AddDays(-1)) > 0 select n).ToList<News>();

            if (newsDistrict != null && newsDistrict.Count() > 0)
            {
                foreach (News m in newsDistrict)
                {
                    m.photo = HttpContext.Current.Server.MapPath(m.GetPhoto());
                    //m.url = HttpContext.Current.Server.MapPath(m.GetUrl());
                    m.PhotoString64 = GetPhotoNew(m.photo, device, version, fonction);

                    string url = "" + m.GetUrl();
                    if (!string.IsNullOrEmpty(url))
                    {
                        m.url = GetBaseUrl() + HttpContext.Current.Server.UrlPathEncode(m.GetUrl());
                        //m.url = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority  + HttpContext.Current.Server.UrlPathEncode(m.GetUrl());
                    }

                    m.urlNews = GetBaseUrl() + urlNews + "?newsid=" + m.id + "&cric=" + m.cric;

                    temp.Add(m);
                }
            }

            if (newsClubs != null && newsClubs.Count() > 0)
            {
                foreach (News m in newsClubs)
                {
                    m.photo = HttpContext.Current.Server.MapPath(m.GetPhoto());
                    //m.url = HttpContext.Current.Server.MapPath(m.GetUrl());
                    m.PhotoString64 = GetPhotoNew(m.photo, device, version, fonction);

                    string url = "" + m.GetUrl();
                    if (!string.IsNullOrEmpty(url))
                    {
                        m.url = GetBaseUrl() + HttpContext.Current.Server.UrlPathEncode(m.GetUrl());
                        //m.url = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority  + HttpContext.Current.Server.UrlPathEncode(m.GetUrl());
                    }

                    m.urlNews = GetBaseUrl() + urlNews + "?newsid=" + m.id + "&cric=" + m.cric;

                    temp.Add(m);
                }
            }

            if (temp != null && temp.Count() > 0)
            {
                lm = temp.OrderBy(x => x.dt).ToList<News>();               
            }
            foreach (News n in lm)
            {
                ln.Add(newsToNouvelle(n));
            }
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();
            Functions.Error(ee);
        }

        string output = JsonConvert.SerializeObject(ln, Formatting.Indented);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, "");

        return output;
    }

    [WebMethod]
    public string GetPhotoNew(string filepath, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        MemoryStream ms = new MemoryStream();

        try
        {
            FileInfo f = new FileInfo(filepath);
            if (f.Exists)
            {
                Image img = Image.FromFile(filepath);
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();
            Functions.Error(ee);
        }
        string jsonString = Convert.ToBase64String(ms.ToArray());
        string output = JsonConvert.SerializeObject(jsonString);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, "");

        return output;
    }

    [WebMethod]
    public string SendMail(string MemberID, string exp, string nom, string obj, string msg, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        string retour = "1";

        try
        {
            int id = 0;
            Member member = null;
            Membre membre = null;
            string message = "Vous avez un message à partir de l'application mobile du district : www.rotary1730.org<br/>";
            message += "Nom & Prenom : " + nom + "<br/>";
            message += "Email : " + exp + "<br/>";
            message += "Message : <br/>";
            message += msg;

            PortalSettings ps = PortalController.GetCurrentPortalSettings();

            if (!string.IsNullOrEmpty(MemberID))
            {
                int.TryParse(MemberID, out id);
                if (id > 0)
                {
                    member = DataMapping.GetMember(id);
                }
            }

            if (member != null)
            {
                membre = memberToMembre(member);
                Mail.SendEmail(exp, ps.Email, membre.email, obj, message);
            }
            else //Envoie au webmaster
            {
                Mail.SendEmail(exp, ps.Email, ps.Email, obj, message);
            }

        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();

            Functions.Error(ee);
            retour = "0";
        }

        string output = JsonConvert.SerializeObject(retour);

        if (retour == "1")
        {
            comment = "Mail envoyé de " + exp + " à Member ID " + MemberID;
        }
        else
        {
            if (comment == "")
            {
                comment = "Mail NON envoyé de " + exp + " à Member ID " + MemberID;
            }
        }

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, "");

        return output;
    }

    [WebMethod]
    public string GetPassword(string UserName, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        string retour = "0";
        string Password = "";

        try
        {
            DotNetNuke.Entities.Users.UserInfo userInfo = DotNetNuke.Entities.Users.UserController.GetUserByName(Globals.GetPortalSettings().PortalId, UserName);
            if (userInfo != null)
            {
                DotNetNuke.Security.Membership.MembershipProvider membershipProvider = DotNetNuke.Security.Membership.MembershipProvider.Instance();

                Password = "" + DotNetNuke.Entities.Users.UserController.GetPassword(ref userInfo, userInfo.Membership.PasswordAnswer);

                if (!string.IsNullOrEmpty(Password))
                {
                    string message = "Récupération de votre mot de passe à partir de l'application mobile du district : www.rotary1730.org<br/>";
                    message += "Votre mot de passe est : <br/>";
                    message += Password;

                    PortalSettings ps = PortalController.GetCurrentPortalSettings();
                    Mail.SendEmail(ps.Email, ps.Email, userInfo.Email, "Récupération de votre mot de passe", message);

                    retour = "1";
                }
            }
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();

            Functions.Error(ee);
            retour = "0";
        }

        string output = JsonConvert.SerializeObject(retour);

        if (retour == "1")
        {
            comment = "Password envoyé à " + UserName;
        }
        else
        {
            if (comment == "")
            {
                comment = "Password NON envoyé à " + UserName;
            }
        }

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, UserName);

        return output;
    }

}
