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
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;
using AIS;
using DotNetNuke.Entities.Host;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Roles;
using DotNetNuke.Services.Mail;
using System.Threading;
using DotNetNuke.UI.Utilities;
using DotNetNuke.Entities.Portals;
using System.Net.Mail;
using System.Net;
using System.IO;

/// <summary>
/// Description résumée de Newsletter
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
// [System.Web.Script.Services.ScriptService]
public class NewsletterWS : System.Web.Services.WebService 
{
    public List<string> la_Liste_Fonction;
    public List<string> La_Liste_Role;
    public string Departement;
    public List<string> La_Liste_AR;
    public string Cric_Members;
    public string President;
    public string Secretaire;

    public NewsletterWS () {

        //Supprimez les marques de commentaire dans la ligne suivante si vous utilisez des composants conçus 
        //InitializeComponent(); 
    }

    public string GetAdminEmail()
    {
        PortalSettings ps = PortalController.GetCurrentPortalSettings();
        return ps.Email;
    }
    public string GetSMTPEmail()
    {
        
        return "webmaster@rotary1730.org";
    }
    public string GetSMTPPassword()
    {
        
        return "17Hayek30!";
    }
    public string ReplaceUrls(string texte, int id)
    {
        //long pre = DateTime.Now.Ticks;

        //File.WriteAllText(Server.MapPath("/"+pre+"texte_" + id + "_a.txt"), texte);

        //StreamWriter sw = new StreamWriter(Server.MapPath("/" + pre + "texte_" + id + "_log.txt"));

        int st = 0;
        int index = texte.IndexOf("=\"http", st);
        //sw.WriteLine("index : "+index+" st : "+st);
        while (st<=texte.Length && index>-1)
        {
            
                index = texte.IndexOf("http", index);
                //sw.WriteLine("index : "+index+" st : "+st);
                int index1 = texte.IndexOf("\"", index + 1);
                //sw.WriteLine("index1 : " + index + " st : " + st);
                if (index1 > index)
                {
                    string url = texte.Substring(index, index1 - index);
                    //sw.WriteLine("Url avant modif");
                    //sw.WriteLine(url);
                    url = "http://www.rotary1730.org/AIS/redir.ashx?id=" + id + "&url=" + HttpUtility.UrlEncode(url);
                    //sw.WriteLine("Url après modif");
                    //sw.WriteLine(url);
                    texte = texte.Substring(0, index) + url + texte.Substring(index1);
                    
                    st = index1;
                }
                else
                {
                    st = index + 6;
                }

                index = texte.IndexOf("=\"http", st);
                //sw.WriteLine("index : " + index + " st : " + st);

        }
        //sw.Flush();
        //sw.Close();

        //File.WriteAllText(Server.MapPath("/" + pre + "texte_" + id + "_b.txt"), texte);
        
        return texte;
    }


    [WebMethod]
    public string HelloWorld(string token) 
    {
        if (!CheckToken(token))
        {
            return "";
        }
        else
        {
            return "Hello World";
        }
    }

    [WebMethod]
    public string Get_Mail_Test(string token)
    {
        if (!CheckToken(token))
        {
            return "Erreur de Token";
        }
        else
        {
            try
            {
                List<Newsletter_Out> Liste_Test = DataMapping.Get_Mails_Test();
                StringBuilder sb = new StringBuilder();
                
                if (Liste_Test != null)
                {
                    if (Liste_Test.Count > 0)
                    {
                        foreach (Newsletter_Out n in Liste_Test)
                        {
                            List<System.Net.Mail.Attachment> att = new List<System.Net.Mail.Attachment>();

                            PortalSettings ps = PortalController.GetCurrentPortalSettings();
                           

                           // string result = Mail.SendEmail(GetAdminEmail(), GetAdminEmail(), n.email, n.la_Newsletter.titre, n.la_Newsletter.texte, att);
                            bool resultat_MAJ = true;
                            
                            try
                            {
                                Newsletter news = DataMapping.GetNewsletter(n.newsletter_id);


                                MailMessage message = new MailMessage(new MailAddress(ps.Email, ps.PortalName), new MailAddress(n.email, ""));
                                
                                message.ReplyToList.Add(new MailAddress(news.sender_email, news.sender_name));
                                //message.ReplyTo = new MailAddress(newsletter.replyemail, newsletter.fromname);
                                message.Subject = n.la_Newsletter.title;
                                message.IsBodyHtml = true;
                                
                                message.Body = ReplaceUrls(n.la_Newsletter.text,n.id);
                                message.BodyEncoding = Encoding.UTF8;
                                message.Headers.Add("X-AIS-Ref", n.newsletter_id);
                                message.DeliveryNotificationOptions =
                                  DeliveryNotificationOptions.OnFailure |
                                  DeliveryNotificationOptions.OnSuccess |
                                  DeliveryNotificationOptions.Delay;
                                message.Headers.Add("Disposition-Notification-To", ps.Email);


                                string SMTPServer = "" + ps.HostSettings["SMTPServer"];
                                int portPos = SMTPServer.IndexOf(":");
                                int SMTPPort = 25;
                                if (portPos > -1)
                                {
                                    SMTPPort = int.Parse(SMTPServer.Substring(portPos + 1, SMTPServer.Length - portPos - 1));
                                    SMTPServer = SMTPServer.Substring(0, portPos);
                                }

                                SmtpClient client = new SmtpClient(SMTPServer, SMTPPort);
                                client.UseDefaultCredentials = false;
                                //client.Credentials = new NetworkCredential("" + ps.HostSettings["SMTPUsername"], "" + ps.HostSettings["SMTPPassword"]);
                                client.Credentials = new NetworkCredential(GetSMTPEmail(), GetSMTPPassword());
                                client.Send(message);
                                message.Dispose();

                                sb.AppendLine("Succes de l'envoie du mail Test id = " + n.id.ToString());
                                n.status = "T";
                                n.error = "";
                                resultat_MAJ = DataMapping.Update_Newsletter_Out(n);
                            
                            }
                            catch (Exception ee)
                            {
                                sb.AppendLine("Erreur lors de l'envoie du mail Test id = " + n.id.ToString());
                                n.status = "E";
                                n.error = ee.Message;
                                resultat_MAJ = DataMapping.Update_Newsletter_Out(n);
                            }

                            //string result = Mail.SendMail(HostEmail, n.email, "", "", "", MailPriority.Normal, n.la_Newsletter.titre, MailFormat.Html, System.Text.Encoding.UTF8, n.la_Newsletter.texte, att, SMTPServer, SMTPAuthentication, SMTPUsername, SMTPPassword, false);

                            //if (!string.IsNullOrEmpty(result))
                            //{
                            //    sb.AppendLine("Erreur lors de l'envoie du mail Test id = " + n.id.ToString());
                            //    n.statut = "E";
                            //    n.erreur = result;
                            //    resultat_MAJ = DataMapping.Update_Newsletter_Out(n);
                            //}
                            //else
                            //{
                            //    sb.AppendLine("Succes de l'envoie du mail Test id = " + n.id.ToString());
                            //    n.statut = "T";
                            //    n.erreur = "";
                            //    resultat_MAJ = DataMapping.Update_Newsletter_Out(n);
                            //}

                            if (resultat_MAJ == false)
                            {
                                sb.AppendLine("Erreur lors de la MAJ du mail Test id = " + n.id.ToString());
                            }
                            //Thread.Sleep(5000);
                        } // end FOREACH
                    }
                    else
                    {
                        return "Pas de mails de Test à envoyer";
                    }
                }
                else
                {
                    return "Problème lors de la récupération des mails de Test";
                }
                return sb.ToString();
            }
            catch(Exception ee)
            {
                return ee.Message;
            }
        }
    }

    [WebMethod]
    public string Get_Newsletter_P(string token)
    {
        if (!CheckToken(token))
        {
            return "Erreur de Token";
        }
        else
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                Newsletter n = DataMapping.GetNewsletter_By_status("P");

                if(n != null)
                {
                    if(!string.IsNullOrEmpty(n.recipient))
                    {
                        List<Member> les_Destinataires = new List<Member>();

                        la_Liste_Fonction = new List<string>();
                        La_Liste_Role = new List<string>();
                        Departement = "";
                        President = "";
                        Secretaire = "";
                        La_Liste_AR = new List<string>();
                        Cric_Members = "";

                        string[] splits = n.recipient.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string s in splits)
                        {
                            switch (s.Substring(0, 2))
                            {
                                case "R:":
                                    La_Liste_Role.Add(s.Remove(0, 2));
                                    break;

                                case "F:":
                                    la_Liste_Fonction.Add(s.Remove(0, 2));
                                    break;

                                case "D:":
                                    Departement = (s.Remove(0, 2));                                    
                                    break;

                                case "B:":
                                    if (s.Remove(0, 2) == "Président")
                                    {
                                        President = s.Remove(0, 2);
                                    }
                                    else if (s.Remove(0, 2) == "Secrétaire")
                                    {
                                        Secretaire = s.Remove(0, 2);
                                    }
                                    break;

                                case "A:":
                                    La_Liste_AR.Add(s.Remove(0, 2));
                                    break;

                                case "M:":
                                    Cric_Members = s.Remove(0, 2);
                                    break;
                            } // Fin Switch
                        } // Fin foreach

                        if (n.recipient.Contains("R:") || n.recipient.Contains("F:"))
                        {
                            les_Destinataires = Recherche_District();
                        }
                        else
                        {
                            les_Destinataires = Recherche_Club();
                        }

                        if(les_Destinataires != null)
                        {
                            if(les_Destinataires.Count > 0)
                            {
                                bool result = DataMapping.Insert_Newsletter_Out(n, les_Destinataires, "A");

                                if(result == true)
                                {
                                    return null;
                                }
                                else
                                {
                                    sb.AppendLine("Erreur lors de la création des destinataires de la newsletter " + n.id);
                                }
                            }
                            else
                            {
                                sb.AppendLine("Pas de destinataire(s) dans la newsletter " + n.id);
                            } 
                        }
                        else
                        {
                            sb.AppendLine("Problème de récupération des destinataires de la newsletter " + n.id);
                        } 
                    }
                    else
                    {
                        sb.AppendLine("Pas de destinataire(s) dans la newsletter " + n.id);
                    }                    
                }
                else
                {
                    sb.AppendLine("Pas de newsletter en attente.");
                }


                return sb.ToString();
            }
            catch (Exception ee)
            {
                return ee.Message;
            }
        }
    }

    [WebMethod]
    public string Get_Newsletter_E(string token)
    {
        if (!CheckToken(token))
        {
            return "Erreur de Token";
        }
        else
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                Newsletter n = DataMapping.GetNewsletter_By_status("E");

                if(n != null)
                {
                    List<Newsletter_Out> Liste = DataMapping.Get_Recipient_by_Newsletter_id(n.id, "A");
                    if (Liste != null)
                    {
                        if (Liste.Count > 0)
                        {
                            Newsletter_Out n_o = Liste[0] as Newsletter_Out;
                            //foreach (Newsletter_Out n_o in Liste)
                            //{
                                List<System.Net.Mail.Attachment> att = new List<System.Net.Mail.Attachment>();
                                PortalSettings ps = PortalController.GetCurrentPortalSettings();
                                bool resultat_MAJ = true;
                                try
                                {



                                    MailMessage message = new MailMessage(new MailAddress(ps.Email, ps.PortalName), new MailAddress(n_o.email, ""));
                                    //message.ReplyTo = new MailAddress(newsletter.replyemail, newsletter.fromname);
                                    message.ReplyToList.Add(new MailAddress(n.sender_email,n.sender_name));
                                    message.Subject = n.title;
                                    message.IsBodyHtml = true;

                                    message.Body = ReplaceUrls(n.text,n_o.id);
                                    message.BodyEncoding = Encoding.UTF8;
                                    message.Headers.Add("X-AIS-Ref", n.id);
                                    message.DeliveryNotificationOptions =
                                      DeliveryNotificationOptions.OnFailure |
                                      DeliveryNotificationOptions.OnSuccess |
                                      DeliveryNotificationOptions.Delay;
                                    message.Headers.Add("Disposition-Notification-To", ps.Email);

                                    string SMTPServer = "" + ps.HostSettings["SMTPServer"];
                                    int portPos = SMTPServer.IndexOf(":");
                                    int SMTPPort = 25;
                                    if (portPos > -1)
                                    {
                                        SMTPPort = int.Parse(SMTPServer.Substring(portPos + 1, SMTPServer.Length - portPos - 1));
                                        SMTPServer = SMTPServer.Substring(0, portPos);
                                    }

                                    SmtpClient client = new SmtpClient(SMTPServer, SMTPPort);
                                    client.UseDefaultCredentials = false;
                                    //client.Credentials = new NetworkCredential("" + ps.HostSettings["SMTPUsername"], "" + ps.HostSettings["SMTPPassword"]);
                                    client.Credentials = new NetworkCredential(GetSMTPEmail(), GetSMTPPassword());
                                    client.Send(message);
                                    message.Dispose();

                                    sb.AppendLine("Succes de l'envoie du mail : " + n_o.email + ", newsletter : "+n.title);
                                    n_o.status = "T";
                                    n_o.error = "";
                                    resultat_MAJ = DataMapping.Update_Newsletter_Out(n_o);

                                }
                                catch (Exception ee)
                                {
                                    sb.AppendLine("Erreur lors de l'envoie du mail : " + n_o.email + ", newsletter : " + n.title);
                                    n_o.status = "E";
                                    n_o.error = ee.Message;
                                    resultat_MAJ = DataMapping.Update_Newsletter_Out(n_o);
                                }


                                //string result = Mail.SendEmail(GetAdminEmail(), GetAdminEmail(), n_o.email, n.titre, n.texte, att);
                                ////string result = Mail.SendMail(HostEmail, n.email, "", "", "", MailPriority.Normal, n.la_Newsletter.titre, MailFormat.Html, System.Text.Encoding.UTF8, n.la_Newsletter.texte, att, SMTPServer, SMTPAuthentication, SMTPUsername, SMTPPassword, false);

                                //bool resultat_MAJ = true;
                                //if (!string.IsNullOrEmpty(result))
                                //{
                                //    sb.AppendLine("Erreur lors de l'envoie du mail id = " + n_o.id.ToString());
                                //    n_o.statut = "E";
                                //    n_o.erreur = result;
                                //    resultat_MAJ = DataMapping.Update_Newsletter_Out(n_o);
                                //}
                                //else
                                //{
                                //    sb.AppendLine("Succes de l'envoie du mail id = " + n_o.id.ToString());
                                //    n_o.statut = "T";
                                //    n_o.erreur = "";
                                //    resultat_MAJ = DataMapping.Update_Newsletter_Out(n_o);
                                //}

                                if (resultat_MAJ == false)
                                {
                                    sb.AppendLine("Erreur lors de la MAJ du mail : " + n_o.email + ", newsletter : " + n.title);
                                }

                             //   Thread.Sleep(5000);
                            //} //end foreach

                           
                        }
                        else
                        {
                            
                            n.status = "T";

                            bool retour = DataMapping.UpdateNewsletter(n);

                            if (retour == true)
                            {
                                sb.AppendLine("");
                            }
                            else
                            {
                                sb.AppendLine("Problème lors de la mise à jour de la newsletter " + n.title);
                            }

                            return "Pas de mails à envoyer";
                            
                        }
                    }
                    else
                    {
                        return "Problème lors de la récupération des mails";
                    }
                }
                else
                {
                    sb.AppendLine("Pas de newsletter en attente.");
                }


                return sb.ToString();
            }
            catch (Exception ee)
            {
                return ee.Message;
            }
        }
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

    protected List<Member> Recherche_District()
    {       
        List<Member> la_Liste = new List<Member>();
        List<Member> la_Liste_Members_Fonction = new List<Member>();
        List<Member> La_Liste_Members_Role = new List<Member>();

        #region Recherche par functions
        string requete = " SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE ";
        if (la_Liste_Fonction != null)
        {
            if (la_Liste_Fonction.Count > 0)
            {
                string requete_AR = "";
                string requete_FCT = "";

                #region AR
                if (La_Liste_AR != null)
                {
                    if (La_Liste_AR.Count > 0)
                    {
                        if (La_Liste_AR.Count == 1)
                        {
                            requete_AR = requete_AR + " rotary_year = '" + La_Liste_AR[0] + "' ";
                        }
                        else
                        {
                            for (int i = 0; i < La_Liste_AR.Count; i++)
                            {
                                if (i == 0)
                                {
                                    requete_AR = requete_AR + " (rotary_year = '" + La_Liste_AR[i] + "' ";
                                }
                                else
                                {
                                    requete_AR = requete_AR + " OR rotary_year = '" + La_Liste_AR[i] + "' ";
                                }
                            }
                            requete_AR = requete_AR + ")";
                        }
                    }
                    else //Si pas AR selectionné => année en cours sélectionné
                    {
                        int annee_0 = Functions.GetRotaryYear();
                        requete_AR = requete_AR + " rotary_year = '" + annee_0.ToString() + "'";
                    }
                }
                else
                {
                    int annee_0 = Functions.GetRotaryYear();
                    requete_AR = requete_AR + " rotary_year = '" + annee_0.ToString() + "'";
                }
                #endregion AR

                #region Fonction
                if (la_Liste_Fonction.Count == 1)
                {
                    requete_FCT = requete_FCT + " AND [function] = '" + la_Liste_Fonction[0] + "' ";
                }
                else
                {
                    for (int i = 0; i < la_Liste_Fonction.Count; i++)
                    {
                        if (i == 0)
                        {
                            requete_FCT = requete_FCT + " AND ([function] = '" + la_Liste_Fonction[i] + "' ";
                        }
                        else
                        {
                            requete_FCT = requete_FCT + " OR [function] = '" + la_Liste_Fonction[i] + "' ";
                        }
                    }
                    requete_FCT = requete_FCT + ")";
                }
                #endregion Fonction

                requete = requete + requete_AR + requete_FCT + ") ";

                if (!string.IsNullOrEmpty(Departement))
                {
                    requete = requete + " AND cric in (SELECT cric FROM " + Const.TABLE_PREFIX + "clubs WHERE SUBSTRING(zip, 1, 2) IN (" + Departement + "))";
                }

                la_Liste_Members_Fonction = DataMapping.GetListMembers_Mailling(requete);
            }
        }
        #endregion Recherche par functions

        #region Recherche par role
        if (La_Liste_Role != null)
        {
            List<string> Liste_Email = new List<string>();
            RoleController ObjRoleController = new RoleController();
            foreach (string s in La_Liste_Role)
            {
                var arrUsers = ObjRoleController.GetUsersByRoleName(0, s);
                foreach (UserInfo u in arrUsers)
                {
                    if (!string.IsNullOrEmpty(u.Email))
                    {
                        Liste_Email.Add("'" + u.Email + "'");
                    }
                }
            }

            string ListeEmail = string.Join(",", Liste_Email);
            La_Liste_Members_Role = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE email IN (" + ListeEmail + ") ");
        }
        #endregion Recherche par role

        #region Trie entre les listes
        if (la_Liste_Members_Fonction != null)
        {
            foreach (Member m in la_Liste_Members_Fonction)
            {
                la_Liste.Add(m);
            }
        }

        if (La_Liste_Members_Role != null)
        {
            foreach (Member mp in La_Liste_Members_Role)
            {
                if (!la_Liste.Exists(mem => mem.nim == mp.nim))
                {
                    la_Liste.Add(mp);
                }
            }
        }
        #endregion Trie entre les listes

        

        return la_Liste;
    }

    protected List<Member> Recherche_Club()
    {
        List<Member> La_Liste = new List<Member>();
        List<Member> Liste_Members = new List<Member>();
        List<Member> Liste_President = new List<Member>();
        List<Member> Liste_Secretaire = new List<Member>();       

        int annee_0 = Functions.GetRotaryYear();

        #region Secrétaire
        if (!string.IsNullOrEmpty(Secretaire))
        {
            if (string.IsNullOrEmpty(Departement))
            {
                Liste_Secretaire = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function] = 'Secrétaire' AND rotary_year = '" + annee_0.ToString() + "')");
            }
            else
            {
                Liste_Secretaire = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function] = 'Secrétaire' AND rotary_year = '" + annee_0.ToString() + "'  AND cric in (SELECT cric FROM " + Const.TABLE_PREFIX + "clubs WHERE SUBSTRING(zip, 1, 2) IN (" + Departement + ")))");
            }
        }
        #endregion Secrétaire

        #region Président
        if (!string.IsNullOrEmpty(President))
        {
            if (string.IsNullOrEmpty(Departement))
            {
                Liste_President = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function] = 'Président' AND rotary_year = '" + annee_0.ToString() + "')");
            }
            else
            {
                Liste_President = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function] = 'Président' AND rotary_year = '" + annee_0.ToString() + "' AND cric in (SELECT cric FROM " + Const.TABLE_PREFIX + "clubs WHERE SUBSTRING(zip, 1, 2) IN (" + Departement + ")))");
            }
        }
        #endregion Président

        #region Tous les membres du club
        if (!string.IsNullOrEmpty(Cric_Members))
        {
            Liste_Members = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE cric='" + Cric_Members + "'");
        }
        #endregion Tous les membres du club

        #region Trie entre les listes
        if (Liste_Members != null)
        {
            foreach (Member m in Liste_Members)
            {
                La_Liste.Add(m);
            }
        }

        if (Liste_President != null)
        {
            foreach (Member mp in Liste_President)
            {
                if (!La_Liste.Exists(mem => mem.nim == mp.nim))
                {
                    La_Liste.Add(mp);
                }
            }
        }

        if (Liste_Secretaire != null)
        {
            foreach (Member ms in Liste_Secretaire)
            {
                if (!La_Liste.Exists(mem => mem.nim == ms.nim))
                {
                    La_Liste.Add(ms);
                }
            }
        }
        #endregion Trie entre les listes

        

        return La_Liste;
    }

    public bool CheckToken(string token)
    {
        string guidmd5 = CalculateMD5Hash(StringToBytes(""+DotNetNuke.Entities.Portals.PortalSettings.Current.GUID));
        return guidmd5 == token;
    }
    public string CalculateMD5Hash(byte[] inputBytes)
    {
        // step 1, calculate MD5 hash from input
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] hash = md5.ComputeHash(inputBytes);

        // step 2, convert byte array to hex string
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString();
    }
    public byte[] StringToBytes(string chaine)
    {
        System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
        return encoding.GetBytes(chaine);
    }

         
}
